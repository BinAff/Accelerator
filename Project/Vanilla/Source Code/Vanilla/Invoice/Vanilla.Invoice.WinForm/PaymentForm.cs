using System;
using System.Text.RegularExpressions; 
using BinAff.Utility;
using System.Collections.Generic;
using System.Windows.Forms;
using BinAff.Core;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;
using PayFac = Vanilla.Invoice.Facade.Payment;
using PresentationLibrary = BinAff.Presentation.Library;

namespace Vanilla.Invoice.WinForm
{

    //public partial class PaymentForm : FormWin.Document
    public partial class PaymentForm : System.Windows.Forms.Form
    {
        PayFac.FormDto formDto = new PayFac.FormDto();
        public PaymentForm()
        {
            InitializeComponent();
            this.SetPaymentGridViewSettings();

            this.txtInvoiceNumber.Text = "INVO-30-05-201412910";
            this.formDto.InvoiceDto = new Facade.Dto 
            {
                invoiceNumber = "INVO-30-05-201412910"
            };

            this.LoadForm();
        }

        //public PaymentForm(UtilFac.Artifact.Dto artifact)
        //    : base(artifact)
        //{
        //    InitializeComponent();
        //}

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (this.ValidateMakePayment())
            {
                ReturnObject<Boolean> ret = new PayFac.Server(formDto).MakePayment(dgvPayment.DataSource as List<Facade.Payment.Dto>, txtInvoiceNumber.Text);            
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<Facade.Payment.Dto> paymentDto = dgvPayment.DataSource == null ? new List<Facade.Payment.Dto>() : dgvPayment.DataSource as List<Facade.Payment.Dto>;
                paymentDto.Add(new Facade.Payment.Dto
                {
                    paymentType = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name,
                    cardNumber = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim(),
                    remark = txtRemark.Text.Trim(),
                    amount = Convert.ToDouble(txtAmount.Text),

                    Type = (Facade.Payment.Type.Dto)cboPaymentType.SelectedItem
                });

                dgvPayment.DataSource = null;
                dgvPayment.DataSource = paymentDto;
                this.Clear();
            }
        }

