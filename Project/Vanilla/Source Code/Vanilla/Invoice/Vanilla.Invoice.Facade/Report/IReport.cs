using System;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Report
{
    public interface IReport
    {
        List<Facade.Dto> GetDailyReport(DateTime date);
    }
}
