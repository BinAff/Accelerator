using System.Collections.Generic;
using System;
using System.Linq;

using BinAff.Core;
using BinAff.Utility;
using BinAff.Presentation.Library.Extension;
using PresLib = BinAff.Presentation.Library;

using ConfFac = Retinue.Lodge.Configuration.Facade;
using CatFac = Retinue.Lodge.Configuration.Facade.Room.Category;
using TypeFac = Retinue.Lodge.Configuration.Facade.Room.Type;

namespace Retinue.Lodge.Configuration.WinForm
{

    public partial class RoomTariff : PresLib.Form
    {

        private Configuration.Facade.Tariff.FormDto formDto;

        public RoomTariff()
        {
            InitializeComponent();
        }

        private void RoomTariff_Load(object sender, EventArgs e)
        {
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dgvTariff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < dgvTariff.Columns.Count; i++) this.dgvTariff.Columns[i].ReadOnly = true;
            this.dgvTariff.MultiSelect = false;
            this.dgvTariff.Columns[0].DataPropertyName = "CategoryText";
            this.dgvTariff.Columns[1].DataPropertyName = "TypeText";
            this.dgvTariff.Columns[2].DataPropertyName = "IsACText";
            this.dgvTariff.Columns[3].DataPropertyName = "StartDate";
            this.dgvTariff.Columns[4].DataPropertyName = "EndDate";
            this.dgvTariff.Columns[5].DataPropertyName = "IsExtraText";
            this.dgvTariff.Columns[6].DataPropertyName = "RateText";
            this.dgvTariff.AutoGenerateColumns = false;

            this.formDto = new Facade.Tariff.FormDto
            {
                Dto = new Facade.Tariff.Dto(),
            };
            this.LoadForm();
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new Configuration.Facade.Tariff.TariffServer(this.formDto);
            facade.LoadForm();

            this.cboCategory.Bind(this.formDto.CategoryList, "Name");
            this.cboType.Bind(this.formDto.TypeList, "Name");
            this.rdoCurrent.Checked = true;
            this.dgvTariff.DataSource = this.formDto.TariffList;
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
                this.formDto.Dto.Category = this.cboCategory.SelectedItem as CatFac.Dto;
                this.formDto.Dto.Type = this.cboType.SelectedItem as TypeFac.Dto;
                this.formDto.Dto.IsAC = this.chkIsAC.Checked;
                this.formDto.Dto.StartDate = this.dtStartDate.Value;
                this.formDto.Dto.EndDate = this.dtEndDate.Value;
                this.formDto.Dto.IsExtra = this.chkIsExtraBed.Checked;
                this.formDto.Dto.Rate = Convert.ToDouble(txtRate.Text);

                BinAff.Facade.Library.Server facade = new ConfFac.Tariff.TariffServer(formDto);

                if (operation == "add")
                {
                    facade.Add();
                }
                else
                {
                    this.formDto.Dto.Id = (dgvTariff.SelectedRows[0].DataBoundItem as ConfFac.Tariff.Dto).Id;
                    facade.Change();
                }
                             
                new PresLib.MessageBox
                {
                    DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
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
            //this.cboCategory.SelectedItem = dto.Category;
            for (int i = 0; i < cboCategory.Items.Count; i++)
            {
                if (dto.Category.Id == ((ConfFac.Room.Category.Dto)cboCategory.Items[i]).Id)
                {
                    cboCategory.SelectedIndex = i;
                    break;
                }
            }

            //highlight type dropdown
            //this.cboType.SelectedItem = dto.Type;
            for (Int32 i = 0; i < cboType.Items.Count; i++)
            {
                if (dto.Type.Id == ((ConfFac.Room.Type.Dto)cboType.Items[i]).Id)
                {
                    cboType.SelectedIndex = i;
                    break;
                }
            }

            this.chkIsAC.Checked = dto.IsAC;
            this.dtStartDate.Value = dto.StartDate;
            this.dtEndDate.Value = dto.EndDate;
            this.chkIsExtraBed.Checked = dto.IsExtra;
            this.txtRate.Text = dto.RateText;
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
                this.PopulateFormData(dgvTariff.SelectedRows[0].DataBoundItem as ConfFac.Tariff.Dto);
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
                    tariffId = (dgvTariff.SelectedRows[0].DataBoundItem as ConfFac.Tariff.Dto).Id;
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
            this.formDto.TariffList = ret.Value;

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
                        if ((dgvTariff.Rows[i].DataBoundItem as ConfFac.Tariff.Dto).Id == tariffId)
                        {
                            dgvTariff.Rows[i].Selected = true;
                            tariffDto = dgvTariff.Rows[i].DataBoundItem as ConfFac.Tariff.Dto; 
                            break;
                        }
                    }
                }

                PopulateFormData(tariffDto);
            }
        }
        
    }

}