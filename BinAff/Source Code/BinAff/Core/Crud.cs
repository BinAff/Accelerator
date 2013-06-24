using System;
using System.Collections.Generic;
using System.Transactions;

namespace BinAff.Core
{

    public abstract class Crud : ICrud
    {

        public Data Data { get; protected set; }

        public Data parentData;
        public Data ParentData 
        {
            get
            {
                return this.parentData;
            }
            set
            {
                if (this.parentData != value)
                {
                    this.parentData = value;
                    this.DataAccess.ParentData = value;
                    this.Validator.ParentData = value;
                }
            }
        }

        private Action actionType;
        private Boolean isMultiValuedChild;

        public Dao dataAccess;
        /// <summary>
        /// Object for data access from database
        /// </summary>
        public Dao DataAccess
        {
            get
            {
                return this.dataAccess;
            }
            set
            {
                this.dataAccess = value;
                if(this.dataAccess != null) this.dataAccess.Server = this;
            }
        }

        public Validator validator;
        /// <summary>
        /// Object for validation
        /// </summary>
        public Validator Validator
        {
            get
            {
                return this.validator;
            }
            set
            {
                this.validator = value;
                if(this.validator != null) this.validator.Server = this;
            }
        }

        /// <summary>
        /// Name of the component
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Is skiping CRUD
        /// </summary>
        public Boolean IsSkip { get; set; }

        /// <summary>
        /// Is skiping create, update and delete
        /// </summary>
        public Boolean IsReadOnly { get; set; }

        /// <summary>
        /// Kind of child with respect to parent
        /// </summary>
        public ChildType Type { get; set; }

        /// <summary>
        /// Child class will hold parent reference
        /// </summary>
        private List<Crud> dependentChildren;

        /// <summary>
        /// Parent class will hold child reference
        /// </summary>
        private List<Crud> independentChildren;

        public Crud(Data data)
        {
            this.Data = data;
            this.dependentChildren = new List<Crud>();
            this.independentChildren = new List<Crud>();
            this.Compose();
        }

        protected abstract void Compose();

        /// <summary>
        /// Create data object
        /// </summary>
        /// <returns></returns>
        internal protected abstract Data CreateDataObject();

        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="data">Data object</param>
        /// <returns></returns>
        protected abstract Crud CreateInstance(Data data);

        /// <summary>
        /// Create children component list
        /// </summary>
        protected virtual void CreateChildren()
        {

        }

        protected virtual void FindChildrenData()
        {

        }

        /// <summary>
        /// Add child component to parent component
        /// </summary>
        /// <param name="child">Child component</param>
        protected Data AddChild(Crud child)
        {
            if (this.actionType == Action.Delete && child.Data == null) return null;
            //Assign parent data
            child.ParentData = this.Data;
            child.DataAccess.ParentData = this.Data;
            child.Validator.ParentData = this.Data;

            if (child.Data == null)
            {
                //if (this.actionType == Action.Delete)
                //{
                //    child.Data = child.CreateDataObject();
                //    child.DataAccess.Data = child.Data;
                //    child.Validator.Data = child.Data;
                //    if (child.Type == ChildType.Dependent)
                //    {
                //        child.DataAccess.ReadForParent(); //Assign child data
                //    }
                //    else
                //    {
                //        //In case of independent children, read own to get children Ids, because independent
                //        //child id will be written in parent table or relationship table under parent
                //        this.ReadOwn();
                //    }
                //}                
                if (this.actionType == Action.Read)
                {
                    if (child.Type == ChildType.Dependent)
                    {
                        child.Data = child.CreateDataObject();
                        child.DataAccess.Data = child.Data;
                        child.Validator.Data = child.Data;
                        child.DataAccess.ReadForParent();
                        //child.IsSkip = true;
                    }
                }
                if (this.actionType == Action.Create || this.actionType == Action.Update)
                {
                    child.Validator = null;
                    child.DataAccess = null;
                    child = null;
                }
            }

            if (child != null && child.Data != null)
            {
                if (child.Type == ChildType.Dependent)
                {
                    this.dependentChildren.Add(child);
                }
                else
                {
                    this.independentChildren.Add(child);
                }
                return child.Data;
            }
            return null;
        }

