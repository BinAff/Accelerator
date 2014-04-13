
using System;
using System.Collections.Generic;

namespace Crystal.Lodge.Component.CheckInReport
{
    public class Server : Crystal.Report.Component.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "CheckInReport";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }
        
        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }
        
        public override List<BinAff.Core.Data> GetDailyReport(DateTime date)
        {
            return ((Dao)this.DataAccess).GetCheckInData(date, date);
        }

        public override List<BinAff.Core.Data> GetWeeklyReport(System.DateTime date)
        {
            DateTime firstDayOfWeek = this.GetPreviousMonday(date);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            return ((Dao)this.DataAccess).GetCheckInData(firstDayOfWeek, lastDayOfWeek);
        }

        public override List<BinAff.Core.Data> GetMonthlyReport(System.DateTime date)
        {
            DateTime firstDayOfMonth = this.GetFirstDayOfMonth(date);
            DateTime lastDayOfMonth = this.GetLastDayOfMonth(date);
            return ((Dao)this.DataAccess).GetCheckInData(firstDayOfMonth, lastDayOfMonth);
        }

        public override List<BinAff.Core.Data> GetQuarterlyReport(System.DateTime date)
        {          
            DateTime firstDayOfQuarter = new DateTime();
            DateTime lastDayOfQuarter = new DateTime();

            if (date.Month <= 3) //first quarter
            {
                firstDayOfQuarter = new DateTime(date.Year, 1, 1);
                lastDayOfQuarter = new DateTime(date.Year, 3, 31);
            }
            else if (date.Month <= 6) // Second Quarter
            {
                firstDayOfQuarter = new DateTime(date.Year, 4, 1);
                lastDayOfQuarter = new DateTime(date.Year, 6, 30);
            }
            else if (date.Month <= 9) // third Quarter
            {
                firstDayOfQuarter = new DateTime(date.Year, 7, 1);
                lastDayOfQuarter = new DateTime(date.Year, 9, 30);
            }
            else //last quarter
            {
                firstDayOfQuarter = new DateTime(date.Year, 10, 1);
                lastDayOfQuarter = new DateTime(date.Year, 12, 31);
            }

            return ((Dao)this.DataAccess).GetCheckInData(firstDayOfQuarter, lastDayOfQuarter);
        }

        public override List<BinAff.Core.Data> GetYearlyReport(System.DateTime date)
        {
            DateTime firstDayOfYear = new DateTime(date.Year, 1, 1);
            DateTime lastDayOfYear = new DateTime(date.Year, 12, 31);

            return ((Dao)this.DataAccess).GetCheckInData(firstDayOfYear, lastDayOfYear);
        }

        private DateTime GetPreviousMonday(DateTime dt)
        {
            var dateDayOfWeek = (int)dt.DayOfWeek;
            if (dateDayOfWeek == 0)
                dateDayOfWeek = dateDayOfWeek + 7;

            var alterNumber = dateDayOfWeek - ((dateDayOfWeek * 2) - 1);
            return dt.AddDays(alterNumber);
        }

        private DateTime GetFirstDayOfMonth(DateTime givenDate)
        {
            return new DateTime(givenDate.Year, givenDate.Month, 1);
        }

        private DateTime GetLastDayOfMonth(DateTime givenDate)
        {
            DateTime firstDayOfTheMonth = new DateTime(givenDate.Year, givenDate.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
    }
}
