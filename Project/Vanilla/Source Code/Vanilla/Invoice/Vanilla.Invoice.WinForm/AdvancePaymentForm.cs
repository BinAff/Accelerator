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

namespace Vanilla.Invoice.WinForm
{

    public partial class AdvancePaymentForm : FormWin.Document
    {

        public AdvancePaymentForm()
        {
            InitializeComponent();
        }

        public AdvancePaymentForm(UtilFac.Artifact.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();            
        }

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
