using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
//using Crystal.Invoice.Facade;
//using BinAff.Core;
//using BinAff.Utility;

using System.IO;
using System.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;

using Facade = Vanilla.Invoice.Facade;

namespace Vanilla.Invoice.WinForm
{
    public partial class Invoice : Form
    {
        private IList<Stream> m_streams;
        private int m_currentPageIndex;


        //private Crystal.Invoice.Component.Data invoiceData;
       
        public Invoice(System.Windows.Forms.TreeView trvForm)
        {
            InitializeComponent();
            //this.invoiceData = data;
            //LoadReport();
            //LoadFormData();

            //if (this.invoiceData.Payment == null || ValidationRule.IsMinimumDate(this.invoiceData.Payment.Date))
            //    btnPrint.Visible = false;
            //else
            //{
            //    btnPayAndPrint.Visible = false;
            //    this.cboPaymentType.Enabled = false;
            //    this.txtLastFourDigit.Enabled = false;
            //    this.txtRemark.Enabled = false;
            //}

        }

        public Invoice(Facade.Dto dto)
        {
            InitializeComponent();
           

        }

        private void LoadReport()
        {
            //List<Data> invoiceList = new List<Data>();
            //foreach (Crystal.Invoice.Component.LineItem lineItem in invoiceData.LineItem)
            //{
            //    invoiceList.Add(new Data
            //    {
            //        Start = lineItem.Start.ToShortDateString(),
            //        End = lineItem.End.ToShortDateString(),
            //        Description = lineItem.Description,
            //        UnitRate = lineItem.UnitRate.ToString(),
            //        Count = lineItem.Count.ToString(),
            //        Total = Convert.ToString(lineItem.UnitRate * lineItem.Count * Convert.ToDateTime(lineItem.End).Subtract(Convert.ToDateTime(lineItem.Start)).Days)
                                        
            //    });                
            //}
          
            //this.rvInvoice.DocumentMapCollapsed = true;
            //this.rvInvoice.ShowPrintButton = false;
            //String path = System.IO.Directory.GetCurrentDirectory();
            ////path = path.Remove(path.IndexOf("Reference"));
            ////path += @"BinAff\Crystal Framework\Invoice Management System\Presentation\Invoice.rdlc";
            //path += @"\Report\Invoice Management System\Invoice.rdlc";

            //this.rvInvoice.LocalReport.ReportPath = path;
            //string sDataSourceName = "Invoice";

            //ReportParameter[] p = new ReportParameter[13];
            //p[0] = new ReportParameter("InvoiceNumber", this.invoiceData.Id.ToString());
            //p[1] = new ReportParameter("SellerName", this.invoiceData.Seller.Name);
            //p[2] = new ReportParameter("SellerAddress", this.invoiceData.Seller.Address);
            //p[3] = new ReportParameter("SellerContactNo", this.invoiceData.Seller.ContactNumber);
            //p[4] = new ReportParameter("SellerEmail", this.invoiceData.Seller.Email);
            //p[5] = new ReportParameter("SellerLicenceNo", this.invoiceData.Seller.Liscence);
            //p[6] = new ReportParameter("BuyerName", this.invoiceData.Buyer.Name);
            //p[7] = new ReportParameter("BuyerContactNo", this.invoiceData.Buyer.ContactNumber);
            //p[8] = new ReportParameter("BuyerAddress", this.invoiceData.Buyer.Address);
            //p[9] = new ReportParameter("Total", "1000"); //Change
            //p[10] = new ReportParameter("Discount", "1000"); //Change
            //p[11] = new ReportParameter("Tax", "4"); //Change
            //p[12] = new ReportParameter("Advance", "1000"); //Change
            
            //this.rvInvoice.LocalReport.SetParameters(p);

            //Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
            //rptDataSoruce.Name = sDataSourceName;
            //rptDataSoruce.Value = invoiceList;

            //this.rvInvoice.Visible = true;
            //this.rvInvoice.LocalReport.DataSources.Add(rptDataSoruce);
            //this.rvInvoice.RefreshReport();
                        
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'DevelopmentRNDDataSet.Invoice' table. You can move, or remove it, as needed.
            //this.InvoiceTableAdapter.Fill(this.DevelopmentRNDDataSet.Invoice);
            //// TODO: This line of code loads data into the 'DevelopmentRNDDataSet.InvoiceLineItem' table. You can move, or remove it, as needed.
            //this.InvoiceLineItemTableAdapter.Fill(this.DevelopmentRNDDataSet.InvoiceLineItem);

            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.rvInvoice.RefreshReport();
        }

