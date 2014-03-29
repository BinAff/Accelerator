using System;
namespace BinAff.Utility
{

    public class Calender
    {

        private System.DateTime GetFirstDayOfMonth(System.DateTime date)
        {
            return new System.DateTime(date.Year, date.Month, 1);
        }

        public int DaysBetweenTwoDays(DateTime fromDate, DateTime toDate)
        {
            return (toDate.Date - fromDate.Date).Days;
        }

    }

}
