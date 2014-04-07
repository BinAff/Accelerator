using System;
using System.Windows.Forms;

using PresentationLibrary = BinAff.Presentation.Library;
using System.Collections.Generic;

namespace Vanilla.Invoice.WinForm.Report
{

    public partial class Weekly : PresentationLibrary.Form
    {
        private Facade.Report.Dto dto;
        private Facade.Report.FormDto formDto;

        public enum ReportCategory
        {
            //Daily = 10001,
            Weekly = 10002,
            //Monthly = 3,
            //Quarterly = 4,
            //Yearly = 5
        }

        //public Weekly()
        //{
        //    InitializeComponent();

        //    this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        //    DateTime dtPrevMonday = GetPreviousMonday(DateTime.Today);
        //    //this.LoadData(dtPrevMonday);
        //}

        public Weekly(Facade.Report.Dto dto)
        {
            InitializeComponent();

            dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dto = dto;
            this.formDto = new Facade.Report.FormDto { dto = this.dto };

            //if (dto.Id > 0)
            //{
            //    dpSearchDate.Enabled = false;
            //    btnSave.Enabled = false;
            //    dpSearchDate.Value = (dto as Facade.Report.Dto).fromDate;
            //    this.LoadData(dpSearchDate.Value.Date, dpSearchDate.Value.Date);
            //}
            //else
            //    this.LoadData(DateTime.Today, DateTime.Today);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.Report.Dto dto = this.dto as Facade.Report.Dto;
            dto.fromDate = GetPreviousMonday(dpSearchDate.Value);
            dto.toDate = dto.fromDate.AddDays(6);
            dto.category = new Vanilla.Report.Facade.Category.Dto { Id = Convert.ToInt64(ReportCategory.Weekly) };

            //BinAff.Facade.Library.Server facade = new Facade.Report.Server(this.formDto);
            //facade.Add();

            //if (facade.IsError)
            //{
            //    new PresentationLibrary.MessageBox
            //    {
            //        DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
            //        Heading = "Splash",
            //    }.Show(facade.DisplayMessageList);
            //}
            //else
            //    this.Close();
        }        

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    DateTime dtPrevMonday = GetPreviousMonday(this.dpSearchDate.Value);

        //    //if previous monday is less than today 
        //    //if (Convert.ToDateTime(dtPrevMonday).Subtract(Convert.ToDateTime(DateTime.Today)).Days <= 0)
        //    //    this.LoadData(dtPrevMonday);
        //}

    }

}
