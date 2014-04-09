using System;
using System.Windows.Forms;

using PresentationLibrary = BinAff.Presentation.Library;
using System.Collections.Generic;

namespace Vanilla.Invoice.WinForm.Report
{

    public partial class Monthly : PresentationLibrary.Form
    {
        private Facade.Report.Dto dto;
        private Facade.Report.FormDto formDto;

        public enum ReportCategory
        {
            //Daily = 10001,
            //Weekly = 2,
            Monthly = 10003,
            //Quarterly = 4,
            //Yearly = 5
        }

        //public Monthly()
        //{
        //    InitializeComponent();

        //    dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        //    DateTime dtFirstDayOfMonth = GetFirstDayOfMonth(DateTime.Today);
        //    //LoadData(dtFirstDayOfMonth);
        //}

        public Monthly(Facade.Report.Dto dto)
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

        public DateTime GetFirstDayOfMonth(DateTime givenDate)
        {
            return new DateTime(givenDate.Year, givenDate.Month, 1);
        }

        //private void LoadData(DateTime firstDayOfMonth)
        //{
        //    DateTime startDate = firstDayOfMonth;
        //    DateTime endDate = GetLastDayOfMonth(startDate);


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
        //                BuyerContactNo = salesData.BuyerContactNo,
        //                Group = WeekNo(salesData.Date)     
        //            };
        //            data.GroupDisplay = WeekDisplay(data.Group, salesData.Date);

        //            salesList.Add(data);
        //        }

        //        this.rvReport.Reset();
        //        this.rvReport.DocumentMapCollapsed = true;
        //        String path = System.IO.Directory.GetCurrentDirectory();
        //        path += @"\Report\Invoice Management System\Monthly.rdlc";
        //        //path = path.Remove(path.IndexOf("Reference"));
        //        //path += @"BinAff\Crystal Framework\Invoice Management System\Presentation\Report\Monthly.rdlc";

        //        this.rvReport.LocalReport.ReportPath = path;
        //        string sDataSourceName = "Sales";

        //        ReportParameter[] p = new ReportParameter[1];
        //        p[0] = new ReportParameter("MonthYear", GetMonthName(firstDayOfMonth.Month) + ", " + firstDayOfMonth.Year);
        //        this.rvReport.LocalReport.SetParameters(p);

        //        Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
        //        rptDataSoruce.Name = sDataSourceName;
        //        rptDataSoruce.Value = salesList;

        //        this.rvReport.Visible = true;
        //        this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
        //        this.rvReport.RefreshReport();

        //    }

        //}

