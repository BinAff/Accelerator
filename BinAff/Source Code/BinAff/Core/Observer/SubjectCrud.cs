using System;
using System.Collections.Generic;

namespace BinAff.Core.Observer
{

    public abstract class SubjectCrud : Crud, ISubject
    {

        private List<ObserverCrud> observers;

        public SubjectCrud(Data data)
            : base(data)
        {
            this.observers = new List<ObserverCrud>();
        }

        #region ISubject

        void ISubject.RegisterObserver(ObserverCrud o)
        {
            this.observers.Add(o);
        }

        void ISubject.RemoveObserver(ObserverCrud o)
        {
            this.observers.Remove(o);
        }

        ReturnObject<Boolean> ISubject.NotifyObserver()
        {
            return NotifyObserver();
        }

        #endregion

        private ReturnObject<Boolean> NotifyObserver()
        {
            ReturnObject<Boolean> notification = new ReturnObject<Boolean>
            {
                Value = true,
                MessageList = new List<Message>()
            };
            foreach (ObserverCrud o in this.observers)
            {
                IObserver observer = o;
                base.ManipulateReturnObject(notification, observer.Update(this.Data));
            }

            return notification;
        }

        /// <summary>
        /// Override delete for observers activity
        /// </summary>
        /// <returns></returns>
        protected override ReturnObject<Boolean> Delete()
        {
            ReturnObject<Boolean> notification = NotifyObserver();
            if (notification.HasError()) return notification;
            return base.Delete();
        }

    }

}
