using System.Windows.Forms;
using Facade = Vanilla.Invoice.Facade;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using BinAff.Utility;
using PresentationLibrary = BinAff.Presentation.Library;
using BinAff.Core;
using FormWin = Vanilla.Form.WinForm;
using UtilFac = Vanilla.Utility.Facade;
using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Invoice.WinForm
{
    public partial class Payment : System.Windows.Forms.Form
    {
        //private Facade.Payment.Dto dto;
        private Facade.Payment.FormDto formDto;
        //private Facade.Dto invoiceDto;
        //private TreeView trvForm;

        public Payment(Facade.Payment.FormDto formDto)
        {
            InitializeComponent();
            this.formDto = formDto;
            this.LoadForm();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            //this.LoadForm();
        }
        //public Payment(UtilFac.Artifact.Dto artifact)
        //    : base(artifact)
        //{
        //    InitializeComponent();            
        //}

        //public Payment(Facade.Dto invoiceDto, TreeView trvForm)
        //{
        //    InitializeComponent();

        //    this.trvForm = trvForm;
        //    this.invoiceDto = invoiceDto;
        //    this.dto = new Facade.Payment.Dto();
        //    this.formDto = new Facade.Payment.FormDto
        //    {
        //        dto = this.dto,
        //        ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
        //    };

        //    new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();

        //    this.dgvProduct.AutoGenerateColumns = false;
        //    this.dgvTax.AutoGenerateColumns = false;

        //    this.SetPaymentGridViewSettings();
        //    this.LoadProductData();
        //    //this.LoadTax();
        //    this.LoadForm();
        //}

        //public Payment()
        //    : base()
        //{
        //    InitializeComponent();
        //}


        //public Payment(Facade.Dto invoiceDto)
        //{
        //    InitializeComponent();        
        //    this.invoiceDto = invoiceDto;

        //    //this.dto = new Facade.Payment.Dto();
        //    //this.formDto = new Facade.Payment.FormDto
        //    //{
        //    //    dto = this.dto,
        //    //    ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
        //    //};

        //    //new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();

        //    //this.dgvProduct.AutoGenerateColumns = false;
        //    //this.dgvTax.AutoGenerateColumns = false;

        //    //this.SetPaymentGridViewSettings();
        //    //this.LoadProductData();
        //    ////this.LoadTax();
        //    //this.LoadForm();
        //}

        //protected override void Compose()
        //{
        //    base.formDto = new Facade.Payment.FormDto
        //    {
        //        ModuleFormDto = new UtilFac.Module.FormDto(),
        //        Dto = new Facade.Payment.Dto()
        //    };

        //    this.facade = new Facade.Payment.Server(base.formDto as Facade.Payment.FormDto);
        //}
              
        private void LoadForm()
        {
            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvTax.AutoGenerateColumns = false;

            this.SetPaymentGridViewSettings();

            //this.LoadProductData();
           

            Facade.Payment.Server server = new Facade.Payment.Server(this.formDto);
            server.LoadForm();

            //--populate payment type category
            this.cboPaymentType.DataSource = null;
            if (formDto.TypeList != null && formDto.TypeList.Count > 0)
            {
                this.cboPaymentType.DataSource = formDto.TypeList;
                this.cboPaymentType.ValueMember = "Id";
                this.cboPaymentType.DisplayMember = "Name";
                this.cboPaymentType.SelectedIndex = 0;
            }

            //this.txtArtifactPath.ReadOnly = true;
        }
              

        //private void LoadProductData()
        //{
        //    for (int i = 0; i < dgvProduct.Columns.Count; i++)
        //        dgvProduct.Columns[i].ReadOnly = true;

        //    dgvProduct.Columns[0].DataPropertyName = "Start";
        //    dgvProduct.Columns[1].DataPropertyName = "End";
        //    dgvProduct.Columns[2].DataPropertyName = "Description";
        //    dgvProduct.Columns[3].DataPropertyName = "UnitRate";
        //    dgvProduct.Columns[4].DataPropertyName = "Count";
        //    dgvProduct.Columns[5].DataPropertyName = "Total";
        //    dgvProduct.MultiSelect = false;

        //    List<Data> invoiceList = new List<Data>();
        //    Double lineItemTotal = 0;
        //    foreach (Facade.LineItem.Dto lineItem in this.formDto.ProductList)
        //    {
        //        invoiceList.Add(new Data
        //        {
        //            Start = lineItem.startDate.ToShortDateString(),
        //            End = lineItem.endDate.ToShortDateString(),
        //            Description = lineItem.description,
        //            UnitRate = lineItem.unitRate.ToString(),
        //            Count = lineItem.count.ToString(),
        //            Total = lineItem.total.ToString()
        //        });
        //        lineItemTotal += lineItem.total;
        //    }

        //    dgvProduct.DataSource = invoiceList;

        //    this.LoadTax(lineItemTotal);
           
        //}

        //private void LoadTax(Double total)
        //{
        //    //Facade.Dto invoiceDto = base.Artifact.Module as Vanilla.Invoice.Facade.Dto;

        //    Facade.IInvoice invoiceServer = new Facade.Server(null);
        //    List<Table> taxList = invoiceServer.CalulateTaxList(total, this.formDto.TaxationList);
        //    dgvTax.ColumnHeadersVisible = false;
        //    for (int i = 0; i < dgvTax.Columns.Count; i++)
        //        dgvTax.Columns[i].ReadOnly = true;

        //    dgvTax.Columns[0].DataPropertyName = "Name";
        //    dgvTax.Columns[1].DataPropertyName = "Value";

        //    dgvProduct.MultiSelect = false;
        //    dgvTax.DataSource = taxList;

        //    Double totalAfterTax = total;
        //    if (taxList != null && taxList.Count > 0)
        //    {
        //        foreach (Table tax in taxList)
        //            totalAfterTax += tax.Value;
        //    }
        //    txtTotal.Text = totalAfterTax.ToString();
        //    txtAdvance.Text = this.formDto.Advance.ToString();
        //    txtGrandTotal.Text = (totalAfterTax - this.formDto.Advance).ToString();
        //}

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            ////Facade.Dto invoiceDto = base.Artifact.Module as Vanilla.Invoice.Facade.Dto;
            //Double discount = 0;

            //if (ValidationRule.IsDouble(txtDiscount.Text))
            //    discount = Convert.ToDouble(txtDiscount.Text);

            //if (ValidationRule.IsDouble(txtDiscount.Text))
            //    txtGrandTotal.Text = (Convert.ToDouble(txtTotal.Text) - this.formDto.Advance - discount).ToString();
            
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidatePayment())
            {
                List<Facade.Payment.Dto> paymentDto = dgvPayment.DataSource == null ? new List<Facade.Payment.Dto>() : dgvPayment.DataSource as List<Facade.Payment.Dto>;
                paymentDto.Add(new Facade.Payment.Dto
                {
                    PaymentType = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name,
                    ReferenceNumber = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim(),
                    Remark = txtRemark.Text.Trim(),
                    Amount = Convert.ToDouble(txtAmount.Text),

                    Type = cboPaymentType.SelectedItem as Table
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
                        if (paymentDto.PaymentType == "Cash")
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
                        if (paymentDto.PaymentType == ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name && paymentDto.ReferenceNumber == txtLastFourDigit.Text.Trim())
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
                txtLastFourDigit.Text = paymentDto.ReferenceNumber;
                txtRemark.Text = paymentDto.Remark;
                txtAmount.Text = paymentDto.Amount.ToString();

                if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
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
                selectedDto.ReferenceNumber = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name == "Cash" ? String.Empty : txtLastFourDigit.Text.Trim();
                selectedDto.Amount = Convert.ToDouble(txtAmount.Text);
                selectedDto.Remark = txtRemark.Text.Trim();
                selectedDto.PaymentType = ((Facade.Payment.Type.Dto)cboPaymentType.SelectedItem).Name;

                dgvPayment.DataSource = null;
                dgvPayment.DataSource = paymentDtoList;
                this.Clear();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Facade.Dto invoiceDto = base.Artifact.Module as Vanilla.Invoice.Facade.Dto;

            //if (this.ValidateMakePayment())
            //{
            //    //call crystal invoice
            //    //invoiceDto.invoiceNumber = Common.GenerateInvoiceNumber();
            //    //invoiceDto.paymentList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
            //    //invoiceDto.discount = txtDiscount.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtDiscount.Text);
            //    //this.formDto.InvoiceNumber = Common.GenerateInvoiceNumber();
            //    this.formDto.PaymentList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
            //    this.formDto.Discount = txtDiscount.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtDiscount.Text);

            //    this.Close();

            //}
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
                    paymentTotal += dto.Amount;

                if (Convert.ToDouble(txtGrandTotal.Text) != paymentTotal)
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
