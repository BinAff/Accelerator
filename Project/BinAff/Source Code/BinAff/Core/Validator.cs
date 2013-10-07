using System;
using System.Collections.Generic;

using BinAff.Utility;

namespace BinAff.Core
{
   
    public abstract class Validator : IValidator
    {

        public Data Data { get; set; }
        public Data ParentData { get; set; }
        public List<Validator> Children { get; set; }
        /// <summary>
        /// Server attached with data access component
        /// </summary>
        public BinAff.Core.Crud Server { get; set; }

        public Validator(Data data)
        {
            this.Data = data;
            this.Children = new List<Validator>();
        }

        protected abstract List<Message> Validate();

        internal virtual ReturnObject<Boolean> IsDeletable()
        {
            return new ReturnObject<Boolean> { Value = true };
        }

        #region IValidator Members

        List<Message> IValidator.Validate()
        {
            return this.ValidateAll();
        }

        #endregion

        /// <summary>
        /// Validate identifier
        /// </summary>
        /// <returns></returns>
        public List<Message> IsValidId()
        {
            if (ValidationRule.IsPositive(this.Data.Id))
                return null;

            //Id is not valid
            List<Message> retMsgList = new List<Message>();
            retMsgList.Add(new Message
            {
                Category = Message.Type.Error,
                Description = "Invalid unique identifier"
            }
            );
            return retMsgList;
        }

        /// <summary>
        /// Validate data and associate data
        /// </summary>
        /// <returns></returns>
        private List<Message> ValidateAll()
        {
            List<Message> msgList = new List<Message>();

            if (this.Data == null)
            {
                msgList.Add(new Message("Data cannot be empty", Message.Type.Error));
                return msgList;
            }

            //if (!this.validateOnlyChildren)
                msgList = this.Validate(); //Validate own data

            if (this.Children != null) //Validating Children
            {
                foreach (Validator val in this.Children)
                {
                    if (val != null)
                    {
                        msgList.AddRange(val.Validate());
                    }
                }
            }
            return msgList;
        }

    }

}
