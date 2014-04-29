using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PresLib = BinAff.Presentation.Library;
using Util = Vanilla.Utility.Facade.Report;

namespace Vanilla.Report.WinForm
{

    public partial class Document : BinAff.Presentation.Library.Form
    {

        private Facade.Document.FormDto formDto;
        private Facade.Document.Server facade;

        public Document()
        {
            InitializeComponent();
        }

        public Document(Facade.Document.Dto dto, Facade.Document.Server facade)
            : this()
        {
            this.formDto = new Facade.Document.FormDto
            {
                Dto = dto,
            };

            this.formDto.Dto.Date = dpSearchDate.Value.Date;
            this.facade = facade;
        }

        private void Document_Load(object sender, EventArgs e)
        {
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            if (this.formDto.Dto.Id > 0)
            {
                this.pnlReportDetail.Hide();
                this.LoadData(this.formDto.Dto.Date);
            }
            else
            {
                this.LoadData(DateTime.Today);
            }
        }

        private void dpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData(dpSearchDate.Value.Date);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save(this.dpSearchDate.Value.Date);
            base.IsModified = true;
        }

        private void LoadData(DateTime date)
        {
            this.formDto.ReportData = this.facade.Generate(date, this.formDto.Dto.Category);
            this.facade.SetCategory(this.formDto.Dto.Category);
            List<BinAff.Facade.Library.Dto> dataList = this.formDto.ReportData;
            this.rvReport.Reset();
            if (dataList != null && dataList.Count > 0)
            {
                Vanilla.Report.Facade.Document.Dto dto = this.facade.SetReportCredential();
                this.formDto.Dto.Path = dto.Path;
                this.formDto.Dto.DataSource = dto.DataSource;
                this.rvReport.DocumentMapCollapsed = true;
                this.rvReport.LocalReport.ReportPath = this.formDto.Dto.Path;
                this.rvReport.LocalReport.SetParameters(new ReportParameter("Start", dto.Start.ToShortDateString()));
                this.rvReport.LocalReport.SetParameters(new ReportParameter("End", dto.End.ToShortDateString()));

                this.rvReport.Visible = true;
                this.rvReport.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource
                {
                    Name = this.formDto.Dto.DataSource,
                    Value = dataList
                });
                this.rvReport.RefreshReport();
            }
        }

        private void Save(DateTime date)
        {
            this.facade.SetDate(date);
            this.facade.Add();
            this.formDto.Dto.Id = this.facade.GetModule().Id;
            if (!facade.IsError)
            {
                this.Close();
            }
            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Reports",
            }.Show(facade.DisplayMessageList);
        }

    }

}
