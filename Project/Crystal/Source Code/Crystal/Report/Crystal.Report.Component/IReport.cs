using System;
using System.Collections.Generic;

namespace Crystal.Report.Component
{

    public interface IReport
    {

        List<BinAff.Core.Data> GetReport(DateTime date);
        String GetReportName();

    }

}
