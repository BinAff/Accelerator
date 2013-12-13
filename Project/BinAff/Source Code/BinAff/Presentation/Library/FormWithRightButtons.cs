using System;

using BinAff.Core;

namespace BinAff.Presentation.Library
{

    public partial  class FormWithRightButtons : System.Windows.Forms.Form
    {

        public FormWithRightButtons()
        {
            InitializeComponent();
            
        }

        public Boolean IsDeleteButton
        {
            set
            {
                this.btnDelete.Enabled = value;
            }
        }

        protected virtual void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadForm();
            this.Clear();
        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            this.SubmitData();
        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteData();
        }

        protected virtual void btnChange_Click(object sender, EventArgs e)
        {
            this.SubmitData();
        }

        protected virtual void LoadForm()
        {
            throw new NotImplementedException();
        }

        protected virtual void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submit data in dialog box
        /// </summary>
        protected virtual void SubmitData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete data in dialog box
        /// </summary>
        protected virtual void DeleteData()
        {
            throw new NotImplementedException();
        }

        protected void ShowMessage(ReturnObject<Boolean> ret)
        {
            new MessageBox().Show(ret.MessageList);
            if (!ret.HasError())
            {
                this.LoadForm();
                this.Clear();
            }
        }

    }

}
