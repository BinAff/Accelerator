﻿using System;
using System.Collections.Generic;

namespace BinAff.Core
{

    public class ReturnObject<T> : IDisposable
    {

        public T Value { get; set; }
        public List<Message> MessageList { get; set; }

        public Boolean HasError()
        {
            return (this.MessageList == null) ? false : this.MessageList.Exists((p) => p.Category == Message.Type.Error);
        }

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

    public class Message : IDisposable
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
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Description = null;
        }

        #endregion

    }

}
