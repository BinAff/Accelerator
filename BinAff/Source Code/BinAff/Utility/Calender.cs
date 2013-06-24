namespace BinAff.Utility
{

    public class Calender
    {

        private System.DateTime GetFirstDayOfMonth(System.DateTime date)
        {
            return new System.DateTime(date.Year, date.Month, 1);
        }

    }

}
