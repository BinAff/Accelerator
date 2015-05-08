using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;

namespace Vanilla.Accountant.WinForm
{

    public partial class AdvancePaymentForm : FormWin.Document
    {

        private ToolStripButton btnPrint;

        public AdvancePaymentForm()
        {
            InitializeComponent();
        }

        public AdvancePaymentForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();            
        }

        #region

        private void AdvancePaymentForm_Load(object sender, EventArgs e)
        {
            base.DisableAddAncestorButton();
            base.DisablePickAncestorButton();
            base.AncestorName = "...";
            base.DisableAttachButton();
            base.DisableShowAttachmentButton();
            base.AttachmentName = "...";

            base.AddToolStripSeparator();
            this.btnPrint = base.AddToolStripButton("6", "Wingdings 2", "Print Receipt");
            this.btnPrint.Click += btnPrint_Click;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            new AdvancePaymentReceipt().ShowDialog();
        }

        #endregion

        protected override void Compose()
        {
            //base.formDto = new Facade.FormDto
            //{
            //    ModuleFormDto = new UtilFac.Module.FormDto(),
            //    Dto = new Facade.Dto()
            //};

            //this.facade = new Facade.Server(base.formDto as Facade.FormDto);
        }

        protected override void LoadForm()
        {
            
        }

        protected override void PopulateDataToForm()
        {

        }

        protected override Boolean ValidateForm()
        {
            return true;
        }

        protected override void AssignDto()
        {

        }
        
    }

}
