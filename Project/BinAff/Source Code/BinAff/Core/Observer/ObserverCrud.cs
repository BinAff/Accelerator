using System;

namespace BinAff.Core.Observer
{

    public abstract class ObserverCrud : Crud, IObserver
    {
        
        public ObserverCrud(Data data)
            : base(data)
        {
            
        }

        ReturnObject<Boolean> IObserver.Update(Data subject)
        {
            return IsSubjectDeletable(subject);
        }

        protected abstract ReturnObject<Boolean> IsSubjectDeletable(Data subject); 

    }

}
