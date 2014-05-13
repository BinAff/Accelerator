using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

using UtilFac = Vanilla.Utility.Facade;
using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Report.Facade.Document;

namespace Vanilla.Report.WinForm
{

    public partial class Document : UtilWin.Document
    {

        public Document()
            : base()
        {
            InitializeComponent();
        }

        public Document(Facade.Document.FormDto formDto)
            : this()
        {
            this.formDto = formDto;
        }

        public Document(ArtfFac.Dto dto)
            : this()
        {
            this.formDto = new DocFac.FormDto
            {
                Dto = dto.Module as DocFac.Dto,
                Document = dto,
                ModuleName = dto.ComponentDefinition.Name,
                Category = (dto.Module as DocFac.Dto).Category,
            };
        }

        private void Document_Load(object sender, EventArgs e)
        {
            this.facade = Facade.Document.Server.GetReportSpecificFacade(this.formDto as Facade.Document.FormDto);
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            (this.formDto.Dto as Facade.Document.Dto).Date = dpSearchDate.Value.Date;
            if (this.formDto.Dto.Id > 0)
            {
                this.pnlReportDetail.Hide();
                this.LoadData((this.formDto.Dto as Facade.Document.Dto).Date);
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

        protected override void Compose()
        {
            
        }

        private void LoadData(DateTime date)
        {
            Facade.Document.FormDto formDto = this.formDto as Facade.Document.FormDto;
            Facade.Document.Dto dto = this.formDto.Dto as Facade.Document.Dto;
            Facade.Document.Server facade = this.facade as Facade.Document.Server;

            formDto.ReportData = facade.Generate(date, dto.Category);
            facade.SetCategory(dto.Category);
            List<BinAff.Facade.Library.Dto> dataList = formDto.ReportData;
            this.rvReport.Reset();
            Vanilla.Report.Facade.Document.Dto updatedDto = facade.GetDto();
            dto.ReportFilePath = updatedDto.ReportFilePath;
            dto.DataSource = updatedDto.DataSource;
            dto.Start = updatedDto.Start;
            dto.End = updatedDto.End;
            if (dataList != null && dataList.Count > 0)
            {
                
                this.rvReport.DocumentMapCollapsed = true;
                this.rvReport.LocalReport.ReportPath = dto.ReportFilePath;
                this.rvReport.LocalReport.SetParameters(new ReportParameter("Start", dto.Start.ToShortDateString()));
                this.rvReport.LocalReport.SetParameters(new ReportParameter("End", dto.End.ToShortDateString()));

                this.rvReport.Visible = true;
                this.rvReport.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource
                {
                    Name = dto.DataSource,
                    Value = dataList
                });
                this.rvReport.RefreshReport();
            }
            this.SetTitle();
        }

        private void SetTitle()
        {
            Facade.Document.FormDto formDto = this.formDto as Facade.Document.FormDto;
            Facade.Document.Dto dto = this.formDto.Dto as Facade.Document.Dto;

            this.Text = String.Format("{0} :: {1} - {2} Report", this.formDto.DocumentName, formDto.ModuleName,
                formDto.Category.Name);
            if (formDto.Category.Id == 10001)
            {
                this.Text = String.Format("{0} on {1}", this.Text, dto.Start.ToShortDateString());
            }
            else
            {
                this.Text = String.Format("{0} from {1} to {2}", this.Text,
                    dto.Start.ToShortDateString(), dto.End.ToShortDateString());
            }
        }

        private void Save(DateTime date)
        {
            Facade.Document.Server facade = this.facade as Facade.Document.Server;

            facade.SetDate(date);
            facade.Add();
            this.formDto.Dto.Id = facade.GetModule().Id;
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
