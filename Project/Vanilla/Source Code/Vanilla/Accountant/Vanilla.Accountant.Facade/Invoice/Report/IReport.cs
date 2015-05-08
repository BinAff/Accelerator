using System;
using System.Collections.Generic;

namespace Vanilla.Accountant.Facade.Invoice.Report
{

    public interface IReport
    {

        List<Facade.Invoice.Dto> GetDailyReport(DateTime date);
        List<Facade.Invoice.Dto> GetWeeklyReport(DateTime date);
        List<Facade.Invoice.Dto> GetMonthlyReport(DateTime date);
        List<Facade.Invoice.Dto> GetQuarterlyReport(DateTime date);
        List<Facade.Invoice.Dto> GetYearlyReport(DateTime date);

    }

}