        private void LoadFormData()
        {
            //IReport payment = new ReportServer();
            //ReturnObject<PaymentDto> ret = payment.LoadForm();

            ////Populate Floor List
            //this.cboPaymentType.DataSource = ret.Value.PaymentTypeList;
            //this.cboPaymentType.DisplayMember = "Name";
            //this.cboPaymentType.ValueMember = "Id";

            //if (this.invoiceData.Payment != null)
            //{
            //    //select payment type
            //    for (int i = 0; i < ret.Value.PaymentTypeList.Count; i++)
            //    {
            //        if (ret.Value.PaymentTypeList[i].Id == this.invoiceData.Payment.Type.Id)
            //        {
            //            this.cboPaymentType.SelectedIndex = i;
            //            break;
            //        }
            //    }

            //    this.txtLastFourDigit.Text = this.invoiceData.Payment.CardNumber;
            //    this.txtRemark.Text = this.invoiceData.Payment.Remark;
            //}
          
        }

        private void btnPayAndPrint_Click(object sender, EventArgs e)
        {
            //this.invoiceData.Payment = new Component.Payment.Data()
            //{
            //    Type = new Component.Payment.Type.Data() {
            //        Id = ((PaymentTypeDto)this.cboPaymentType.SelectedItem).Id
            //    },
            //    CardNumber = this.txtLastFourDigit.Text.Trim(),
            //    Remark = this.txtRemark.Text.Trim()
            //};

            //Crystal.Invoice.Facade.IReport report = new Crystal.Invoice.Facade.ReportServer();
            //ReturnObject<Boolean> ret = report.SavePayment(this.invoiceData);

            //if (!ret.HasError())
            //{ 
            //    //Print the report
            //    PrintInvoice(this.invoiceData);
            //}  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintInvoice(this.invoiceData);
        }

        //private void PrintInvoice(Crystal.Invoice.Component.Data invoiceData)
        //{
        //    return;
        //    LocalReport report = new LocalReport();

        //    String path = System.IO.Directory.GetCurrentDirectory();
        //    path = path.Remove(path.IndexOf("Reference"));
        //    path += @"BinAff\Crystal Framework\Invoice Management System\Presentation\Invoice.rdlc";


        //    report.ReportPath = path;

        //    string sDataSourceName = "Invoice";
        //    Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
        //    rptDataSoruce.Name = sDataSourceName;
        //    rptDataSoruce.Value = LoadSalesData();

        //    //report.DataSources.Add(
        //    //   new ReportDataSource("Sales", LoadSalesData()));
        //    report.DataSources.Add(rptDataSoruce);

        //    Export(report);
        //    Print();

        //}

        //private List<Data> LoadSalesData()
        //{
        //    List<Data> invoiceList = new List<Data>();
        //    foreach (Crystal.Invoice.Component.LineItem lineItem in invoiceData.LineItem)
        //    {
        //        invoiceList.Add(new Data
        //        {
        //            Start = lineItem.Start.ToShortDateString(),
        //            End = lineItem.End.ToShortDateString(),
        //            Description = lineItem.Description,
        //            UnitRate = lineItem.UnitRate.ToString(),
        //            Count = lineItem.Count.ToString(),
        //            Total = Convert.ToString(lineItem.UnitRate * lineItem.Count * Convert.ToDateTime(lineItem.End).Subtract(Convert.ToDateTime(lineItem.Start)).Days)

        //        });
        //    }
        //    return invoiceList;
        //}

//        // Export the given report as an EMF (Enhanced Metafile) file.
//        private void Export(LocalReport report)
//        {
//            string deviceInfo =
//              @"<DeviceInfo>
//                <OutputFormat>EMF</OutputFormat>
//                <PageWidth>8.5in</PageWidth>
//                <PageHeight>11in</PageHeight>
//                <MarginTop>0.25in</MarginTop>
//                <MarginLeft>0.25in</MarginLeft>
//                <MarginRight>0.25in</MarginRight>
//                <MarginBottom>0.25in</MarginBottom>
//            </DeviceInfo>";

//            Warning[] warnings;
//            m_streams = new List<Stream>();
//            report.Render("Image", deviceInfo, CreateStream, out warnings);
//            foreach (Stream stream in m_streams)
//                stream.Position = 0;
//        }

        // Routine to provide to the report renderer, in order to
        // save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }


    }
}
