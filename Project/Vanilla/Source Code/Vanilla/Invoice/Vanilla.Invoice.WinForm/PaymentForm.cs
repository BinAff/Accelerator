using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;

using BinAff.Utility;
using BinAff.Core;
using BinAff.Presentation.Library.Extension;

using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Utility.Facade.Document;
using PayFac = Vanilla.Invoice.Facade.Payment;
using PresentationLibrary = BinAff.Presentation.Library;

namespace Vanilla.Invoice.WinForm
{

    public partial class PaymentForm : FormWin.Document
    {

        public PaymentForm()
        {
            InitializeComponent();
            this.SetPaymentGridViewSettings();
            (base.formDto as PayFac.FormDto).InvoiceDto = new Facade.Dto 
            {
                invoiceNumber = "INVO-30-05-201412910"
            };

            this.LoadForm();
        }

        public PaymentForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
            this.SetPaymentGridViewSettings();
            (base.formDto as PayFac.FormDto).InvoiceDto = new Facade.Dto
            {
                invoiceNumber = "INVO-30-05-201412910"
            };
        }

        protected override void Compose()
        {
            this.formDto = new PayFac.FormDto
            {
                Dto = new PayFac.Dto()
            };

            this.facade = new PayFac.Server(this.formDto as PayFac.FormDto);
        }

        //protected override void Ok()
        //{
        //    if (base.Save())
        //    {
        //        base.Artifact.Module = base.formDto.Dto;
        //        base.IsModified = true;
        //        //this.Close();
        //    }
        //}

        protected override void LoadForm()
        {
            base.facade.LoadForm();
        }

        protected override void ClearForm()
        {
            this.cboPaymentType.SelectedIndex = 0;
            this.txtAmount.Text = String.Empty;
            this.txtLastFourDigit.Text = String.Empty;
            this.txtRemark.Text = String.Empty;
        }

        protected override void RevertForm()
        {
            PayFac.Dto dto = (base.formDto as PayFac.FormDto).Dto as PayFac.Dto;
            dto.LineItemList = (InitialDto as PayFac.Dto).LineItemList;
        }

        protected override DocFac.Dto CloneDto(DocFac.Dto source)
        {
            return source.Clone() as DocFac.Dto;
        }

        protected override void PopulateDataToForm()
        {
            PayFac.FormDto formDto = base.formDto as PayFac.FormDto;

            this.cboPaymentType.DisplayMember = "Name";
            this.cboPaymentType.Bind(formDto.TypeList);

            List<PayFac.LineItem> paymentList = (formDto.Dto as PayFac.Dto).LineItemList;
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (PayFac.LineItem dto in paymentList)
                {
                    dto.PaymentType = (facade as PayFac.Server).GetPaymentName(dto.Type.Id, formDto.TypeList);
                }

                this.dgvPayment.DataSource = null;
                this.dgvPayment.DataSource = paymentList;

                this.cboPaymentType.Enabled = false;
                this.txtLastFourDigit.Enabled = false;
                this.txtRemark.Enabled = false;
                this.txtAmount.Enabled = false;
                this.dgvPayment.Enabled = false;
                base.DisableOkButton();
                this.btnAdd.Enabled = false;
                this.btnChange.Enabled = false;
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        protected override void AssignDto()
        {
            PayFac.Dto dto = (base.formDto as PayFac.FormDto).Dto as PayFac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;

            dto.LineItemList = this.dgvPayment.DataSource as List<PayFac.LineItem>;
           
        }

        protected override Boolean ValidateForm()
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
                List<PayFac.LineItem> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem>;
                foreach (PayFac.LineItem dto in paymentDtoList)
                {
                    paymentTotal += dto.Amount;
                }

                //Need to check the logic in invoice grid and payment form

                //if (Convert.ToDouble(this.txtAmount.Text) != paymentTotal)
                //{
                //    DialogResult result = MessageBox.Show("Total payment amount is not matching with bill total.Do you want to make the payment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (result == System.Windows.Forms.DialogResult.No)
                //    {
                //        return false;
                //    }
                //}
            }