        /// Add children component to parent component
        /// </summary>
        /// <param name="schema">Child component</param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        protected List<Data> AddChildren(Crud schema, List<Data> dataList)
        {
            if (dataList == null)
            {
                Crud child = schema.CreateInstance(null);
                child.Type = schema.Type;
                child.IsReadOnly = schema.IsReadOnly;
                child.IsSkip = schema.IsSkip;
                child.ParentData = schema.ParentData;
                this.AddChild(child);
            }
            if (dataList != null && dataList.Count > 0)
            {
                foreach (Data data in dataList)
                {
                    Crud child = schema.CreateInstance(data);
                    child.Type = schema.Type;
                    child.IsReadOnly = schema.IsReadOnly;
                    child.IsSkip = schema.IsSkip;
                    child.ParentData = schema.ParentData;
                    child.isMultiValuedChild = true;
                    this.AddChild(child);
                }
                return dataList;
            }
            return null;
        }

        protected virtual Data GetDataForParent()
        {
            return this.DataAccess.GetDataFromParentData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ReturnObject<Boolean> SaveInternal()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };

            this.actionType = this.Data.Id == 0 ? Action.Create : Action.Update;
            this.CreateChildren();

            //Validate
            retObj.MessageList = this.Validate();
            if (retObj.HasError()) retObj.Value = false;
            if (!retObj.Value) return retObj;

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                //Manage hook before
                if (!ManipulateRetuenObject(retObj, this.actionType == Action.Create ? this.CreateBefore() : this.UpdateBefore()).Value) return retObj;

                if (this.actionType == Action.Update) this.PrepareChildrenForUpdate();

                //Save independent children
                foreach (ICrud child in this.independentChildren)
                {
                    if (!((Crud)child).IsReadOnly && !this.SaveOrDelete(child, retObj).Value) return retObj;
                }

                //Save own
                if (!ManipulateRetuenObject(retObj, this.actionType == Action.Create ? this.Create() : this.Update()).Value) return retObj;

                //Save dependent children
                foreach (ICrud child in this.dependentChildren)
                {
                    if (!((Crud)child).IsReadOnly && !this.SaveOrDelete(child, retObj).Value) return retObj;
                }

                //Manage hook after
                if (!ManipulateRetuenObject(retObj, this.actionType == Action.Create ? this.CreateAfter() : this.UpdateAfter()).Value) return retObj;
                T.Complete();
            }
            
