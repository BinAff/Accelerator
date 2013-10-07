using System;

namespace BinAff.Core.Observer
{

    public interface ISubject
    {

        /// <summary>
        /// Register new observer
        /// </summary>
        /// <param name="o">Observer</param>
        void RegisterObserver(ObserverCrud o);

        /// <summary>
        /// Remove existing observer
        /// </summary>
        /// <param name="o">Observer</param>
        void RemoveObserver(ObserverCrud o);

        /// <summary>
        /// Notify observers
        /// </summary>
        ReturnObject<Boolean> NotifyObserver();

    }

}
