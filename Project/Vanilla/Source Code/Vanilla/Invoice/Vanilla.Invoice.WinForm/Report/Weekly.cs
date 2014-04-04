using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Invoice.WinForm.Report
{

    public partial class Weekly : Form
    {

        public Weekly()
        {
            InitializeComponent();

            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DateTime dtPrevMonday = GetPreviousMonday(DateTime.Today);
            //this.LoadData(dtPrevMonday);
        }

        private DateTime GetPreviousMonday(DateTime dt)
        {
            var dateDayOfWeek = (int)dt.DayOfWeek;
            if (dateDayOfWeek == 0)
                dateDayOfWeek = dateDayOfWeek + 7;

            var alterNumber = dateDayOfWeek - ((dateDayOfWeek * 2) - 1);
            return dt.AddDays(alterNumber);
        }

        //private void LoadData(DateTime PreviousMonday)
        //{
        //    DateTime startDate = PreviousMonday;
        //    DateTime endDate = DateTime.Today;

        //    if (Convert.ToDateTime(endDate).Subtract(Convert.ToDateTime(startDate)).Days > 6)
        //    {
        //        endDate = startDate.AddDays(6);
        //    }

        //    List<Data> salesList = new List<Data>();
        //    Crystal.Invoice.Facade.IReport sales = new Crystal.Invoice.Facade.ReportServer();
        //    ReturnObject<List<Crystal.Invoice.Facade.Dto>> retVal = sales.GetList(startDate, endDate);


        //    if (retVal.Value != null)
        //    {
        //        List<Crystal.Invoice.Facade.Dto> salesDtoList = retVal.Value;

        //        foreach (Crystal.Invoice.Facade.Dto salesData in salesDtoList)                
        //        {
        //            salesList.Add(new Data
        //            {
        //                InvoiceNumber = salesData.Id.ToString(),
        //                Date = salesData.Date.ToShortDateString(),
        //                SellerName = salesData.SellerName,
        //                SellerAddress = salesData.SellerAddress,
        //                SellerContactNo = salesData.SellerContactNo,
        //                SellerEmail = salesData.SellerEmail,
        //                SellerLicence = salesData.SellerLicence,
        //                BuyerName = salesData.BuyerName,
        //                BuyerAddress = salesData.BuyerAddress,
        //                BuyerContactNo = salesData.BuyerContactNo,                      
        //            });
        //        }

        //        this.rvReport.Reset();
        //        this.rvReport.DocumentMapCollapsed = true;
        //        String path = System.IO.Directory.GetCurrentDirectory();
        //        path += @"\Report\Invoice Management System\Weekly.rdlc";
        //        //path = path.Remove(path.IndexOf("Reference"));
        //        //path += @"BinAff\Crystal Framework\Invoice Management System\Presentation\Report\Weekly.rdlc";

        //        this.rvReport.LocalReport.ReportPath = path;
        //        string sDataSourceName = "Sales";

        //        ReportParameter[] p = new ReportParameter[1];
        //        p[0] = new ReportParameter("WeekRange", startDate.ToShortDateString() + " -- " + endDate.ToShortDateString());
        //        this.rvReport.LocalReport.SetParameters(p);

        //        Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
        //        rptDataSoruce.Name = sDataSourceName;
        //        rptDataSoruce.Value = salesList;

        //        this.rvReport.Visible = true;
        //        this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
        //        this.rvReport.RefreshReport();

        //    }

        //}

        private void Weekly_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtPrevMonday = GetPreviousMonday(this.dpSearchDate.Value);

            //if previous monday is less than today 
            //if (Convert.ToDateTime(dtPrevMonday).Subtract(Convert.ToDateTime(DateTime.Today)).Days <= 0)
            //    this.LoadData(dtPrevMonday);
        }

    }

}
