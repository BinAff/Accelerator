using System;
using System.Windows.Forms;
using System.Collections.Generic;

using PresentationLibrary = BinAff.Presentation.Library;
using FacadeReport = AutoTourism.Customer.Facade.Report;
using UtilityReport = Vanilla.Utility.Facade.Report;

namespace AutoTourism.Customer.WinForm.Report
{
    public partial class Quarterly : PresentationLibrary.Form
    {
        private Facade.Report.Dto dto;
        private Facade.Report.FormDto formDto;

        public enum ReportCategory
        {
            Quarterly = 10004
        }

        public Quarterly(Facade.Report.Dto dto)
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
            UtilityReport.IReport report = new FacadeReport.Server(null);
            List<UtilityReport.Dto> customerDataList = report.GetQuarterlyReport(date);

            this.rvReport.Reset();
            List<Data> customerList = new List<Data>();
            if (customerDataList != null && customerDataList.Count > 0)
            {
                foreach (FacadeReport.Dto customerData in customerDataList)
                {
                    customerList.Add(new Data
                    {
                        Group = customerData.Id.ToString(),
                        CheckInDate = customerData.CheckInDate.ToShortDateString(),
                        CheckOutDate = customerData.CheckInStatusId == 10001 ? String.Empty : customerData.CheckInDate.AddDays(customerData.NoOfDays).ToShortDateString(),
                        InvoiceNumber = customerData.InvoiceNumber,
                        BookingFrom = customerData.BookingFrom.ToShortDateString(),
                        NoOfDays = customerData.NoOfDays.ToString(),
                        NoOfPersons = customerData.NoOfPersons.ToString(),
                        NoOfRooms = customerData.NoOfRooms.ToString(),
                        Description = customerData.Description,
                        Advance = customerData.Advance.ToString(),

                        Name = GetCustomerDisplayName(customerData),
                        Address = customerData.Address,
                        State = customerData.State,
                        City = customerData.City,
                        Pin = customerData.Pin.ToString(),
                        Email = customerData.Email,
                        IdentityProofType = customerData.IdentityProofType,
                        IdentityProofName = customerData.IdentityProofName,
                        ContactNumber = customerData.ContactNumber
                    });
                }


                this.rvReport.DocumentMapCollapsed = true;
                String path = System.IO.Directory.GetCurrentDirectory();
                path = path.Remove(path.IndexOf("AutoTourism"));
                path += @"AutoTourism\Source Code\AutoTourism\Customer\AutoTourism.Customer.WinForm\Report\Quarterly.rdlc";

                this.rvReport.LocalReport.ReportPath = path;
                string sDataSourceName = "Customer";

                Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
                rptDataSoruce.Name = sDataSourceName;
                rptDataSoruce.Value = customerList;

                this.rvReport.Visible = true;
                this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
                this.rvReport.RefreshReport();
            }
        }

        private String GetCustomerDisplayName(FacadeReport.Dto customer)
        {
            String Name = customer.Initial == null ? String.Empty : customer.Initial;
            Name += (Name == String.Empty) ? (customer.FirstName == null ? String.Empty : customer.FirstName) : " " + (customer.FirstName == null ? String.Empty : customer.FirstName);
            Name += (Name == String.Empty) ? (customer.MiddleName == null ? String.Empty : customer.MiddleName) : " " + (customer.MiddleName == null ? String.Empty : customer.MiddleName);
            Name += (Name == String.Empty) ? (customer.LastName == null ? String.Empty : customer.LastName) : " " + (customer.LastName == null ? String.Empty : customer.LastName);

            return Name;
        }
        
        private void Quarterly_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.Report.Dto dto = this.dto as Facade.Report.Dto;
            dto.date = dpSearchDate.Value.Date;
            dto.category = new Vanilla.Utility.Facade.Report.Category.Dto { Id = Convert.ToInt64(ReportCategory.Quarterly) };
                
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
