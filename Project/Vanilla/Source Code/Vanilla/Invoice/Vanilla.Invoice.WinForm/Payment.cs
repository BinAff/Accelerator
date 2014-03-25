using System.Windows.Forms;
using Facade = Vanilla.Invoice.Facade;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using BinAff.Utility;
using PresentationLibrary = BinAff.Presentation.Library;

namespace Vanilla.Invoice.WinForm
{
    public partial class Payment : Form
    {
        private Facade.Payment.Dto dto;
        private Facade.Payment.FormDto formDto;
        private Facade.Dto invoiceDto;
        private TreeView trvForm;

        public Payment(Facade.Dto invoiceDto, TreeView trvForm)
        {
            InitializeComponent();
            
            this.trvForm = trvForm;
            this.invoiceDto = invoiceDto;
            this.dto = new Facade.Payment.Dto();
            this.formDto = new Facade.Payment.FormDto 
            { 
                dto = this.dto,
                ModuleFormDto = new Vanilla.Utility.Facade.Module.FormDto()
            };

            new Vanilla.Utility.Facade.Module.Server(this.formDto.ModuleFormDto).LoadForm();
            

            this.SetPaymentGridViewSettings();
            this.LoadProductData();
            this.LoadTax();
            this.LoadForm();
        }

        private void LoadProductData()
        {
            for (int i = 0; i < dgvProduct.Columns.Count; i++)
                dgvProduct.Columns[i].ReadOnly = true;

            dgvProduct.Columns[0].DataPropertyName = "Start";
            dgvProduct.Columns[1].DataPropertyName = "End";
            dgvProduct.Columns[2].DataPropertyName = "Description";
            dgvProduct.Columns[3].DataPropertyName = "UnitRate";
            dgvProduct.Columns[4].DataPropertyName = "Count";
            dgvProduct.Columns[5].DataPropertyName = "Total";
            dgvProduct.MultiSelect = false;

            List<Data> invoiceList = new List<Data>();
            Double lineItemTotal = 0;
            foreach (Facade.LineItem.Dto lineItem in this.invoiceDto.productList)
            {
                invoiceList.Add(new Data
                {
                    Start = lineItem.startDate.ToShortDateString(),
                    End = lineItem.endDate.ToShortDateString(),
                    Description = String.Empty,
                    UnitRate = lineItem.unitRate.ToString(),
                    Count = lineItem.count.ToString(),
                    Total = lineItem.total.ToString()
                });
                lineItemTotal += lineItem.total;
            }

            dgvProduct.DataSource = invoiceList;
            txtTotal.Text = lineItemTotal.ToString();
        }

        private void LoadTax()
        {
            List<Tax> taxList = new List<Tax>();
            String taxName = String.Empty;
            Double taxValue = 0;
            Double grandTotal = 0;

            Double total = Convert.ToDouble(txtTotal.Text);
            Double discount = txtDiscount.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtDiscount.Text);
            Double totalToCalculate = total - discount;
            grandTotal = totalToCalculate;

            if (this.invoiceDto.taxationList != null && this.invoiceDto.taxationList.Count > 0)
            {
                foreach (Facade.Taxation.Dto dto in this.invoiceDto.taxationList)
                {
                    taxName = dto.Name;
                    if (dto.isPercentage)
                    {
                        taxName += " (" + dto.Amount + " %)";
                        taxValue = totalToCalculate * (dto.Amount / 100);

                        grandTotal += taxValue;
                    }
                    else
                    {
                        taxValue = dto.Amount;
                        grandTotal += taxValue;
                    }

                    taxList.Add(new Tax 
                    {
                        name = taxName,
                        value = taxValue
                    });                    
                }
            }


            dgvTax.ColumnHeadersVisible = false;
            for (int i = 0; i < dgvTax.Columns.Count; i++)
                dgvTax.Columns[i].ReadOnly = true;

            dgvTax.Columns[0].DataPropertyName = "name";
            dgvTax.Columns[1].DataPropertyName = "value";
                                  
            dgvProduct.MultiSelect = false;
            dgvTax.DataSource = taxList;

            txtGrandTotal.Text = grandTotal.ToString();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            this.LoadTax();
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new Facade.Payment.Server(formDto);
            facade.LoadForm();

            //--populate payment type category
            this.cboPaymentType.DataSource = null;
            if (this.formDto.typeList != null && this.formDto.typeList.Count > 0)
            {
                this.cboPaymentType.DataSource = this.formDto.typeList;
                this.cboPaymentType.ValueMember = "Id";
                this.cboPaymentType.DisplayMember = "Name";
                this.cboPaymentType.SelectedIndex = 0;
            }

            this.txtArtifactPath.ReadOnly = true;
            this.txtArtifactPath.Text = new Vanilla.Utility.Facade.Module.Server(null).GetRootLevelModulePath("INVO", this.formDto.ModuleFormDto.FormModuleList, "Form");

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
            dgvPayment.Columns[3].DataPropertyName = "remark"; ;
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (this.ValidateMakePayment())
            {
                //call crystal invoice
                this.invoiceDto.invoiceNumber = Common.GenerateInvoiceNumber();
                this.invoiceDto.paymentList = dgvPayment.DataSource as List<Facade.Payment.Dto>;
                this.invoiceDto.discount = txtDiscount.Text.Trim() == String.Empty ? 0 : Convert.ToDouble(txtDiscount.Text);
                               
                //Facade.Server facade = new Facade.Server(new Facade.FormDto { dto = invoiceDto });
                //facade.Add();

                this.Tag = this.invoiceDto;
                this.Close();


                //if (facade.IsError)
                //{
                //    //retVal = false;
                //    new PresentationLibrary.MessageBox
                //    {
                //        DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                //        Heading = "Splash",
                //    }.Show(facade.DisplayMessageList);
                //}
                //else
                //{   
                //    this.Tag = this.invoiceDto;
                //    this.Close();                    
                //}
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

    public class Tax
    {
        public String name { get; set; }
        public Double value { get; set; }
    }
}
