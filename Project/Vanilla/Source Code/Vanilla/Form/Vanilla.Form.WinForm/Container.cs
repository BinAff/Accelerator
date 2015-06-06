using System;

using AccFac = Vanilla.Guardian.Facade.Account;
using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.WinForm
{

    public partial class Container : UtilWin.Container
    {

        protected Container()
            : base()
        {
            InitializeComponent();
            this.Text = "Forms";
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {
            InitializeComponent();
            this.Text = "Forms";
        }

        private static Container currentInstance;

        public static Container CreateInstance(AccFac.Dto account)
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container(account);
            return currentInstance;
        }

        public static Container CreateInstance()
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container();
            return currentInstance;
        }

        private void Container_Load(object sender, EventArgs e)
        {
            //this.spnlLeftLink.Options[0].Name = (this.ActiveMdiChild as Document).AncestorName;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).RefreshForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).SaveForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).DeleteForm();
        }

        protected override void Compose()
        {
            base.facade = new Facade.Container.Server(null);
            base.IsPathShown = true;
        }

        protected override UtilWin.Container CreateExecutableInstance(AccFac.Dto dto)
        {
            return Vanilla.Form.WinForm.Container.CreateInstance(dto);
        }

        protected override UtilWin.OpenDialog GetOpenDialogue()
        {
            return new OpenDialog
            {
                Text = "Open Form",
                Owner = this,
            };
        }

        protected override UtilWin.SaveDialog GetNewDialogue()
        {
            return new SaveDialogue
            {
                Text = "Save Form",
                Owner = this,
            };
        }

        protected override void OnLeftPanleClick()
        {
            this.spnlLeftLink.Show();
        }

        protected override void OnRightPanleClick()
        {
            this.spnlRightLink.Show();
        }

        private void Container_MdiChildActivate(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).ButtonStatusChange += delegate(Document.ButtonType type, Document.ChangeProperty changeProperty, Boolean status)
            {
                System.Windows.Forms.Button button;
                switch (type)
                {
                    case Document.ButtonType.Delete:
                        button = this.btnDelete;
                        break;
                    case Document.ButtonType.Refresh:
                        button = this.btnRefresh;
                        break;
                    case Document.ButtonType.Save:
                        button = this.btnSave;
                        break;
                    default:
                        button = this.btnDelete;
                        break;
                }
                switch (changeProperty)
                {
                    case Document.ChangeProperty.Enabled:
                        button.Enabled = status;
                        break;
                    case Document.ChangeProperty.Visible:
                        button.Visible = status;
                        break;
                }
            };
            this.spnlLeftLink.Options[0].Name = (this.ActiveMdiChild as Document).AncestorName;
        }



    }

}