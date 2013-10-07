using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public abstract class Manager
    {
        private Crud start;
        
        public Data Data { get; private set; }
        private Crud Parent { get; set; }

        //public Crud(Data data)
        //{
        //    this.Data = data;
        //}

        //protected void AddChild(Crud child)
        //{
        //    this.Parent = this;
        //}

        private ReturnObject<Boolean> Save()
        {
            ReturnObject<Boolean> retObj;

            //Manage before hook
            retObj = this.SaveBefore();
            if (retObj.IsError()) retObj.Value = false;
            if (retObj.Value == false) return retObj;
            //

            if (this.Data.Id == 0)
            {
                using (ReturnObject<Boolean> temp = this.Create())
                {
                    if (temp.MessageList != null && temp.MessageList.Count > 0)
                        retObj.MessageList.AddRange(temp.MessageList);
                    retObj.Value &= temp.Value;
                }
            }
            else
            {
                using (ReturnObject<Boolean> temp = this.Update())
                {
                    if (temp.MessageList != null && temp.MessageList.Count > 0)
                        retObj.MessageList.AddRange(temp.MessageList);
                    retObj.Value &= temp.Value;
                }
            }

            if (retObj.IsError()) retObj.Value = false;
            if (retObj.Value == false) return retObj;

            //Manage after hook
            using (ReturnObject<Boolean> temp = this.SaveAfter())
            {
                if (temp.MessageList != null && temp.MessageList.Count > 0)
                    retObj.MessageList.AddRange(temp.MessageList);
                retObj.Value &= temp.Value;
            }
            if (retObj.IsError()) retObj.Value = false;

            return retObj;
        }

        protected ReturnObject<Boolean> Create()
        {
            return this.start.Create();
        }

        protected ReturnObject<Boolean> Update()
        {
            return this.start.Update();
        }

        private ReturnObject<Boolean> DeleteInternal()
        {
            ReturnObject<Boolean> retObj;

            //Manage before hook
            retObj = this.DeleteBefore();
            if (retObj.IsError()) retObj.Value = false;
            if (retObj.Value == false) return retObj;
            //

            using (ReturnObject<Boolean> temp = this.start.Delete())
            {
                if (temp.MessageList != null && temp.MessageList.Count > 0)
                    retObj.MessageList.AddRange(temp.MessageList);
                retObj.Value &= temp.Value;
            }

            if (retObj.IsError()) retObj.Value = false;
            if (retObj.Value == false) return retObj;

            //Manage after hook
            using (ReturnObject<Boolean> temp = this.DeleteBefore())
            {
                if (temp.MessageList != null && temp.MessageList.Count > 0)
                    retObj.MessageList.AddRange(temp.MessageList);
                retObj.Value &= temp.Value;
            }
            if (retObj.IsError()) retObj.Value = false;

            return retObj;
        }

        protected ReturnObject<Boolean> Delete()
        {
            throw new NotImplementedException();
        }

        private ReturnObject<Data> Read()
        {
            throw new NotImplementedException();
        }

        private ReturnObject<List<Data>> ReatAll()
        {
            throw new NotImplementedException();
        }

        protected abstract ReturnObject<Boolean> SaveBefore();
        protected abstract ReturnObject<Boolean> SaveAfter();

        protected abstract ReturnObject<Boolean> DeleteBefore();
        protected abstract ReturnObject<Boolean> DeleteAfter();

        #region ICrud Members

        ReturnObject<bool> ICrud.Save()
        {
            return this.Save();
        }

        ReturnObject<bool> ICrud.Delete()
        {
            return this.DeleteInternal();
        }

        ReturnObject<Data> ICrud.Read()
        {
            return this.Read();
        }

        ReturnObject<List<Data>> ICrud.ReatAll()
        {
            return this.ReatAll();
        }

        #endregion

    }
}
