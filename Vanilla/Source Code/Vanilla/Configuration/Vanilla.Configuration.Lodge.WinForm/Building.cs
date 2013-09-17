using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//using BinAff.Core;
//using BinAff.Utility;

//using AutoTourism.Presentation.Library;

//using AutoTourism.Facade.Configuration.Building;

namespace AutoTourism.Configuration
{

    public partial class Building : Form
    {
        public enum BuildingStatus
        { 
            Open = 10001,
            Close = 10002
        }


        public Building()
        {
            InitializeComponent();
        }

        //private AutoTourism.Facade.UserManagement.User.Dto userDto = null;

        //public Building(AutoTourism.Facade.UserManagement.User.Dto userDto)
        //{
        //    InitializeComponent();

        //    this.userDto = userDto;
        //    base.IsMinimizeBox = false;
        //    base.IsOpenButton = true;
        //    base.IsCloseButton = true;
        //}

        private void Building_Load(object sender, System.EventArgs e)
        {
            LoadForm();
            Clear();
        }

        protected override void btnAdd_Click(object sender, System.EventArgs e)
        {
            //if (ValidateUser())
            //{
            //    Dto buildingDto = new Dto()
            //    {
            //        Name = txtName.Text.Trim(),
            //        Floor = (List<Int32>)lstFloorList.DataSource,
            //        Type = (AutoTourism.Facade.Configuration.BuildingType.Dto)this.cboType.SelectedItem,
            //        DefaultFloor = Convert.ToInt32(this.cboFloor.SelectedItem),
            //        IsDefault = chkDefault.Checked
            //    };

            //    if (!ValidateUnique(buildingDto) && OverWriteDefaultIfExists(buildingDto))
            //    {
            //        IBuilding building = new BuildingServer();
            //        ReturnObject<Boolean> ret = building.Add(buildingDto);

            //        base.ShowMessage(ret); //Show message     
            //    }
            //}
        }

        protected override void btnChange_Click(object sender, EventArgs e)
        {
            //if (this.cboBuildingList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one building", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //if (ValidateUser())
            //{
            //    Dto buildingDto = new Dto()
            //    {
            //        Id = ((Dto)this.cboBuildingList.SelectedItem).Id,
            //        Name = txtName.Text.Trim(),
            //        Floor = (List<Int32>)lstFloorList.DataSource,
            //        Type = (AutoTourism.Facade.Configuration.BuildingType.Dto)this.cboType.SelectedItem,
            //        DefaultFloor = Convert.ToInt32(this.cboFloor.SelectedItem),
            //        IsDefault = chkDefault.Checked,
            //    };

            //    if (!ValidateUnique(buildingDto) && OverWriteDefaultIfExists(buildingDto))
            //    {
            //        IBuilding building = new BuildingServer();
            //        ReturnObject<Boolean> ret = building.Change(buildingDto);

            //        base.ShowMessage(ret); //Show message                    
            //    }

            //}
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            //if (this.cboBuildingList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one building.", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the building.?", "Building Delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //{

            //    IBuilding building = new BuildingServer();
            //    ReturnObject<Boolean> ret = building.Delete(new Dto()
            //    {
            //        Id = ((Dto)this.cboBuildingList.SelectedItem).Id
            //    });

            //    base.ShowMessage(ret); //Show message
            //}
            //else Clear();
        }

        protected override void btnRefresh_Click(object sender, EventArgs e)
        {
            //LoadForm();
            //Clear();
        }

