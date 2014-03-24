﻿
using System;
namespace Vanilla.Invoice.Facade.LineItem
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        //property below is used to display
        //public String startDate { get; set; }
        //public String endDate { get; set; }
        //public String description { get; set; }
        //public Double unitRate { get; set; }
        //public Int16 count { get; set; }
        //public Double total { get; set; }


        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String description { get; set; }
        public Double unitRate { get; set; }
        public Int16 count { get; set; }
        public Double total { get; set; }

        public Int64 roomCategoryId { get; set; }
        public Int64 roomTypeId { get; set; }
        public Boolean roomIsAC { get; set; }
    }
}
