using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;

using BinAff.Utility;
using BinAff.Core;
using BinAff.Presentation.Library.Extension;
using PresLib = BinAff.Presentation.Library;

using FrmWin = Vanilla.Form.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using InvFac = Vanilla.Invoice.Facade;
using PayFac = Vanilla.Invoice.Facade.Payment;

namespace Vanilla.Invoice.WinForm
{

    public partial class PaymentForm : FrmWin.Document
    {

        ToolStripButton btnPrint;

        public PaymentForm()
        {
            InitializeComponent();
            //(base.formDto as PayFac.FormDto).InvoiceDto = new Facade.Dto
            //{
            //    InvoiceNumber = "INVO-30-05-201412910"
            //};
        }

        public PaymentForm(ArtfFac.Dto artifact)
            : base(artifact)
        {
            InitializeComponent();
        }

        #region Event

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new PaymentReceipt().ShowDialog(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<PayFac.LineItem.Dto> paymentList = this.dgvPayment.DataSource == null ? new List<PayFac.LineItem.Dto>() : this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
                paymentList.Add(new Facade.Payment.LineItem.Dto
                {
                    Reference = (this.cboPaymentType.SelectedItem as Table).Name == "Cash" ? String.Empty : this.txtLastFourDigit.Text.Trim(),
                    Remark = this.txtRemark.Text.Trim(),
                    Amount = Convert.ToDouble(this.txtAmount.Text),
                    Type = this.cboPaymentType.SelectedItem as Table
                });

                this.dgvPayment.DataSource = null;
                this.dgvPayment.DataSource = paymentList;
                this.ClearForm();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<PayFac.LineItem.Dto> paymentList = this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
                PayFac.LineItem.Dto selectedDto = paymentList[dgvPayment.SelectedRows[0].Index];
                selectedDto.Reference = (this.cboPaymentType.SelectedItem as Table).Name == "Cash" ? String.Empty : this.txtLastFourDigit.Text.Trim();
                selectedDto.Amount = Convert.ToDouble(this.txtAmount.Text);
                selectedDto.Remark = this.txtRemark.Text.Trim();
                selectedDto.Type = this.cboPaymentType.SelectedItem as Table;

                this.dgvPayment.DataSource = null;
                this.dgvPayment.DataSource = paymentList;
                this.ClearForm();
            }
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const Int32 EDIT_INDEX = 4;
            const Int32 DELETE_INDEX = 5;
            List<PayFac.LineItem.Dto> paymentList = this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;