        private void bttnAddContact_Click(object sender, EventArgs e)
        {
            //errorProvider.Clear();

            //ReturnObject<List<Int32>> retObj;
            //if (txtFloor.Text.Trim() != String.Empty)
            //{
            //    if (ValidationRule.IsInteger(txtFloor.Text.Trim()))
            //    {
            //        retObj = GetFloorList(Convert.ToInt32(txtFloor.Text.Trim()), (List<Int32>)lstFloorList.DataSource);
            //        if (retObj.HasError())
            //            errorProvider.SetError(txtFloor, "Entered floor already exists.");
            //        else
            //        {
            //            lstFloorList.DataSource = null;
            //            lstFloorList.DataSource = retObj.Value;
            //            lstFloorList.SelectedIndex = -1;

            //            //populate Default floor
            //            List<Int32> DefaultFloorList = new List<Int32>();
            //            foreach (Int32 dFloor in retObj.Value)
            //            {
            //                DefaultFloorList.Add(dFloor);
            //            }
            //            cboFloor.DataSource = null;
            //            cboFloor.DataSource = DefaultFloorList;
            //        }
            //        txtFloor.Text = String.Empty;
            //    }
            //    else
            //        errorProvider.SetError(txtFloor, "Please enter integer values.");
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<Int32> retList = new List<Int32>();
            List<Int32> FloorList = (List<Int32>)lstFloorList.DataSource;
            Boolean blnAdd = true;
            if (FloorList != null && lstFloorList.SelectedItems.Count > 0)
            {
                foreach (Int32 iFloor in FloorList)
                {
                    foreach (Int32 selFloor in lstFloorList.SelectedItems)
                    {
                        if (iFloor == selFloor)
                        {
                            blnAdd = false;
                            break;
                        }
                    }
                    if (blnAdd)
                        retList.Add(iFloor);

                    blnAdd = true;
                }

                lstFloorList.DataSource = null;
                lstFloorList.DataSource = retList;
                lstFloorList.SelectedIndex = -1;

                //populate Default floor
                List<Int32> DefaultFloorList = new List<Int32>();
                foreach (Int32 dFloor in retList)
                {
                    DefaultFloorList.Add(dFloor);
                }
                cboFloor.DataSource = null;
                cboFloor.DataSource = DefaultFloorList;
            }
        }

        private void cboBuildingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cboBuildingList.SelectedIndex != -1)
            //{
            //    Dto data = (Dto)this.cboBuildingList.SelectedItem;
            //    txtName.Text = data.Name;
            //    chkDefault.Checked = data.IsDefault;

            //    lstFloorList.DataSource = data.Floor;
            //    lstFloorList.SelectedIndex = -1;

            //    for (int i = 0; i < cboType.Items.Count; i++)
            //    {
            //        if (data.Type.Id == ((AutoTourism.Facade.Configuration.BuildingType.Dto)cboType.Items[i]).Id)
            //        {
            //            cboType.SelectedIndex = i;
            //            break;
            //        }
            //    }

