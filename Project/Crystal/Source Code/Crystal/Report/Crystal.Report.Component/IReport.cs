using System;
using System.Collections.Generic;

namespace Crystal.Report.Component
{
    public interface IReport
    {
        List<BinAff.Core.Data> GetReport(DateTime date);
        List<BinAff.Core.Data> GetDailyReport(DateTime date);
        List<BinAff.Core.Data> GetWeeklyReport(DateTime date);
        List<BinAff.Core.Data> GetMonthlyReport(DateTime date);
        List<BinAff.Core.Data> GetQuarterlyReport(DateTime date);
        List<BinAff.Core.Data> GetYearlyReport(DateTime date);
    }
}
