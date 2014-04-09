
using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component.Report
{
    public class Server : Crystal.Report.Component.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Report";
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
            return ((Dao)this.DataAccess).GetSalesData(date, date);
        }

        public override List<BinAff.Core.Data> GetWeeklyReport(System.DateTime date)
        {
            DateTime firstDayOfWeek = this.GetPreviousMonday(date);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            return ((Dao)this.DataAccess).GetSalesData(firstDayOfWeek, lastDayOfWeek);
        }

        public override List<BinAff.Core.Data> GetMonthlyReport(System.DateTime date)
        {
            DateTime firstDayOfMonth = this.GetFirstDayOfMonth(date);
            DateTime lastDayOfMonth = this.GetLastDayOfMonth(date);
            return ((Dao)this.DataAccess).GetSalesData(firstDayOfMonth, lastDayOfMonth);
        }

        public override List<BinAff.Core.Data> GetQuarterlyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public override List<BinAff.Core.Data> GetYearlyReport(System.DateTime date)
        {
            throw new System.NotImplementedException();
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
