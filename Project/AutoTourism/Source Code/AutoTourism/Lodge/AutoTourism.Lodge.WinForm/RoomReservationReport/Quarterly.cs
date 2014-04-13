﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

using PresentationLibrary = BinAff.Presentation.Library;
//using FacadeReport = AutoTourism.Customer.Facade.Report;

namespace AutoTourism.Lodge.WinForm.RoomReservationReport
{
    public partial class Quarterly : PresentationLibrary.Form
    {
        private Facade.RoomReservationReport.Dto dto;
        private Facade.RoomReservationReport.FormDto formDto;

        public enum ReportCategory
        {
            Quarterly = 10004
        }

        public Quarterly(Facade.RoomReservationReport.Dto dto)
        {
            InitializeComponent();

            dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dto = dto;
            this.formDto = new Facade.RoomReservationReport.FormDto { dto = this.dto };

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
            //FacadeReport.IReport report = new FacadeReport.Server(null);
            //List<Facade.Dto> customerDataList = report.GetQuarterlyReport(date);

            //this.rvReport.Reset();
            //List<Data> customerList = new List<Data>();
            //if (customerDataList != null && customerDataList.Count > 0)
            //{
            //    foreach (Facade.Dto customerData in customerDataList)
            //    {
            //        customerList.Add(new Data
            //        {
            //            Name = customerData.FirstName
            //        });
            //    }

            //    //this.rvReport.Reset();
            //    this.rvReport.DocumentMapCollapsed = true;
            //    String path = System.IO.Directory.GetCurrentDirectory();
            //    path = path.Remove(path.IndexOf("AutoTourism"));
            //    path += @"Vanilla\Source Code\Vanilla\Invoice\Vanilla.Invoice.WinForm\Report\Daily.rdlc";


            //    this.rvReport.LocalReport.ReportPath = path;
            //    string sDataSourceName = "Customer";

            //    Microsoft.Reporting.WinForms.ReportDataSource rptDataSoruce = new Microsoft.Reporting.WinForms.ReportDataSource();
            //    rptDataSoruce.Name = sDataSourceName;
            //    rptDataSoruce.Value = customerList;

            //    this.rvReport.Visible = true;
            //    this.rvReport.LocalReport.DataSources.Add(rptDataSoruce);
            //    this.rvReport.RefreshReport();
            //}

        }

        private void Quarterly_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Facade.RoomReservationReport.Dto dto = this.dto as Facade.RoomReservationReport.Dto;
            dto.date = dpSearchDate.Value.Date;
            dto.category = new Vanilla.Utility.Facade.Report.Category.Dto { Id = Convert.ToInt64(ReportCategory.Quarterly) };

            BinAff.Facade.Library.Server facade = new Facade.RoomReservationReport.Server(this.formDto);
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