        private Boolean ValidatePayment()
        {
            errorProvider.Clear();

            if (txtLastFourDigit.Text != String.Empty && !(new Regex(@"^[0-9]*$").IsMatch(txtLastFourDigit.Text)))
            {
                errorProvider.SetError(txtLastFourDigit, "Entered " + txtLastFourDigit.Text + " is Invalid.");
                txtLastFourDigit.Focus();
                return false;
            }
            else if (txtRemark.Text != String.Empty && txtRemark.Text.Trim().Length > 255)
            {
                errorProvider.SetError(txtRemark, "Length of remarks cannot be greater than 255.");
                txtRemark.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                errorProvider.SetError(txtAmount, "Please enter amount.");
                txtAmount.Focus();
                return false;
            }
            else if (!ValidationRule.IsDecimal(txtAmount.Text.Trim() == String.Empty ? "0" : txtAmount.Text.Trim().Replace(",", "")))
            {
                errorProvider.SetError(txtAmount, "Entered " + txtAmount.Text + " is Invalid.");
                txtAmount.Focus();
                return false;
            }
            else if (((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name == "Cash")  //[For Cash there will be only one line item]
            {
                if (dgvPayment.DataSource != null)
                {
                    List<Facade.Payment.Dto> paymentDtoList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
                    foreach (Facade.Payment.Dto paymentDto in paymentDtoList)
                    {
                        if (paymentDto.paymentType == "Cash")
                        {
                            errorProvider.SetError(cboPaymentType, "System will allow only one cash transaction.");
                            cboPaymentType.Focus();
                            return false;
                        }
                    }
                }
            }
            else if (((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name != "Cash") // same card cannot have more than one transaction
            {
                if (dgvPayment.DataSource != null)
                {
                    List<Facade.Payment.Dto> paymentDtoList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
                    foreach (Facade.Payment.Dto paymentDto in paymentDtoList)
                    {
                        if (paymentDto.paymentType == ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name && paymentDto.cardNumber == txtLastFourDigit.Text.Trim())
                        {
                            errorProvider.SetError(cboPaymentType, "Same card cannot be used more than once.");
                            cboPaymentType.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void Clear()
        {
            this.cboPaymentType.SelectedIndex = 0;
            txtLastFourDigit.Text = String.Empty;
            txtRemark.Text = String.Empty;
            txtAmount.Text = String.Empty;
        }

        private void SetPaymentGridViewSettings()
        {
            for (int i = 0; i < dgvPayment.Columns.Count; i++)
                dgvPayment.Columns[i].ReadOnly = true;

            dgvPayment.MultiSelect = false;

            dgvPayment.Columns[0].DataPropertyName = "paymentType";
            dgvPayment.Columns[1].DataPropertyName = "amount";
            dgvPayment.Columns[2].DataPropertyName = "cardNumber";
            dgvPayment.Columns[3].DataPropertyName = "remark";
            dgvPayment.AutoGenerateColumns = false;

            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            dgvPayment.Columns.Add(Editlink);

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dgvPayment.Columns.Add(Deletelink);
        }

        //protected override void Compose()
        //{
        //    //base.formDto = new Facade.FormDto
        //    //{
        //    //    ModuleFormDto = new UtilFac.Module.FormDto(),
        //    //    Dto = new Facade.Dto()
        //    //};
        //}

        //protected override DocFac.Dto CloneDto(DocFac.Dto source)
        //{
        //    return new DocFac.Dto();
        //}

        //protected override void LoadForm()
        //{
        //    //BinAff.Facade.Library.Server facade = new Facade.Server(formDto);
        //    //facade.LoadForm();

        //    //Facade.FormDto formDto = base.formDto as Facade.FormDto;
        //    //base.facade.LoadForm();
        //}

        //protected override void PopulateDataToForm()
        //{

        //}

        //protected override Boolean ValidateForm()
        //{
        //    return true;
        //}

        //protected override void AssignDto()
        //{
        //}

        protected void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new PayFac.Server(formDto);
            facade.LoadForm();
                       
            this.txtInvoiceDate.Text = "11-11-2014";
            this.txtPaymentAmount.Text = "5000";

            //--populate payment type category
            this.cboPaymentType.DataSource = null;
            if (formDto.typeList != null && formDto.typeList.Count > 0)
            {
                this.cboPaymentType.DataSource = formDto.typeList;
                this.cboPaymentType.ValueMember = "Id";
                this.cboPaymentType.DisplayMember = "Name";
                this.cboPaymentType.SelectedIndex = 0;
            }
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Facade.Payment.FormDto formDto = base.formDto as Facade.Payment.FormDto;

            int Edit = 4;
            int Delete = 5;
            List<Facade.Payment.Dto> paymentDtoList = dgvPayment.DataSource as List<Facade.Payment.Dto>;

            if (e.ColumnIndex == Delete)
            {
                paymentDtoList = this.RemoveDtoAtGivenPosition(paymentDtoList, e.RowIndex);
                dgvPayment.DataSource = paymentDtoList;
            }
            else if (e.ColumnIndex == Edit)
            {
                dgvPayment.Rows[e.RowIndex].Selected = true;
                Facade.Payment.Dto paymentDto = paymentDtoList[e.RowIndex];
                txtLastFourDigit.Text = paymentDto.cardNumber;
                txtRemark.Text = paymentDto.remark;
                txtAmount.Text = paymentDto.amount.ToString();

                if (this.formDto.typeList != null && this.formDto.typeList.Count > 0)
                {
                    for (int i = 0; i < cboPaymentType.Items.Count; i++)
                    {
                        if (paymentDto.Type.Id == ((Facade.Payment.Type.Dto)cboPaymentType.Items[i]).Id)
                        {
                            cboPaymentType.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private List<Facade.Payment.Dto> RemoveDtoAtGivenPosition(List<Facade.Payment.Dto> lstPaymentDto, int removePosition)
        {
            List<Facade.Payment.Dto> paymentDtoList = new List<Facade.Payment.Dto>();
            for (int i = 0; i < lstPaymentDto.Count; i++)
            {
                if (i != removePosition)
                    paymentDtoList.Add(lstPaymentDto[i]);
            }

            return paymentDtoList;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<Facade.Payment.Dto> paymentDtoList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
                Facade.Payment.Dto selectedDto = paymentDtoList[dgvPayment.SelectedRows[0].Index];
                selectedDto.cardNumber = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim();
                selectedDto.amount = Convert.ToDouble(txtAmount.Text);
                selectedDto.remark = txtRemark.Text.Trim();
                selectedDto.paymentType = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name;

                dgvPayment.DataSource = null;
                dgvPayment.DataSource = paymentDtoList;
                this.Clear();
            }
        }

        private Boolean ValidateMakePayment()
        {
            if (dgvPayment.DataSource == null)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(new List<String> { "No payment data exists." });

                return false;
            }
            else
            {
                Double paymentTotal = 0;
                List<Facade.Payment.Dto> paymentDtoList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
                foreach (Facade.Payment.Dto dto in paymentDtoList)
                    paymentTotal += dto.amount;

                if (Convert.ToDouble(txtPaymentAmount.Text) != paymentTotal)
                {
                    DialogResult result = MessageBox.Show("Total payment amount is not matching with bill total.Do you want to make the payment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }

}
