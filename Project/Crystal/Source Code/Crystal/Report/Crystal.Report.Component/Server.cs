using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystal.Report.Component
{
    public abstract class Server : BinAff.Core.Crud, IReport
    {
        public Server(Data data)
            : base(data)
        {

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

        public abstract List<BinAff.Core.Data> GetDailyReport(DateTime date);
        public abstract List<BinAff.Core.Data> GetWeeklyReport(DateTime date);
        public abstract List<BinAff.Core.Data> GetMonthlyReport(DateTime date);
        public abstract List<BinAff.Core.Data> GetQuarterlyReport(DateTime date);
        public abstract List<BinAff.Core.Data> GetYearlyReport(DateTime date);
        
    }
}
