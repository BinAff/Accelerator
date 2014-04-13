using System;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Report
{
    public interface IReport
    {
        List<Facade.Report.Dto> GetDailyReport(DateTime date);
        List<Facade.Report.Dto> GetWeeklyReport(DateTime date);
        List<Facade.Report.Dto> GetMonthlyReport(DateTime date);
        List<Facade.Report.Dto> GetQuarterlyReport(DateTime date);
        List<Facade.Report.Dto> GetYearlyReport(DateTime date);
    }
}
