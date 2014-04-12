using System;
using System.Windows.Forms;
using System.Collections.Generic;

using PresentationLibrary = BinAff.Presentation.Library;
using FacadeReport = Vanilla.Invoice.Facade.Report;

namespace Vanilla.Invoice.WinForm.Report
{

    public partial class Daily : PresentationLibrary.Form
    {
        private Facade.Report.Dto dto;        
        private Facade.Report.FormDto formDto;

        public enum ReportCategory
        {
            Daily = 10001
        }       

        public Daily(Facade.Report.Dto dto)
        {
            InitializeComponent();

            dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dto = dto;
            this.formDto = new Facade.Report.FormDto { dto = this.dto };

            if (dto.Id > 0)
            {
                dpSearchDate.Enabled = false;
                btnSave.Enabled = false;
                dpSearchDate.Value = dto.date;
                this.LoadData(dpSearchDate.Value.Date);
            }
            else
                this.LoadData(DateTime.Today);
        }
        
        private void LoadData(DateTime date)
        {
            FacadeReport.IReport report = new FacadeReport.Server(null);
            List<Facade.Dto> invoiceList = report.GetDailyReport(date);

            this.rvReport.Reset();
            List<Data> salesList = new List<Data>();
            if (invoiceList != null && invoiceList.Count > 0)
            {
                foreach (Facade.Dto invoiceData in invoiceList)
                {
                    salesList.Add(new Data
                    {
                        InvoiceNumber = invoiceData.invoiceNumber,
                        Date = invoiceData.date.ToShortDateString(),
                        SellerName = invoiceData.seller.Name,
                        SellerAddress = invoiceData.seller.Address,
                        SellerContactNo = invoiceData.seller.ContactNumber,
                        SellerEmail = invoiceData.seller.Email,
                        SellerLicence = invoiceData.seller.Liscence,
                        BuyerName = invoiceData.buyer.Name,
                        BuyerAddress = invoiceData.buyer.Address,
                        BuyerContactNo = invoiceData.buyer.ContactNumber
                    });
                }

                //this.rvReport.Reset();
                this.rvReport.DocumentMapCollapsed = true;
                String path = System.IO.Directory.GetCurrentDirectory();
                path = path.Remove(path.IndexOf("AutoTourism"));
                path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Report\Daily.rdlc";
               

                this.rvReport.LocalReport.ReportPath = path;               
                string sDataSourceName = "Sales";

                Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
                rptDataSoruce.Name = sDataSourceName;
                rptDataSoruce.Value = salesList;

                this.rvReport.Visible = true;
                this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
                this.rvReport.RefreshReport();
            }

        }

        private void Daily_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.Report.Dto dto = this.dto as Facade.Report.Dto;           
            dto.date = dpSearchDate.Value.Date;
            dto.category = new Vanilla.Report.Facade.Category.Dto { Id = Convert.ToInt64(ReportCategory.Daily) };
            
            BinAff.Facade.Library.Server facade = new Facade.Report.Server(this.formDto);
            facade.Add();

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
     
        private void dpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData(dpSearchDate.Value.Date);
        }

    }

}
