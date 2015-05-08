using System;
using System.Collections.Generic;

namespace Vanilla.Accountant.Facade.Report
{
    public interface IReport
    {
        List<Facade.Dto> GetDailyReport(DateTime date);
        List<Facade.Dto> GetWeeklyReport(DateTime date);
        List<Facade.Dto> GetMonthlyReport(DateTime date);
        List<Facade.Dto> GetQuarterlyReport(DateTime date);
        List<Facade.Dto> GetYearlyReport(DateTime date);
    }
}
