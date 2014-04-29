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
            switch ((this.Data as Data).Category.Id)
            {
                case 10001:
                    data.Path = "Daily.rdlc";
                    return this.GetDailyReport(date);
                case 10002:
                    data.Path = "Weekly.rdlc";
                    return this.GetWeeklyReport(date);
                case 10003:
                    data.Path = "Monthly.rdlc";
                    return this.GetMonthlyReport(date);
                case 10004:
                    data.Path = "Quarterly.rdlc";
                    return this.GetQuarterlyReport(date);
                case 10005:
                    data.Path = "Yearly.rdlc";
                    return this.GetYearlyReport(date);
            }
            return new List<BinAff.Core.Data>();
        }

        String IReport.GetReportName()
        {
            switch ((this.Data as Data).Category.Id)
            {
                case 10001:
                    return "Daily.rdlc";
                case 10002:
                    return "Weekly.rdlc";
                case 10003:
                    return "Monthly.rdlc";
                case 10004:
                    return "Quarterly.rdlc";
                case 10005:
                    return "Yearly.rdlc";
                default:
                    return String.Empty;
            }
        }

        Data IReport.SetStartEnd()
        {
            Data data = this.Data as Data;
            switch ((this.Data as Data).Category.Id)
            {
                case 10001:
                    data.Start = data.Date;
                    data.End = data.Date;
                    break;
                case 10002:
                    data.Start = this.GetPreviousMonday(data.Date);
                    data.End = data.Start.AddDays(6);
                    break;
                case 10003:
                    data.Start = this.GetFirstDayOfMonth(data.Date);
                    data.End = this.GetLastDayOfMonth(data.Date);
                    break;
                case 10004:
                    data.Start = this.GetFirstDayOfQuarter(data.Date);
                    data.End = this.GetLastDayOfQuarter(data.Date);
                    break;
                case 10005:
                    data.Start = new DateTime(data.Date.Year, 1, 1);
                    data.End = new DateTime(data.Date.Year, 12, 31);
                    break;
                default:
                    data.Start = data.Date;
                    data.End = data.Date;
                    break;
            }

            return data;
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
            DateTime firstDayOfQuarter = this.GetFirstDayOfQuarter(date);
            DateTime lastDayOfQuarter = this.GetLastDayOfQuarter(date);
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

        private DateTime GetFirstDayOfQuarter(DateTime givenDate)
        {
            DateTime firstDayOfQuarter = new DateTime();
            if (givenDate.Month <= 3) //first quarter
            {
                firstDayOfQuarter = new DateTime(givenDate.Year, 1, 1);
            }
            else if (givenDate.Month <= 6) // Second Quarter
            {
                firstDayOfQuarter = new DateTime(givenDate.Year, 4, 1);
            }
            else if (givenDate.Month <= 9) // third Quarter
            {
                firstDayOfQuarter = new DateTime(givenDate.Year, 7, 1);
            }
            else //last quarter
            {
                firstDayOfQuarter = new DateTime(givenDate.Year, 10, 1);
            }

            return firstDayOfQuarter;
        }

        private DateTime GetLastDayOfQuarter(DateTime givenDate)
        {
            DateTime lastDayOfQuarter = new DateTime();
            if (givenDate.Month <= 3) //first quarter
            {
                lastDayOfQuarter = new DateTime(givenDate.Year, 3, 31);
            }
            else if (givenDate.Month <= 6) // Second Quarter
            {
                lastDayOfQuarter = new DateTime(givenDate.Year, 6, 30);
            }
            else if (givenDate.Month <= 9) // third Quarter
            {
                lastDayOfQuarter = new DateTime(givenDate.Year, 9, 30);
            }
            else //last quarter
            {
                lastDayOfQuarter = new DateTime(givenDate.Year, 12, 31);
            }

            return lastDayOfQuarter;
        }

    }

}
