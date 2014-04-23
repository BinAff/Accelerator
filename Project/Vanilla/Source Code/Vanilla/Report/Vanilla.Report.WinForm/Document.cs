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
            this.dpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.formDto = new Facade.Document.FormDto { Dto = dto };
            this.facade = facade;            
            if (this.formDto.Dto.Id > 0)
            {
                this.pnlReportDetail.Hide();
                this.LoadData(dpSearchDate.Value.Date);
            }
            else
            {
                this.LoadData(DateTime.Today);
            }
        }

        private void Document_Load(object sender, EventArgs e)
        {
            //this.rvReport.RefreshReport();
        }

        private void dpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData(dpSearchDate.Value.Date);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            this.Save();
        }

        private void LoadData(DateTime date)
        {
            this.facade.Generate(date, this.formDto.Dto.Category);
            List<BinAff.Facade.Library.Dto> dataList = this.formDto.ReportData;
            this.rvReport.Reset();
            List<Facade.Document.DisplayData> displayDataList = new List<Facade.Document.DisplayData>();
            if (dataList != null && dataList.Count > 0)
            {
                //foreach (Facade.Document.Dto data in dataList)
                //{
                //    displayDataList.Add(this.CreateDataObject(data));
                //}
                this.facade.SetReportCredential();
                this.rvReport.DocumentMapCollapsed = true;
                this.rvReport.LocalReport.ReportPath = this.formDto.Dto.Path;
                this.rvReport.Visible = true;
                this.rvReport.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource
                {
                    Name = this.formDto.Dto.DataSource,
                    Value = dataList
                });
                this.rvReport.RefreshReport();
            }
        }

        private void Save()
        {
            this.formDto.Dto.Date = dpSearchDate.Value.Date;
            //this.formDto.Dto.Category = new Util.Category.Dto { Id = Convert.ToInt64(ReportCategory.Daily) };

            BinAff.Facade.Library.Server facade = new Facade.Document.Server(this.formDto);
            facade.Add();

            if (facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                    Heading = "Reports",
                }.Show(facade.DisplayMessageList);
            }
            else
            {
                this.Close();
            }
        }

        //protected Facade.Document.DisplayData CreateDataObject(Facade.Document.Dto data)
        //{
        //    throw new NotImplementedException();
        //}

    }

}
