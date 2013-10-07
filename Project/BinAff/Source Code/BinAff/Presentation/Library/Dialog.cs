using System;
using System.Windows.Forms;

namespace BinAff.Presentation.Library
{

    public abstract partial class Dialog : System.Windows.Forms.Form
    {

        public Dialog()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.LoadData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SubmitData();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Submit data in dialog box
        /// </summary>
        protected virtual void SubmitData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load dialog box;
        /// </summary>
        protected virtual void LoadData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear all controls in dialog box
        /// </summary>
        protected virtual void ClearData()
        {
            throw new NotImplementedException();
        }

    }

}
