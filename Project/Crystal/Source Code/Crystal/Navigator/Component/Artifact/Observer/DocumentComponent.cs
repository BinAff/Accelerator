using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Navigator.Component.Artifact.Observer
{

    public abstract class DocumentComponent : ObserverSubjectCrud, ISubject
    {

        private List<Artifact.Server> observers;

        public DocumentComponent(BinAff.Core.Data data)
            : base(data)
        {
            this.observers = new List<Artifact.Server>();
        }

        #region ISubject

        void ISubject.RegisterObserver(Artifact.Server artf)
        {
            this.observers.Add(artf);
        }

        void ISubject.RemoveObserver(Artifact.Server artf)
        {
            this.observers.Remove(artf);
        }

        ReturnObject<Boolean> ISubject.NotifyObserverForCreate()
        {
            return this.NotifyObserverForCreate();
        }

        ReturnObject<Boolean> ISubject.NotifyObserverForUpdate()
        {
            return this.NotifyObserverForUpdate();
        }

        #endregion

        private ReturnObject<Boolean> NotifyObserverForCreate()
        {
            ReturnObject<Boolean> notification = new ReturnObject<Boolean>
            {
                Value = true,
                MessageList = new List<Message>()
            };
            foreach (Artifact.Server o in this.observers)
            {
                IObserver observer = o;
                base.ManipulateReturnObject(notification, observer.UpdateArtifactComponentLink(this.Data as Data));
            }

            return notification;
        }

        private ReturnObject<Boolean> NotifyObserverForUpdate()
        {
            ReturnObject<Boolean> notification = new ReturnObject<Boolean>
            {
                Value = true,
                MessageList = new List<Message>()
            };
            foreach (Artifact.Server o in this.observers)
            {
                IObserver observer = o;
                base.ManipulateReturnObject(notification, observer.UpdateAfterComponentUpdate(this.Data as Data));
            }

            return notification;
        }

        /// <summary>
        /// Override create for observers activity
        /// </summary>
        /// <returns></returns>
        protected override ReturnObject<Boolean> Create()
        {
            ReturnObject<Boolean> notification = base.Create();
            if (notification.HasError()) return notification;
            return this.NotifyObserverForCreate();
        }

        /// <summary>
        /// Override delete for observers activity
        /// </summary>
        /// <returns></returns>
        protected override ReturnObject<Boolean> Update()
        {
            ReturnObject<Boolean> notification = this.NotifyObserverForUpdate();
            if (notification.HasError()) return notification;
            return base.Update();
        }

    }

}
