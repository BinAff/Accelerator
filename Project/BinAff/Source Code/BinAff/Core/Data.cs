using System;

namespace BinAff.Core
{

    public class Data
    {

        public Int64 Id { get; set; }
        public Boolean IsDeletable { get; set; }

        public virtual Data Clone()
        {
            return this.MemberwiseClone() as Data;
        }

    }

}