            return true;
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<PayFac.LineItem> paymentList = dgvPayment.DataSource == null ? new List<PayFac.LineItem>() : dgvPayment.DataSource as List<PayFac.LineItem>;
                paymentList.Add(new Facade.Payment.LineItem
                {
                    PaymentType = (cboPaymentType.SelectedItem as Table).Name,
                    Reference = (cboPaymentType.SelectedItem as Table).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim(),
                    Remark = txtRemark.Text.Trim(),
                    Amount = Convert.ToDouble(txtAmount.Text),

                    Type = cboPaymentType.SelectedItem as Table
                });

                dgvPayment.DataSource = null;
                dgvPayment.DataSource = paymentList;
                this.ClearForm();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<PayFac.LineItem> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem>;
                PayFac.LineItem selectedDto = paymentDtoList[dgvPayment.SelectedRows[0].Index];
                selectedDto.Reference = (cboPaymentType.SelectedItem as Table).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim();
                selectedDto.Amount = Convert.ToDouble(txtAmount.Text);
                selectedDto.Remark = txtRemark.Text.Trim();
                selectedDto.PaymentType = (cboPaymentType.SelectedItem as Table).Name;

                dgvPayment.DataSource = null;
                dgvPayment.DataSource = paymentDtoList;
                this.ClearForm();
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
            else if ((cboPaymentType.SelectedItem as Table).Name == "Cash")  //[For Cash there will be only one line item]
            {
                if (dgvPayment.DataSource != null)
                {
                    List<PayFac.LineItem> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem>;
                    foreach (PayFac.LineItem paymentDto in paymentDtoList)
                    {
                        if (paymentDto.PaymentType == "Cash")
                        {
                            errorProvider.SetError(cboPaymentType, "System will allow only one cash transaction.");
                            cboPaymentType.Focus();
                            return false;
                        }
                    }
                }
            }
            else if ((cboPaymentType.SelectedItem as Table).Name != "Cash") // same card cannot have more than one transaction
            {
                if (dgvPayment.DataSource != null)
                {
                    List<PayFac.LineItem> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem>;
                    foreach (PayFac.LineItem paymentDto in paymentDtoList)
                    {
                        if (paymentDto.PaymentType == (cboPaymentType.SelectedItem as Table).Name && paymentDto.Reference == txtLastFourDigit.Text.Trim())
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
        
        private void SetPaymentGridViewSettings()
        {
            for (int i = 0; i < dgvPayment.Columns.Count; i++)
                dgvPayment.Columns[i].ReadOnly = true;

            dgvPayment.MultiSelect = false;

            dgvPayment.Columns[0].DataPropertyName = "PaymentType";
            dgvPayment.Columns[1].DataPropertyName = "Amount";
            dgvPayment.Columns[2].DataPropertyName = "Reference";
            dgvPayment.Columns[3].DataPropertyName = "Remark";
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

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Facade.Payment.FormDto formDto = base.formDto as Facade.Payment.FormDto;

            int Edit = 4;
            int Delete = 5;
            List<PayFac.LineItem> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem>;

            if (e.ColumnIndex == Delete)
            {
                paymentDtoList = this.RemoveDtoAtGivenPosition(paymentDtoList, e.RowIndex);
                dgvPayment.DataSource = paymentDtoList;
            }
            else if (e.ColumnIndex == Edit)
            {
                dgvPayment.Rows[e.RowIndex].Selected = true;
                PayFac.LineItem paymentDto = paymentDtoList[e.RowIndex];
                txtLastFourDigit.Text = paymentDto.Reference;
                txtRemark.Text = paymentDto.Remark;
                txtAmount.Text = paymentDto.Amount.ToString();

                if ((base.formDto as PayFac.FormDto).TypeList != null && (base.formDto as PayFac.FormDto).TypeList.Count > 0)
                {
                    for (int i = 0; i < cboPaymentType.Items.Count; i++)
                    {
                        if (paymentDto.Type.Id == (cboPaymentType.Items[i] as Table).Id)
                        {
                            cboPaymentType.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private List<PayFac.LineItem> RemoveDtoAtGivenPosition(List<PayFac.LineItem> lstPaymentDto, int removePosition)
        {
            List<PayFac.LineItem> paymentDtoList = new List<PayFac.LineItem>();
            for (int i = 0; i < lstPaymentDto.Count; i++)
            {
                if (i != removePosition)
                    paymentDtoList.Add(lstPaymentDto[i]);
            }

            return paymentDtoList;
        }
        
    }

}