            return retObj;
        }

        private void PrepareChildrenForUpdate()
        {
            //Mark Id all existing children to 0, such that it will insert only
            foreach (Crud child in this.dependentChildren)
            {
                if(child.isMultiValuedChild && !child.IsReadOnly) child.Data.Id = 0;
            }
            foreach (Crud child in this.independentChildren)
            {
                if (child.isMultiValuedChild && !child.IsReadOnly) child.Data.Id = 0;
            }

            //Prepare children for deletion
            Data d = this.CreateDataObject();
            d.Id = this.Data.Id;
            Crud me = this.CreateInstance(d);
            me.Read();
            me.dependentChildren.Clear();
            me.independentChildren.Clear();
            me.actionType = Action.Delete;
            me.CreateChildren();
            //Map deletable dependent children
            foreach (Crud child in me.dependentChildren)
            {
                if (child.isMultiValuedChild)
                {
                    child.Data.IsDeletable = true;
                    this.dependentChildren.Add(child);
                }
            }
            //Map deletable independent children
            foreach (Crud child in me.independentChildren)
            {
                if (child.isMultiValuedChild)
                {
                    child.Data.IsDeletable = true;
                    this.independentChildren.Add(child);
                }
            }
        }

        private List<Message> Validate()
        {
            List<Message> valMsgLst = new List<Message>();
            IValidator val = this.Validator;
            valMsgLst = val.Validate();

            //Validate independent children
            foreach (Crud child in this.independentChildren)
            {
                if (!child.IsSkip && !child.IsReadOnly)
                {
                    val = child.Validator;
                    valMsgLst.AddRange(val.Validate());
                }
            }

            //Validate independent children
            foreach (Crud child in this.dependentChildren)
            {
                if (!child.IsSkip && !child.IsReadOnly)
                {
                    val = child.Validator;
                    valMsgLst.AddRange(val.Validate());
                }
            }
            return valMsgLst;
        }

        /// <summary>
        /// Save or delete child
        /// </summary>
        /// <remarks>
        /// In case of parent updation, child may be deleted or saved (Created or Updated)
        /// </remarks>
        /// <param name="crud">CRUD engine</param>
        /// <param name="retObj">Return object</param>
        /// <returns></returns>
        private ReturnObject<Boolean> SaveOrDelete(ICrud crud, ReturnObject<Boolean> retObj)
        {
            if (!((Crud)crud).IsSkip && ((Crud)crud).Data != null)
            {
                if (!ManipulateRetuenObject(retObj, (((Crud)crud).Data.IsDeletable && this.actionType == Action.Update) ? crud.Delete() : crud.Save()).Value) return retObj;
            }
            return retObj;
            //if (!((Crud)crud).IsSkip && ((Crud)crud).Data != null)
            //{
            //    if (((Crud)crud).Data.IsDeletable && this.actionType == Action.Update)
            //    {
            //        //Manage before hook
            //        if (this.DataAccess.DeleteBefore())
            //        {
            //            return new ReturnObject<Boolean>
            //            {
            //            };
            //        }
            //        //if (!this.ManipulateRetuenObject(retObj, this.DataAccess.DeleteBefore()).Value) return retObj;
            //        //Delete own with all children
            //        if (!this.ManipulateRetuenObject(retObj, crud.Delete()).Value) return retObj;
            //        //Manage after hook
            //        if (!this.ManipulateRetuenObject(retObj, this.DeleteAfter()).Value) return retObj;
            //    }
            //    else
            //    {
            //        //Manage hook before
            //        if (!ManipulateRetuenObject(retObj, this.actionType == Action.Create ? this.CreateBefore() : this.UpdateBefore()).Value) return retObj;
            //        //Save own
            //        if (!ManipulateRetuenObject(retObj, crud.Save()).Value) return retObj;
            //        //Manage hook after
            //        if (!ManipulateRetuenObject(retObj, this.actionType == Action.Create ? this.CreateAfter() : this.UpdateAfter()).Value) return retObj;
            //    }
            //}
            //return retObj;
        }

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <returns></returns>
        protected ReturnObject<Boolean> Create()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                MessageList = new List<Message>()
            };

            if (!this.IsSkip && !this.IsReadOnly)
            {
                retObj.Value = this.DataAccess.Create();
                String msg;
                if (retObj.Value)
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data successfully inserted." : this.Name + " data successfully inserted.";
                }
                else
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data insertion failed." : this.Name + " data insertion failed.";
                }
                retObj.MessageList.Add(new Message(msg, Message.Type.Information));
            }

            return retObj;
        }

        /// <summary>
        /// Update existing record
        /// </summary>
        /// <returns></returns>
        protected ReturnObject<Boolean> Update()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                MessageList = new List<Message>()
            };

            if (!this.IsSkip && !this.IsReadOnly)
            {
                retObj.Value = this.DataAccess.Update();
                String msg;
                if (retObj.Value)
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data successfully updated." : this.Name + " data successfully updated.";
                }
                else
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data updation failed." : this.Name + " data updation failed.";
                }
                retObj.MessageList.Add(new Message(msg, Message.Type.Information));
            }

            return retObj;
        }

        private ReturnObject<Boolean> DeleteInternal()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };

            this.actionType = Action.Delete;
            this.Read();
            this.dependentChildren.Clear();
            this.independentChildren.Clear();
            this.actionType = Action.Delete;
            this.CreateChildren();

            if (this.Data.Id != 0) //There is no data to delete
            {
                using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
                {
                    //Manage before hook
                    if (!this.ManipulateRetuenObject(retObj, this.DeleteBefore()).Value) return retObj;

                    //Check the data is deletable or not
                    if(!this.ManipulateRetuenObject(retObj, this.validator.IsDeletable()).Value) return retObj;

                    //Delete own with all children
                    if (!this.ManipulateRetuenObject(retObj, this.Delete()).Value) return retObj;

                    //Manage after hook
                    if (!this.ManipulateRetuenObject(retObj, this.DeleteAfter()).Value) return retObj;
                    T.Complete();
                }
            }

            return retObj;
        }

        /// <summary>
        /// Delete own data with all children data
        /// </summary>
        /// <returns></returns>
        protected virtual ReturnObject<Boolean> Delete()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };

            //Delete dependent children
            if (!ManipulateRetuenObject(retObj, this.DeleteChildren(this.dependentChildren)).Value) return retObj;

            //Delete own
            if (!ManipulateRetuenObject(retObj, this.DeleteOwn()).Value) return retObj;

            //Delete independent children
            if (!ManipulateRetuenObject(retObj, this.DeleteChildren(this.independentChildren)).Value) return retObj;

            return retObj;
        }

        /// <summary>
        /// Delete own data
        /// </summary>
        /// <returns></returns>
        protected virtual ReturnObject<Boolean> DeleteOwn()
        {
            if (!this.IsSkip && !this.IsReadOnly && this.Data != null)
            {
                ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
                {
                    Value = this.DataAccess.Delete(),
                    MessageList = new List<Message>()
                };
                String msg;
                if (retObj.Value)
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data successfully deleted." : this.Name + " data successfully deleted.";
                }
                else
                {
                    msg = String.IsNullOrEmpty(this.Name) ? "Data deletion failed." : this.Name + " data deletion failed.";
                }
                retObj.MessageList.Add(new Message(msg, Message.Type.Information));
                return retObj;
            }

            //Data not deleted due to rule
            return new ReturnObject<Boolean>()
            {
                Value = true
            };
        }

        /// <summary>
        /// Delete chldren data
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        protected virtual ReturnObject<Boolean> DeleteChildren(List<Crud> children)
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
            foreach (ICrud child in children)
            {
                if (!((Crud)child).IsSkip && !((Crud)child).IsReadOnly && ((Crud)child).Data != null)
                {
                    if (!ManipulateRetuenObject(retObj, child.Delete()).Value) return retObj;
                }
            }
            return retObj;
        }

        protected virtual ReturnObject<Data> Read()
        {
            this.actionType = Action.Read;
            //Read own
            ReturnObject<Data> retObj = ReadOwn();

            //Create children
            this.CreateChildren();
            //Read dependent
            foreach (ICrud child in this.dependentChildren)
            {
                using (ReturnObject<Data> temp = child.Read())
                {
                    if (temp.MessageList != null && temp.MessageList.Count > 0)
                    {
                        if (retObj.MessageList == null) retObj.MessageList = new List<Message>();
                        retObj.MessageList.AddRange(temp.MessageList);
                    }
                }
            }

            //Read independent
            foreach (ICrud child in this.independentChildren)
            {
                using (ReturnObject<Data> temp = child.Read())
                {
                    if (temp.MessageList != null && temp.MessageList.Count > 0)
                    {
                        if (retObj.MessageList == null) retObj.MessageList = new List<Message>();
                        retObj.MessageList.AddRange(temp.MessageList);
                    }
                }
            }

            return retObj;
        }

        protected virtual ReturnObject<Data> ReadOwn()
        {
            ReturnObject<Data> retObj = new ReturnObject<Data>();
            if (!this.IsSkip && this.Data.Id != 0)//Data is not holding anything
            {
                retObj.Value = this.DataAccess.Read();
            }

            if (retObj.Value == null) retObj.MessageList = new List<Message> { new Message("No data found for " + this.Name, Message.Type.Information) };

            return retObj;
        }

        protected virtual ReturnObject<List<Data>> ReadAll()
        {
            ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = ((Dao)this.DataAccess).ReadAll()
            };

            foreach (BinAff.Core.Data data in retList.Value)
            {
                ICrud crud = this.CreateInstance(data);
                crud.Read();
            }

            return retList;
        }

        #region Hook

        protected virtual ReturnObject<Boolean> CreateBefore()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        protected virtual ReturnObject<Boolean> CreateAfter()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        protected virtual ReturnObject<Boolean> UpdateBefore()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        protected virtual ReturnObject<Boolean> UpdateAfter()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        protected virtual ReturnObject<Boolean> DeleteBefore()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        protected virtual ReturnObject<Boolean> DeleteAfter()
        {
            return new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };
        }

        #endregion

        #region ICrud Members

        ReturnObject<Boolean> ICrud.Save()
        {
            return this.SaveInternal();
        }

        ReturnObject<Boolean> ICrud.Delete()
        {
            return this.DeleteInternal();
        }

        ReturnObject<Data> ICrud.Read()
        {
            return this.Read();
        }

        ReturnObject<List<Data>> ICrud.ReadAll()
        {
            return this.ReadAll();
        }

        #endregion

        protected ReturnObject<Boolean> ManipulateRetuenObject(ReturnObject<Boolean> retObj, ReturnObject<Boolean> result)
        {
            if (result.MessageList != null && result.MessageList.Count > 0)
                retObj.MessageList.AddRange(result.MessageList);
            retObj.Value &= result.Value;
            if (retObj.HasError()) retObj.Value = false;
            return retObj;
        }

        public enum ChildType
        {
            Dependent = 1,
            Independent = 2
        }

        public enum Action
        {
            Create,
            Read,
            Update,
            Delete
        }

    }

}
