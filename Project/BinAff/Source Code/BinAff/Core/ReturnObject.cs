using System;
using System.Collections.Generic;

namespace BinAff.Core
{

    public sealed class ReturnObject<T> : IDisposable
    {

        public T Value { get; set; }

        public List<Message> MessageList { get; set; }

        public List<String> GetMessage(Message.Type type)
        {
            List<String> errorList = new List<string>();
            if (this.MessageList != null)
            {
                foreach (Message msg in this.MessageList)
                {
                    if (msg.Category == type)
                    {
                        errorList.Add(msg.Description);
                    }
                }
            }
            return errorList;
        }

        public Boolean HasError()
        {
            return (this.MessageList == null) ? false : this.MessageList.Exists((p) => p.Category == Message.Type.Error);
        }

        public ReturnObject<T1> Convert<T1>() where T1 : Data
        {
            return new ReturnObject<T1>
            {
                Value = this.Value as T1,
                MessageList = this.MessageList
            };
        }

        public ReturnObject<T> MergeMessageList<T1>(ReturnObject<T1> ret)
        {
            if (ret.MessageList == null) return this;
            if (this.MessageList == null) this.MessageList = new List<Message>();
            this.MessageList.AddRange(ret.MessageList);
            return this;
        }

        //protected ReturnObject<Boolean> ManipulateReturnObject(ReturnObject<Boolean> retObj, ReturnObject<Boolean> result)
        //{
        //    if (result.MessageList != null && result.MessageList.Count > 0)
        //    {
        //        if (retObj.MessageList == null) retObj.MessageList = new List<Message>();
        //        retObj.MessageList.AddRange(result.MessageList);
        //    }
        //    retObj.Value &= result.Value;
        //    if (retObj.HasError()) retObj.Value = false;
        //    return retObj;
        //}

        #region IDisposable Members

        public void Dispose()
        {
            if (this.MessageList != null)
            {
                for (Int16 i = 0; i < this.MessageList.Count; i++)
                {
                    this.MessageList[i].Dispose();
                    this.MessageList[i] = null;
                }
            }
            this.MessageList = null;
        }

        #endregion

    }

    public sealed class Message : IDisposable
    {

        public String Description { get; set; }
        public Type Category { get; set; }

        public Message()
        {

        }

        public Message(String description, Type type)
        {
            this.Description = description;
            this.Category = type;
        }

        public enum Type
        {
            Information = 1,
            Error = 2,
            Question = 3,
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Description = null;
        }

        #endregion

    }

}