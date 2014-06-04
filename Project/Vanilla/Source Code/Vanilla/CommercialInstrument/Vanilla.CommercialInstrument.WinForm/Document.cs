using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Utility.Facade.Document;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.CommercialInstrument.WinForm
{

    public partial class Document : UtilWin.Document
    {

        public delegate void OnArtifactSaved(ArtfFac.Dto document);
        public event OnArtifactSaved ArtifactSaved;

        public Document()
            : base()
        {
            InitializeComponent();
        }

        public Document(ArtfFac.Dto artifact)
            : this()
        {
            base.formDto.Document = artifact;
        }

        private void Document_Load(object sender, EventArgs e)
        {
            
        }

        private void Document_Shown(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (this.Artifact != null && this.Artifact.Id != 0)
            {
                this.SetTitle();
                this.formDto.Document = this.Artifact;
                if (this.Artifact.Module != null)
                {
                    this.formDto.Dto = this.Artifact.Module as DocFac.Dto;
                }
                this.LoadForm();
                //if (this.formDto.Dto != null)
                //{
                //    this.PopulateDataToForm();
                //}
                if (this.ArtifactSaved != null) this.ArtifactSaved(this.formDto.Document);
            }
        }

        protected virtual void LoadForm()
        {
            this.rvViewer.RefreshReport();
            //
        }

        private void SetTitle()
        {
            DocFac.FormDto formDto = this.formDto as DocFac.FormDto;
            DocFac.Dto dto = this.formDto.Dto as DocFac.Dto;

            this.Text += " :: " + this.formDto.DocumentName;
        }

    }
}