            if (e.ColumnIndex == DELETE_INDEX)
            {
                paymentList.RemoveAt(e.RowIndex);
                //paymentList = this.RemoveDtoAtGivenPosition(paymentList, e.RowIndex);
                this.dgvPayment.DataSource = null;
                this.dgvPayment.DataSource = paymentList;
            }
            else if (e.ColumnIndex == EDIT_INDEX)
            {
                this.dgvPayment.Rows[e.RowIndex].Selected = true;
                PayFac.LineItem.Dto paymentDto = paymentList[e.RowIndex];
                this.txtLastFourDigit.Text = paymentDto.Reference;
                this.txtRemark.Text = paymentDto.Remark;
                this.txtAmount.Text = paymentDto.Amount.ToString();

                if ((base.formDto as PayFac.FormDto).TypeList != null && (base.formDto as PayFac.FormDto).TypeList.Count > 0)
                {
                    for (int i = 0; i < this.cboPaymentType.Items.Count; i++)
                    {
                        if (paymentDto.Type.Id == (this.cboPaymentType.Items[i] as Table).Id)
                        {
                            this.cboPaymentType.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region Protected

        protected override void Compose()
        {
            this.formDto = new PayFac.FormDto
            {
                Dto = new PayFac.Dto()
            };

            this.facade = new PayFac.Server(this.formDto as PayFac.FormDto);
        }

        protected override void LoadForm()
        {
            base.AddToolStripSeparator();
            this.btnPrint = base.AddToolStripButton("6", "Wingdings 2", "Print");
            this.btnPrint.Click += btnPrint_Click;

            base.facade.LoadForm();
            this.SetPaymentGridViewSettings();

            this.cboPaymentType.Bind((base.formDto as PayFac.FormDto).TypeList, "Name");
        }

        protected override void PopulateDataToForm()
        {
            PayFac.FormDto formDto = base.formDto as PayFac.FormDto;
            PayFac.Dto dto = formDto.Dto as PayFac.Dto;

            this.PopulateAnsestorData(dto.Invoice);

            this.txtReceiptNo.Text = dto.ReceiptNumber;
            if (dto.Status != null) this.txtStatus.Text = dto.Status.Name;
            this.dgvPayment.DataSource = dto.LineItemList;
        }

        protected override Boolean ValidateForm()
        {
            if (dgvPayment.DataSource == null)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(new List<String> { "No payment data exists." });

                return false;
            }
            else
            {
                Double paymentTotal = 0;
                List<PayFac.LineItem.Dto> paymentDtoList = dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
                foreach (PayFac.LineItem.Dto dto in paymentDtoList)
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

        protected override void AssignDto()
        {
            PayFac.Dto dto = (base.formDto as PayFac.FormDto).Dto as PayFac.Dto;
            dto.Id = dto == null ? 0 : dto.Id;

            dto.LineItemList = this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
            if (this.dgvInvoice.DataSource != null && (this.dgvInvoice.DataSource as List<InvFac.Dto>).Count > 0) dto.Invoice = (this.dgvInvoice.DataSource as List<InvFac.Dto>)[0];
        }

        protected override void ClearForm()
        {
            this.cboPaymentType.SelectedIndex = 0;
            this.txtAmount.Text = String.Empty;
            this.txtLastFourDigit.Text = String.Empty;
            this.txtRemark.Text = String.Empty;
        }

        protected override void DisableFormControls()
        {
            List<PayFac.LineItem.Dto> paymentList = (base.formDto.Dto as PayFac.Dto).LineItemList;
            if (paymentList != null && paymentList.Count > 0)
            {
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

        protected override FrmWin.Document GetAnsestorForm()
        {
            return new InvoiceForm(new ArtfFac.Dto());
        }

        protected override void PopulateAnsestorData(Form.Facade.Document.Dto dto)
        {
            //Call invoice component to get the data. It cannot be accessed using child concept,
            //because it will create circuler reference.
            dto = (base.facade as Vanilla.Invoice.Facade.Payment.Server).GetInvoice(dto as InvFac.Dto);
            if (dto != null)
            {
                this.dgvInvoice.Columns[1].DataPropertyName = "Date";
                this.dgvInvoice.Columns[2].DataPropertyName = "InvoiceNumber";
                this.dgvInvoice.Columns[3].DataPropertyName = "Total";
                this.dgvInvoice.Columns[4].DataPropertyName = "Advance";
                this.dgvInvoice.Columns[5].DataPropertyName = "Discount";
                this.dgvInvoice.Columns[6].DataPropertyName = "Outstanding";
                this.dgvInvoice.AutoGenerateColumns = false;

                this.dgvInvoice.DataSource = new List<InvFac.Dto>
                {
                    dto as InvFac.Dto,
                };
            }
        }

        #endregion

        private Boolean ValidatePayment()
        {
            errorProvider.Clear();

            if (!String.IsNullOrEmpty(this.txtLastFourDigit.Text) && !(new Regex(@"^[0-9]*$").IsMatch(this.txtLastFourDigit.Text)))
            {
                this.errorProvider.SetError(this.txtLastFourDigit, "Entered " + this.txtLastFourDigit.Text + " is Invalid.");
                this.txtLastFourDigit.Focus();
                return false;
            }
            else if (!String.IsNullOrEmpty(this.txtRemark.Text) && this.txtRemark.Text.Trim().Length > 255)
            {
                this.errorProvider.SetError(this.txtRemark, "Length of remarks cannot be greater than 255.");
                this.txtRemark.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtAmount.Text))
            {
                this.errorProvider.SetError(this.txtAmount, "Please enter amount.");
                this.txtAmount.Focus();
                return false;
            }
            else if (!ValidationRule.IsDecimal(this.txtAmount.Text.Trim() == String.Empty ? "0" : this.txtAmount.Text.Trim().Replace(",", "")))
            {
                this.errorProvider.SetError(this.txtAmount, "Entered " + this.txtAmount.Text + " is Invalid.");
                this.txtAmount.Focus();
                return false;
            }
            else if (this.cboPaymentType.SelectedItem == null)
            {
                this.errorProvider.SetError(this.cboPaymentType, "Payment type is not selected.");
                this.cboPaymentType.Focus();
                return false;
            }
            else if ((this.cboPaymentType.SelectedItem as Table).Name == "Cash")  //[For Cash there will be only one line item]
            {
                if (this.dgvPayment.DataSource != null)
                {
                    List<PayFac.LineItem.Dto> paymentList = this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
                    foreach (PayFac.LineItem.Dto paymentDto in paymentList)
                    {
                        if (paymentDto.Type.Name == "Cash")
                        {
                            this.errorProvider.SetError(this.cboPaymentType, "System will allow only one cash transaction.");
                            this.cboPaymentType.Focus();
                            return false;
                        }
                    }
                }
            }
            else if ((this.cboPaymentType.SelectedItem as Table).Name != "Cash") // same card cannot have more than one transaction
            {
                if (this.dgvPayment.DataSource != null)
                {
                    List<PayFac.LineItem.Dto> paymentDtoList = this.dgvPayment.DataSource as List<PayFac.LineItem.Dto>;
                    foreach (PayFac.LineItem.Dto paymentDto in paymentDtoList)
                    {
                        if (paymentDto.Type == (this.cboPaymentType.SelectedItem as Table) && paymentDto.Reference == this.txtLastFourDigit.Text.Trim())
                        {
                            this.errorProvider.SetError(this.cboPaymentType, "Same card cannot be used more than once.");
                            this.cboPaymentType.Focus();
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
            {
                dgvPayment.Columns[i].ReadOnly = true;
            }

            dgvPayment.MultiSelect = false;

            this.dgvPayment.Columns[0].DataPropertyName = "TypeName";
            this.dgvPayment.Columns[1].DataPropertyName = "Amount";
            this.dgvPayment.Columns[2].DataPropertyName = "Reference";
            this.dgvPayment.Columns[3].DataPropertyName = "Remark";
            this.dgvPayment.Columns[4].DataPropertyName = "EditColumn";
            this.dgvPayment.Columns[5].DataPropertyName = "DeleteColumn";
            this.dgvPayment.AutoGenerateColumns = false;
        }

        private List<PayFac.LineItem.Dto> RemoveDtoAtGivenPosition(List<PayFac.LineItem.Dto> lstPaymentDto, int removePosition)
        {
            List<PayFac.LineItem.Dto> paymentDtoList = new List<PayFac.LineItem.Dto>();
            for (int i = 0; i < lstPaymentDto.Count; i++)
            {
                if (i != removePosition)
                {
                    paymentDtoList.Add(lstPaymentDto[i]);
                }
            }

            return paymentDtoList;
        }

    }

}