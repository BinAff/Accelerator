using System;
using System.Windows.Forms;

using PresentationLibrary = BinAff.Presentation.Library;

namespace Vanilla.Invoice.WinForm.Report
{

    public partial class Daily : PresentationLibrary.Form
    {
        private Facade.Report.Dto dto;        
        private Facade.Report.FormDto formDto;

        public Daily()
        {
            InitializeComponent();

            dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //this.LoadData(DateTime.Today, DateTime.Today);
        }

        public Daily(Facade.Report.Dto dto)
        {
            InitializeComponent();

            dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dto = dto;
            this.formDto = new Facade.Report.FormDto { dto = this.dto };
            
        }



        //private void LoadData(DateTime startDate, DateTime endDate)
        //{
        //    List<Data> salesList = new List<Data>();
        //    Crystal.Invoice.Facade.IReport sales = new Crystal.Invoice.Facade.ReportServer();
        //    ReturnObject<List<Crystal.Invoice.Facade.Dto>> retVal = sales.GetList(startDate, endDate);

        //    if (retVal.Value != null)
        //    {
        //        List<Crystal.Invoice.Facade.Dto> salesDtoList = retVal.Value;

        //        foreach (Crystal.Invoice.Facade.Dto salesData in salesDtoList)
        //        {
        //            Data data = new Data()
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
        //                BuyerContactNo = salesData.BuyerContactNo
        //            };

        //            salesList.Add(data);
        //        }

        //        this.rvReport.Reset();
        //        this.rvReport.DocumentMapCollapsed = true;
        //        String path = System.IO.Directory.GetCurrentDirectory();
        //        path += @"\Report\Invoice Management System\Daily.rdlc";
        //        //path = path.Remove(path.IndexOf("Reference"));                
        //        //path += @"BinAff\Crystal Framework\Invoice Management System\Presentation\Report\Daily.rdlc";

        //        this.rvReport.LocalReport.ReportPath = path;               
        //        string sDataSourceName = "Sales";

        //        Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
        //        rptDataSoruce.Name = sDataSourceName;
        //        rptDataSoruce.Value = salesList;

        //        this.rvReport.Visible = true;
        //        this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
        //        this.rvReport.RefreshReport();
        //    }

        //}

        private void Daily_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    //LoadData(dpSearchDate.Value, dpSearchDate.Value);   
        //}

        //private void btnSearch_Click_1(object sender, EventArgs e)
        //{

        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.Report.Dto dto = this.dto as Facade.Report.Dto;
            dto.fromDate = dpSearchDate.Value.Date;
            dto.toDate = dpSearchDate.Value.Date;
            
            BinAff.Facade.Library.Server facade = new Facade.Report.Server(this.formDto);
            facade.Add();

            //this.dto.Id = this.formDto.dto.Id;

            if (facade.IsError)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
            }
            else
                this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }

}
