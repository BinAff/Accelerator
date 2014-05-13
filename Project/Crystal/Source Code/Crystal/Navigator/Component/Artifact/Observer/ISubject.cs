using System;

using BinAff.Core;

namespace Crystal.Navigator.Component.Artifact.Observer
{

    public interface ISubject : BinAff.Core.Observer.ISubject
    {

        /// <summary>
        /// Register new observer
        /// </summary>
        /// <param name="o">Observer</param>
        void RegisterObserver(Artifact.Server o);

        /// <summary>
        /// Remove existing observer
        /// </summary>
        /// <param name="o">Observer</param>
        void RemoveObserver(Artifact.Server o);

        /// <summary>
        /// Notify observers when module is getting created
        /// </summary>
        ReturnObject<Boolean> NotifyObserverForCreate();

        /// <summary>
        /// Notify observers when module is getting updated
        /// </summary>
        ReturnObject<Boolean> NotifyObserverForUpdate();

    }

}
