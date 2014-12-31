using System;

namespace BinAff.Core
{

    public class Table
    {

        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Double Value { get; set; }

        public Table Clone()
        {
            return this.MemberwiseClone() as Table;
        }

    }

}
