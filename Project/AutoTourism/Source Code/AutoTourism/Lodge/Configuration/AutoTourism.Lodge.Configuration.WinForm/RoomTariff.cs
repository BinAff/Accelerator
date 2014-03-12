
//using AutoTourism.Presentation.Library;
//using AutoTourism.Facade.Configuration.Tariff;
//using BinAff.Core;
using BinAff.Utility;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

using PresentationLibrary = BinAff.Presentation.Library;
using ConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

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
                //this.formDto.CategoryList.Insert(0, new LodgeConfigurationFacade.Room.Category.Dto
                //{
                //    Name = "All"
                //});

                this.cboCategory.DataSource = this.formDto.CategoryList;
                this.cboCategory.ValueMember = "Id";
                this.cboCategory.DisplayMember = "Name";
                this.cboCategory.SelectedIndex = -1;
            }

            //--populate room type
            this.cboType.DataSource = null;
            if (this.formDto.TypeList != null && this.formDto.TypeList.Count > 0)
            {
                //this.formDto.TypeList.Insert(0, new LodgeConfigurationFacade.Room.Type.Dto
                //{
                //    Name = "All"
                //});
                this.cboType.DataSource = this.formDto.TypeList;
                this.cboType.ValueMember = "Id";
                this.cboType.DisplayMember = "Name";
                this.cboType.SelectedIndex = -1;
            }

            //ITariff tariff = new TariffServer();
            //ReturnObject<FormDto> ret = tariff.LoadForm();

            ////populate Category List
            //this.cboCategory.DataSource = null;
            //if (ret.Value.CategoryList != null && ret.Value.CategoryList.Count > 0)
            //{
            //    this.cboCategory.DataSource = ret.Value.CategoryList;
            //    this.cboCategory.ValueMember = "Id";
            //    this.cboCategory.DisplayMember = "Name";
            //    this.cboCategory.SelectedIndex = -1;
            //}

            ////populate Type List
            //this.cboType.DataSource = null;
            //if (ret.Value.TypeList != null && ret.Value.TypeList.Count > 0)
            //{
            //    this.cboType.DataSource = ret.Value.TypeList;
            //    this.cboType.ValueMember = "Id";
            //    this.cboType.DisplayMember = "Name";
            //    this.cboType.SelectedIndex = -1;
            //}

            ////populate Tariff Grid
            //if(ret.Value.TariffList != null && ret.Value.TariffList.Count>0)
            //{
            //    dgvTariff.DataSource = ret.Value.TariffList;               
            //    PopulateFormData(ret.Value.TariffList[0]);                
            //}

        }

        //protected override void Clear()
        //{
        //    //base.Clear();
        //}

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
                this.dto.Id = this.dto == null ? 0 : this.dto.Id;
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

                BinAff.Facade.Library.Server facade = new ConfigurationFacade.Tariff.TariffServer(formDto);

                if (operation == "add")
                    facade.Add();
                else
                    facade.Change();

            }

            return retVal;

           

            //if (operation == "change")
            //{
            //    if (dgvTariff.SelectedRows.Count == 0)
            //        return;

            //    tariffDto.Id = ((Dto)dgvTariff.SelectedRows[0].DataBoundItem).Id;

            //}

            //ITariff tariff = new TariffServer();
            //ReturnObject<System.Boolean> ret = tariff.Change(tariffDto);

            //base.ShowMessage(ret); //Show message  

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
            else if (ValidationRule.IsDateLess(dtEndDate.Value, dtStartDate.Value))
            {
                errorProvider.SetError(dtEndDate, "End date cannot be less than start date.");
                dtEndDate.Focus();
                return false;
            }


            return retVal;
        }

        //private void PopulateFormData(Dto dto)
        //{
        //    //highlight category dropdown
        //    for (int i = 0; i < cboCategory.Items.Count; i++)
        //    {
        //        if (dto.Category.Id == ((AutoTourism.Facade.Configuration.RoomCategory.Dto)cboCategory.Items[i]).Id)
        //        {
        //            cboCategory.SelectedIndex = i;
        //            break;
        //        }
        //    }

        //    //highlight type dropdown
        //    for (int i = 0; i < cboType.Items.Count; i++)
        //    {
        //        if (dto.Type.Id == ((AutoTourism.Facade.Configuration.RoomType.Dto)cboType.Items[i]).Id)
        //        {
        //            cboType.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //    chkIsAC.Checked = dto.IsAC;
        //    dtStartDate.Value = dto.StartDate;
        //    dtEndDate.Value = dto.EndDate;
        //    txtRate.Text = dto.Rate == 0 ? string.Empty : Converter.ConvertToIndianCurrency(Convert.ToDecimal(dto.Rate));
        //}

       

        private void rdoAll_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdoAll.Checked)
            //{
            //    ITariff tariff = new TariffServer();
            //    ReturnObject<List<Dto>> ret = tariff.ReadAllTariff();

            //    //populate Tariff Grid
            //    if (ret.Value != null && ret.Value.Count > 0)
            //    {
            //        dgvTariff.DataSource = ret.Value;
                    
            //        PopulateFormData(ret.Value[0]);
            //    }

            //}
        }

        private void rdoCurrent_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdoCurrent.Checked)
            //{
            //    ITariff tariff = new TariffServer();
            //    ReturnObject<List<Dto>> ret = tariff.ReadAllCurrentTariff();

            //    //populate Tariff Grid
            //    if (ret.Value != null && ret.Value.Count > 0)
            //    {
            //        dgvTariff.DataSource = ret.Value;

            //        PopulateFormData(ret.Value[0]);
            //    }

            //}

        }

        private void rdoFuture_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdoFuture.Checked)
            //{
            //    ITariff tariff = new TariffServer();
            //    ReturnObject<List<Dto>> ret = tariff.ReadAllFutureTariff();

            //    //populate Tariff Grid
            //    if (ret.Value != null && ret.Value.Count > 0)
            //    {
            //        dgvTariff.DataSource = ret.Value;

            //        PopulateFormData(ret.Value[0]);
            //    }

            //}

        }

        private void dgvTariff_SelectionChanged(object sender, System.EventArgs e)
        {            
            //if (dgvTariff.SelectedRows.Count > 0)
            //    PopulateFormData((Dto)dgvTariff.SelectedRows[0].DataBoundItem);
        }

       

     
    }
}
