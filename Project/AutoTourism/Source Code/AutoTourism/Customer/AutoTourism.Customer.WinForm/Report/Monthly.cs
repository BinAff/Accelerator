using System;
using System.Collections.Generic;

using FacadeReport = AutoTourism.Customer.Facade.Report;
using PresentationLibrary = BinAff.Presentation.Library;
using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Customer.WinForm.Report
{

    public partial class Monthly : Vanilla.Report.WinForm.Document
    {

        public Monthly()
            : base()
        {

        }

        public Monthly(Facade.Report.Dto dto)
            : base(dto)
        {

        }

    }

}