        public DateTime GetLastDayOfMonth(DateTime givenDate)
        {
            DateTime firstDayOfTheMonth = new DateTime(givenDate.Year, givenDate.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        public String WeekDisplay(String weekNo, DateTime givenDate)
        {
            String WeekDisplay = String.Empty;
            DateTime FirstDayOfMonth = GetFirstDayOfMonth(givenDate);
            String startDate = String.Empty;
            String endDate = String.Empty;
            DateTime StartSecondWeek = DateTime.Today;

            DateTime StartThirdWeek = DateTime.Today;
            DateTime StartForthWeek = DateTime.Today;
            DateTime StartFifthWeek = DateTime.Today;
            DateTime StartSixthWeek = DateTime.Today;
            DateTime StartSevenWeek = DateTime.Today;

            if (FirstDayOfMonth.DayOfWeek.ToString() == "Monday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Mon)";
                endDate = FirstDayOfMonth.AddDays(6).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(7);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Tuesday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Tue)";
                endDate = FirstDayOfMonth.AddDays(5).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(6);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Wednesday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Wed)";
                endDate = FirstDayOfMonth.AddDays(4).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(5);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Thursday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Thu)";
                endDate = FirstDayOfMonth.AddDays(3).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(4);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Friday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Fri)";
                endDate = FirstDayOfMonth.AddDays(2).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(3);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Saturday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Fri)";
                endDate = FirstDayOfMonth.AddDays(1).ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(2);
            }
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Sunday")
            {
                startDate = FirstDayOfMonth.ToShortDateString() + " (Fri)";
                endDate = FirstDayOfMonth.ToShortDateString() + " (Sun)";

                StartSecondWeek = FirstDayOfMonth.AddDays(1);
            }

            StartThirdWeek = StartSecondWeek.AddDays(7);
            StartForthWeek = StartThirdWeek.AddDays(7);
            StartFifthWeek = StartForthWeek.AddDays(7);
            StartSixthWeek = StartFifthWeek.AddDays(7);

            if (weekNo == "1") WeekDisplay = startDate + "  --  " + endDate;
            else if (weekNo == "2")
                WeekDisplay = GetDisplayDate(StartSecondWeek) + "  --  " + GetDisplayDate(StartSecondWeek.AddDays(6));
            else if (weekNo == "3")
                WeekDisplay = GetDisplayDate(StartThirdWeek) + "  --  " + GetDisplayDate(StartThirdWeek.AddDays(6));
            else if (weekNo == "4")
                WeekDisplay = GetDisplayDate(StartForthWeek) + "  --  " + GetDisplayDate(GetEndDate(StartForthWeek, StartForthWeek.AddDays(6)));
            else if (weekNo == "5")
                WeekDisplay = GetDisplayDate(StartFifthWeek) + "  --  " + GetDisplayDate(GetEndDate(StartFifthWeek, StartFifthWeek.AddDays(6)));
            else if (weekNo == "6")
                WeekDisplay = GetDisplayDate(StartSixthWeek) + "  --  " + GetDisplayDate(GetEndDate(StartSixthWeek, StartSixthWeek.AddDays(6)));


            return WeekDisplay;
        }

        private String GetMonthName(int monthNumber)
        {
            if (monthNumber == 1) return "January";
            else if (monthNumber == 2) return "February";
            else if (monthNumber == 3) return "March";
            else if (monthNumber == 4) return "April";
            else if (monthNumber == 5) return "May";
            else if (monthNumber == 6) return "June";
            else if (monthNumber == 7) return "July";
            else if (monthNumber == 8) return "August";
            else if (monthNumber == 9) return "September";
            else if (monthNumber == 10) return "October";
            else if (monthNumber == 11) return "November";
            else return "December";

        }

        private String GetDisplayDate(DateTime givenDate)
        {
            String DisplayDate = String.Empty;
            if (givenDate.DayOfWeek.ToString() == "Monday")
                DisplayDate = givenDate.ToShortDateString() + " (Monday)";
            else if (givenDate.DayOfWeek.ToString() == "Tuesday")
                DisplayDate = givenDate.ToShortDateString() + " (Tuesday)";
            else if (givenDate.DayOfWeek.ToString() == "Wednesday")
                DisplayDate = givenDate.ToShortDateString() + " (Wednesday)";
            else if (givenDate.DayOfWeek.ToString() == "Thursday")
                DisplayDate = givenDate.ToShortDateString() + " (Thursday)";
            else if (givenDate.DayOfWeek.ToString() == "Friday")
                DisplayDate = givenDate.ToShortDateString() + " (Friday)";
            else if (givenDate.DayOfWeek.ToString() == "Saturday")
                DisplayDate = givenDate.ToShortDateString() + " (Saturday)";
            else if (givenDate.DayOfWeek.ToString() == "Sunday")
                DisplayDate = givenDate.ToShortDateString() + " (Sunday)";

            return DisplayDate;
        }

        private DateTime GetEndDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.Month.ToString() == endDate.Month.ToString())
                return endDate;
            else
                return startDate;
        }

        private void Monthly_Load(object sender, EventArgs e)
        {

            this.rvReport.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtFirstDayOfMonth = GetFirstDayOfMonth(dpSearchDate.Value);

            //if first day of the month is less than today 
            //if (DateTime.Compare(dtFirstDayOfMonth, DateTime.Parse(DateTime.Now.ToShortDateString())) <= 0)
            //    LoadData(dtFirstDayOfMonth);
        }

        public String WeekNo(DateTime givenDate)
        {
            String WeekNo = String.Empty;
            DateTime FirstDayOfMonth = GetFirstDayOfMonth(givenDate);

            int FirstWeekRange = 0;
            if (FirstDayOfMonth.DayOfWeek.ToString() == "Monday") FirstWeekRange = 7;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Tuesday") FirstWeekRange = 6;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Wednesday") FirstWeekRange = 5;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Thursday") FirstWeekRange = 4;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Friday") FirstWeekRange = 3;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Saturday") FirstWeekRange = 2;
            else if (FirstDayOfMonth.DayOfWeek.ToString() == "Sunday") FirstWeekRange = 1;

            int SecondWeekRange = FirstWeekRange + 7;
            int ThirdWeekRange = SecondWeekRange + 7;
            int ForthWeekRange = ThirdWeekRange + 7;
            int FifthWeekRange = ForthWeekRange + 7;
            int SixthWeekRange = FifthWeekRange + 7;
            int SeventhWeekRange = SixthWeekRange + 7;

            int NoOfDays = Convert.ToDateTime(givenDate).Subtract(Convert.ToDateTime(FirstDayOfMonth)).Days + 1;

            if (NoOfDays <= FirstWeekRange)
                WeekNo = "1";
            else if (NoOfDays <= SecondWeekRange)
                WeekNo = "2";
            else if (NoOfDays <= ThirdWeekRange)
                WeekNo = "3";
            else if (NoOfDays <= ForthWeekRange)
                WeekNo = "4";
            else if (NoOfDays <= FifthWeekRange)
                WeekNo = "5";
            else if (NoOfDays <= SixthWeekRange)
                WeekNo = "6";

            return WeekNo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.Report.Dto dto = this.dto as Facade.Report.Dto;
            //dto.fromDate = GetFirstDayOfMonth(dpSearchDate.Value);
            //dto.toDate = GetLastDayOfMonth(dpSearchDate.Value);
            dto.category = new Vanilla.Report.Facade.Category.Dto { Id = Convert.ToInt64(ReportCategory.Monthly) };

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

    }

}
