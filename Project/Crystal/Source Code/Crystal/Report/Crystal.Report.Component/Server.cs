using System;
using System.Collections.Generic;

namespace Crystal.Report.Component
{

    public abstract class Server : BinAff.Core.Crud, IReport
    {

        public Server(Data data)
            : base(data)
        {

        }

        List<BinAff.Core.Data> IReport.GetReport(DateTime date)
        {
            Data data = this.Data as Data;
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.IndexOf("AutoTourism"));
            path += @"AutoTourism\Source Code\AutoTourism\Customer\AutoTourism.Customer.WinForm\Report\";
            switch ((this.Data as Data).Category.Id)
            {
                case 10001:
                    data.Path = path + "Daily.rdlc";
                    return this.GetDailyReport(date);
                case 10002:
                    data.Path = path + "Weekly.rdlc";
                    return this.GetWeeklyReport(date);
                case 10003:
                    data.Path = path + "Monthly.rdlc";
                    return this.GetMonthlyReport(date);
                case 10004:
                    data.Path = path + "Quarterly.rdlc";
                    return this.GetQuarterlyReport(date);
                case 10005:
                    data.Path = path + "Yearly.rdlc";
                    return this.GetYearlyReport(date);
            }
            return new List<BinAff.Core.Data>();
        }

        List<BinAff.Core.Data> IReport.GetDailyReport(DateTime date)
        {
            return this.GetDailyReport(date);
        }

        List<BinAff.Core.Data> IReport.GetWeeklyReport(DateTime date)
        {
            return this.GetWeeklyReport(date);
        }

        List<BinAff.Core.Data> IReport.GetMonthlyReport(DateTime date)
        {
            return this.GetMonthlyReport(date);
        }

        List<BinAff.Core.Data> IReport.GetQuarterlyReport(DateTime date)
        {
            return this.GetQuarterlyReport(date);
        }

        List<BinAff.Core.Data> IReport.GetYearlyReport(DateTime date)
        {
            return this.GetYearlyReport(date);
        }

        public List<BinAff.Core.Data> GetDailyReport(DateTime date)
        {
            return ((Dao)this.DataAccess).GetData(date, date);
        }

        public List<BinAff.Core.Data> GetWeeklyReport(System.DateTime date)
        {
            DateTime firstDayOfWeek = this.GetPreviousMonday(date);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            return ((Dao)this.DataAccess).GetData(firstDayOfWeek, lastDayOfWeek);
        }

        public List<BinAff.Core.Data> GetMonthlyReport(System.DateTime date)
        {
            DateTime firstDayOfMonth = this.GetFirstDayOfMonth(date);
            DateTime lastDayOfMonth = this.GetLastDayOfMonth(date);
            return ((Dao)this.DataAccess).GetData(firstDayOfMonth, lastDayOfMonth);
        }

        public List<BinAff.Core.Data> GetQuarterlyReport(System.DateTime date)
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

            return ((Dao)this.DataAccess).GetData(firstDayOfQuarter, lastDayOfQuarter);
        }

        public List<BinAff.Core.Data> GetYearlyReport(System.DateTime date)
        {
            DateTime firstDayOfYear = new DateTime(date.Year, 1, 1);
            DateTime lastDayOfYear = new DateTime(date.Year, 12, 31);

            return ((Dao)this.DataAccess).GetData(firstDayOfYear, lastDayOfYear);
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
