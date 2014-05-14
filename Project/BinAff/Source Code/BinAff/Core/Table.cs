using System;

namespace BinAff.Core
{

    public class Table : ICloneable
    {

        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Double Value { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

}
