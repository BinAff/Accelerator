using System;

namespace Crystal.Guardian.Component.Role
{

    public class Data : BinAff.Core.Data
    {

        public String Name { get; set; }
        public String Description { get; set; }
        public Right.Data Right { get; set; }

    }

}
