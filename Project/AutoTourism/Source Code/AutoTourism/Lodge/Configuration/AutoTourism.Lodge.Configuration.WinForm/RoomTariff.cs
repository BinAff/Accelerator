using BinAff.Utility;
using System.Collections.Generic;
using System;

using BinAff.Core;
using PresentationLibrary = BinAff.Presentation.Library;

using ConfFac = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class RoomTariff : PresentationLibrary.Form
    {

        private Configuration.Facade.Tariff.Dto dto;
        private Configuration.Facade.Tariff.FormDto formDto;

        public RoomTariff()
        {
            InitializeComponent();
            
            dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            //dgvTariff
            dgvTariff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < dgvTariff.Columns.Count; i++) dgvTariff.Columns[i].ReadOnly = true;
            dgvTariff.MultiSelect = false;

            dgvTariff.Columns[0].DataPropertyName = "CategoryText";
            dgvTariff.Columns[1].DataPropertyName = "TypeText";
            dgvTariff.Columns[2].DataPropertyName = "IsACText";
            dgvTariff.Columns[3].DataPropertyName = "StartDate";
            dgvTariff.Columns[4].DataPropertyName = "EndDate";
            dgvTariff.Columns[5].DataPropertyName = "RateText";

            dgvTariff.AutoGenerateColumns = false;

            this.dto = new Facade.Tariff.Dto();
            this.formDto = new Facade.Tariff.FormDto { dto = this.dto };
            LoadForm();
            //Clear();

            rdoCurrent.Checked = true;
            //base.IsDeleteButton = false;
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new Configuration.Facade.Tariff.TariffServer(formDto);
            facade.LoadForm();

            //--populate room category
            this.cboCategory.DataSource = null;
            if (this.formDto.CategoryList != null && this.formDto.CategoryList.Count > 0)
            {
                this.cboCategory.DataSource = this.formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = -1;
            }

            //--populate room type
            this.cboType.DataSource = null;
            if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
            {
                this.cboType.DataSource = this.formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = -1;
            }
            
            //populate Tariff Grid
            if (this.formDto.TariffList != null && this.formDto.TariffList.Count > 0)
            {
                dgvTariff.DataSource = this.formDto.TariffList;
                PopulateFormData(this.formDto.TariffList[0]);   
            }
        }
             
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save("add");         
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Save("change");
        }

        private Boolean Save(string operation)
        {
            Boolean retVal = this.ValidateTariff(operation);

            if (retVal)
            {
                if (this.dto == null) this.dto = new Facade.Tariff.Dto();                
                this.dto.Category = new Facade.Room.Category.Dto { Id = ((Facade.Room.Category.Dto)cboCategory.SelectedItem).Id };
                this.dto.Type = new Facade.Room.Type.Dto { Id = ((Facade.Room.Type.Dto)cboType.SelectedItem).Id };
                this.dto.IsAC = chkIsAC.Checked;
                this.dto.StartDate = dtStartDate.Value;
                this.dto.EndDate = dtEndDate.Value;
                this.dto.Rate = System.Convert.ToDouble(txtRate.Text);

                Facade.Tariff.FormDto formDto = new Facade.Tariff.FormDto 
                { 
                    dto = this.dto
                };

                BinAff.Facade.Library.Server facade = new ConfFac.Tariff.TariffServer(formDto);

                if (operation == "add")
                {
                    facade.Add();
                }
                else
                {
                    this.dto.Id = ((ConfFac.Tariff.Dto)dgvTariff.SelectedRows[0].DataBoundItem).Id;
                    facade.Change();
                }
                             
                new PresentationLibrary.MessageBox
                {
                    DialogueType = facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);

                if (!facade.IsError)
                {
                    this.RadioChange(operation);
                }
            }
            return retVal;
        }

        private System.Boolean ValidateTariff(string operation)
        {
            System.Boolean retVal = true;
            errorProvider.Clear();
           
            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategory, "Please select a category.");
                cboCategory.Focus();
                return false;
            }
            else if (cboType.SelectedIndex == -1)
            {
                errorProvider.SetError(cboType, "Please select a type.");
                cboType.Focus();
                return false;
            }
            else if (System.String.IsNullOrEmpty(txtRate.Text))
            {
                errorProvider.SetError(txtRate, "Please enter the rate.");
                txtRate.Focus();
                return false;
            }
            else if (!ValidationRule.IsDecimal(txtRate.Text.Trim().Replace(",", "")))
            {
                errorProvider.SetError(txtRate, "Entered " + txtRate.Text + " is Invalid.");
                txtRate.Focus();
                return false;
            }
            else if (operation == "add" && ValidationRule.IsDateLessThanToday(dtStartDate.Value))
            {
                errorProvider.SetError(dtStartDate, "Start date cannot be less than today.");
                dtStartDate.Focus();
                return false;
            }
            else if (operation == "change" && dtEndDate.Value < System.DateTime.Today.AddDays(-1))
            {
                errorProvider.SetError(dtEndDate, "End date cannot be less than previous day.");
                dtEndDate.Focus();
                return false;
            }
            else if (operation == "change" && dgvTariff.SelectedRows.Count == 0)
            {
                errorProvider.SetError(dgvTariff, "Select a row in the grid to change.");
                dgvTariff.Focus();
                return false;

            }
            else if (ValidationRule.IsDateLess(dtEndDate.Value, dtStartDate.Value))
            {
                errorProvider.SetError(dtEndDate, "End date cannot be less than start date.");
                dtEndDate.Focus();
                return false;
            }
            return retVal;
        }

        private void PopulateFormData(ConfFac.Tariff.Dto dto)
        {       

            //highlight category dropdown
            for (int i = 0; i < cboCategory.Items.Count; i++)
            {
                if (dto.Category.Id == ((ConfFac.Room.Category.Dto)cboCategory.Items[i]).Id)
                {
                    cboCategory.SelectedIndex = i;
                    break;
                }
            }

            //highlight type dropdown
            for (int i = 0; i < cboType.Items.Count; i++)
            {
                if (dto.Type.Id == ((ConfFac.Room.Type.Dto)cboType.Items[i]).Id)
                {
                    cboType.SelectedIndex = i;
                    break;
                }
            }

            chkIsAC.Checked = dto.IsAC;
            dtStartDate.Value = dto.StartDate;
            dtEndDate.Value = dto.EndDate;
            txtRate.Text = dto.Rate == 0 ? string.Empty : Converter.ConvertToIndianCurrency(Convert.ToDecimal(dto.Rate));
        }

        private void rdoAll_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RadioChange("all");           
        }

        private void rdoCurrent_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RadioChange("current");
        }

        private void rdoFuture_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RadioChange("future");
        }

        private void dgvTariff_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvTariff.SelectedRows.Count > 0)
            {
                PopulateFormData((ConfFac.Tariff.Dto)dgvTariff.SelectedRows[0].DataBoundItem);
            }
        }

        private void RadioChange(String source)
        {
            ConfFac.Tariff.ITariff tariff = new ConfFac.Tariff.TariffServer(this.formDto);
            ReturnObject<List<ConfFac.Tariff.Dto>> ret = new ReturnObject<List<ConfFac.Tariff.Dto>>();

            Int64 tariffId = 0;
            Boolean isSelectIndexRequired = false;
            if (source == "add" || source == "change")
            {
                if (source == "change")
                {
                    tariffId = ((ConfFac.Tariff.Dto)dgvTariff.SelectedRows[0].DataBoundItem).Id;
                    isSelectIndexRequired = true;
                }
                if (rdoAll.Checked)
                {
                    source = "all";
                }
                else if (rdoCurrent.Checked)
                {
                    source = "current";
                }
                else if (rdoFuture.Checked)
                {
                    source = "future";
                }
            }

            switch (source)
            {
                case "all":
                    ret = tariff.ReadAllTariff();
                    break;
                case "current":
                    ret = tariff.ReadAllCurrentTariff();
                    break;
                case "future":
                    ret = tariff.ReadAllFutureTariff();
                    break;
            }

            //populate Tariff Grid
            if (ret.Value != null && ret.Value.Count > 0)
            {
                dgvTariff.DataSource = null;
                dgvTariff.DataSource = ret.Value;
                ConfFac.Tariff.Dto tariffDto = ret.Value[0];

                if (isSelectIndexRequired)
                {
                    for (int i = 0; i < dgvTariff.RowCount; i++)
                    {
                        if (((ConfFac.Tariff.Dto)dgvTariff.Rows[i].DataBoundItem).Id == tariffId)
                        {
                            dgvTariff.Rows[i].Selected = true;
                            tariffDto = (ConfFac.Tariff.Dto)dgvTariff.Rows[i].DataBoundItem; 
                            break;
                        }
                    }
                }

                PopulateFormData(tariffDto);
            }
        }
        
    }

}