            //    //populate Default floor
            //    if (data.Floor != null)
            //    {
            //        List<Int32> DefaultFloorList = new List<Int32>();
            //        foreach (Int32 dFloor in data.Floor)
            //        {
            //            DefaultFloorList.Add(dFloor);
            //        }
            //        cboFloor.DataSource = null;
            //        cboFloor.DataSource = DefaultFloorList;
            //        cboFloor.SelectedItem = data.DefaultFloor;
            //    }
            //}
        }

        protected override void btnClose_Click(object sender, EventArgs e)
        {
            //if (this.cboBuildingList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one building.", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //Facade.Configuration.Building.Dto dto = (Facade.Configuration.Building.Dto)this.cboBuildingList.SelectedItem;
            //if (dto.Status.Id == Convert.ToInt64(BuildingStatus.Close))
            //{
            //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>() { 
            //        Value = true,
            //        MessageList = new List<Message>(),
            //    };
            //    ret.MessageList.Add(new Message("Building is already closed.", Message.Type.Information));
            //    base.ShowMessage(ret);
            //}
            //else
            //{
            //    new ReasonDialog(Convert.ToString(EnumDefination.FormName.Building), this.userDto, dto.Id,0).ShowDialog(this);

            //    LoadForm();
            //    Clear();
            //}
        }

        protected override void btnOpen_Click(object sender, EventArgs e)
        {
            //if (this.cboBuildingList.SelectedIndex == -1)
            //{
            //    //Show message
            //    new MessageBox("Please select one building.", MessageBox.Type.Alert).ShowDialog(this);
            //    return;
            //}

            //if (((Dto)this.cboBuildingList.SelectedItem).Status.Id != Convert.ToInt64(BuildingStatus.Close))
            //{
            //    new MessageBox("Unable to open building. Only closed buildings can be opened", MessageBox.Type.Error).ShowDialog(this);//Show message
            //    return;
            //}
           
            //Facade.Configuration.Building.Dto dto = (Facade.Configuration.Building.Dto)this.cboBuildingList.SelectedItem;
            //if (dto.Status.Id == Convert.ToInt64(BuildingStatus.Open))
            //{
            //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>()
            //    {
            //        Value = true,
            //        MessageList = new List<Message>(),
            //    };
            //    ret.MessageList.Add(new Message("Building is already open.", Message.Type.Information));
            //    base.ShowMessage(ret);
            //}
            //else
            //{
            //    IBuilding building = new BuildingServer();
            //    ReturnObject<Boolean> ret = building.Open(new Dto()
            //    {
            //        Id = ((Dto)this.cboBuildingList.SelectedItem).Id,
            //    });

            //    base.ShowMessage(ret);
            //    LoadForm();
            //    Clear();

            //}
        }

        protected override void LoadForm()
        {
            //IBuilding building = new BuildingServer();
            //ReturnObject<FormDto> ret = building.LoadForm();

            ////Populate Floor List
            //this.cboBuildingList.DataSource = ret.Value.BuildingList;
            //this.cboBuildingList.DisplayMember = "Name";
            //this.cboBuildingList.ValueMember = "Id";
            //this.cboBuildingList.SelectedIndex = -1;

            ////populate Type List
            //this.cboType.DataSource = ret.Value.TypeList;
            //this.cboType.DisplayMember = "Name";
            //this.cboType.ValueMember = "Id";
        }

        protected override void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtFloor.Text = String.Empty;
            this.lstFloorList.DataSource = null;
            this.cboFloor.DataSource = null;
            this.chkDefault.Checked = false;
        }

        //private Boolean ValidateUnique(Dto data)
        //{
        //    List<Dto> list = (List<Dto>)this.cboBuildingList.DataSource;
        //    foreach (Dto dto in list)
        //    {
        //        if (dto.Name.ToUpper() == txtName.Text.Trim().ToUpper() && dto.Id != data.Id)
        //        {
        //            //Show message // TO DO :: Need to change
        //            new MessageBox("Building already exists.", MessageBox.Type.Information).ShowDialog(this);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private Boolean OverWriteDefaultIfExists(Dto data)
        //{
        //    if (chkDefault.Checked)
        //    {
        //        List<Dto> list = (List<Dto>)this.cboBuildingList.DataSource;
        //        foreach (Dto dto in list)
        //        {
        //            if (dto.Id != data.Id && dto.IsDefault)
        //            {
        //                //Show message
        //                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Default already exists. Do you want to overwrite.", "Alert", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
        //                if (result == System.Windows.Forms.DialogResult.Yes)
        //                    return true;
        //                else
        //                    return false;
        //            }
        //        }

        //        if (data.IsDefault) return true;

        //        return false;
        //    }
        //    return true;
        //}

        private Boolean ValidateUser()
        {
            Boolean retVal = true;
            errorProvider.Clear();

            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider.SetError(txtName, "Please enter building name.");
                txtName.Focus();
                return false;
            }
            else if (!(new Regex(@"^[a-zA-Z_0-9 ]*$").IsMatch(txtName.Text.Trim())))
            {
                errorProvider.SetError(txtName, "Entered " + txtName.Text + " is Invalid.");
                txtName.Focus();
                return false;
            }
            else if (lstFloorList.Items.Count == 0)
            {
                errorProvider.SetError(lstFloorList, "Please enter floor(s).");
                txtFloor.Focus();
                return false;
            }
            else if (this.cboType.DataSource == null)
            {
                errorProvider.SetError(cboType, "Please select building type.");
                return false;
            }

            return retVal;
        }

        //private ReturnObject<List<Int32>> GetFloorList(Int32 val, List<Int32> floor)
        //{
        //    ReturnObject<List<Int32>> retObj = new ReturnObject<List<int>>()
        //    {
        //        Value = new List<Int32>()
        //    };

        //    if (floor == null || floor.Count == 0)
        //        retObj.Value.Add(val);
        //    else
        //    {
        //        foreach (Int32 i in floor)
        //        {
        //            if (i == val)
        //            {
        //                retObj.Value = floor;

        //                retObj.MessageList = new List<BinAff.Core.Message>();
        //                retObj.MessageList.Add(new BinAff.Core.Message()
        //                {
        //                    Description = "Duplicate",
        //                    Category = BinAff.Core.Message.Type.Error
        //                });
        //                return retObj;
        //            }
        //        }
        //        floor.Add(val);
        //        retObj.Value = floor;
        //    }

        //    return retObj;
        //}

    }

}
