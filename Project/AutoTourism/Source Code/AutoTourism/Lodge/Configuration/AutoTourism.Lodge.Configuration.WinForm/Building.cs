using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Utility;
using PresentationLibrary = BinAff.Presentation.Library;

using FacadeBuilding = AutoTourism.Lodge.Configuration.Facade.Building;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class Building : Form
    {

        FacadeBuilding.FormDto formDto;
        
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.formDto.Dto = new FacadeBuilding.Dto();
            this.CreateDto();
            if (!this.ValidateAndShowMessage()) return;
            if(IsExist())
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash"
                }.Show("Duplicate entry.");
                this.cboBuildingList.SelectedIndex = -1;
            }
            else
            {
                this.formDto.Dto.Action = BinAff.Facade.Library.Dto.ActionType.Create;
                BinAff.Facade.Library.Server building = new FacadeBuilding.Server(this.formDto);
                building.Add();
                new PresentationLibrary.MessageBox
                {
                    DialogueType = building.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(building.DisplayMessageList);

                LoadForm();
                Clear();
            }
        }        
        
        private void btnChange_Click(object sender, EventArgs e)
        {
            //Change is deleting closer reason. Need to fix that
            if (!this.ValidateAndShowMessage()) return;
            if (IsExist())
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash"
                }.Show("Duplicate entry.");
            }
            else
            {
                this.CreateDto();
                this.formDto.Dto.Action = BinAff.Facade.Library.Dto.ActionType.Update;
                BinAff.Facade.Library.Server building = new FacadeBuilding.Server(this.formDto);
                building.Change();
                new PresentationLibrary.MessageBox
                {
                    DialogueType = building.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(building.DisplayMessageList);

                this.LoadForm();
                this.Clear();
            }
        }

        private void CreateDto()
        {
            this.formDto.Dto.Name = txtName.Text.Trim();
            this.formDto.Dto.Type = (FacadeBuilding.Type.Dto)this.cboType.SelectedItem;
            this.formDto.Dto.FloorList = (List<Table>)lstFloorList.DataSource;
            this.formDto.Dto.Status = new Table
            {
                Id = Convert.ToInt64(BuildingStatus.Open)
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.cboBuildingList.SelectedIndex == -1)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                }.Show("Please select one building.");
                return;
            }

            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the building?", "Building Delete",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                BinAff.Facade.Library.Server building = new FacadeBuilding.Server(this.formDto);
                this.formDto.Dto = new FacadeBuilding.Dto
                {
                    Id = ((FacadeBuilding.Dto)this.cboBuildingList.SelectedItem).Id
                };
                building.Delete();

                new PresentationLibrary.MessageBox
                {
                    DialogueType = building.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                    Heading = "Splash",
                }.Show(building.DisplayMessageList);
            }
            this.LoadForm();
            this.Clear();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadForm();
            this.Clear();
        }

        private void bttnAddContact_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            ReturnObject<List<Table>> retObj;
            if (txtFloor.Text.Trim() != String.Empty)
            {
                if (ValidationRule.IsInteger(txtFloor.Text.Trim()))
                {
                    retObj = GetFloorList(txtFloor.Text.Trim(), (List<Table>)lstFloorList.DataSource);
                    if (retObj.HasError())
                    {
                        errorProvider.SetError(txtFloor, "Entered floor already exists.");
                    }
                    else
                    {
                        lstFloorList.DataSource = null;
                        lstFloorList.DataSource = retObj.Value;
                        lstFloorList.DisplayMember = "Name";
                        lstFloorList.ValueMember = "Id";
                        lstFloorList.SelectedIndex = -1;

                        //populate Default floor
                        //List<Int32> DefaultFloorList = new List<Int32>();
                        //foreach (Int32 dFloor in retObj.Value)
                        //{
                        //    DefaultFloorList.Add(dFloor);
                        //}
                        //cboFloor.DataSource = null;
                        //cboFloor.DataSource = DefaultFloorList;
                    }
                    txtFloor.Text = String.Empty;
                }
                else
                {
                    errorProvider.SetError(txtFloor, "Please enter integer values.");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<Table> retList = new List<Table>();
            List<Table> FloorList = (List<Table>)lstFloorList.DataSource;
            Boolean blnAdd = true;
            if (FloorList != null && lstFloorList.SelectedItems.Count > 0)
            {
                foreach (Table iFloor in FloorList)
                {
                    foreach (Table selFloor in lstFloorList.SelectedItems)
                    {
                        if (iFloor.Name == selFloor.Name)
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
                lstFloorList.DisplayMember = "Name";
                lstFloorList.ValueMember = "Id";
                lstFloorList.SelectedIndex = -1;

                //populate Default floor
                //List<Int32> DefaultFloorList = new List<Int32>();
                //foreach (Int32 dFloor in retList)
                //{
                //    DefaultFloorList.Add(dFloor);
                //}
                //cboFloor.DataSource = null;
                //cboFloor.DataSource = DefaultFloorList;
            }
        }

        private void cboBuildingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboBuildingList.SelectedIndex != -1)
            {
                this.formDto.Dto = this.formDto.DtoList.FindLast((p) => p == this.cboBuildingList.SelectedItem as FacadeBuilding.Dto);
                txtName.Text = this.formDto.Dto.Name;

                lstFloorList.DataSource = this.formDto.Dto.FloorList;
                lstFloorList.DisplayMember = "Name";
                lstFloorList.ValueMember = "Id";
                lstFloorList.SelectedIndex = -1;

                //Int64 typeId = this.formDto.Dto.Type.Id;
                //cboType.SelectedIndex = (this.formDto.TypeList.FindLastIndex(p => p.Id == typeId));

                for (int i = 0; i < cboType.Items.Count; i++)
                {
                    if (this.formDto.Dto.Type.Id == ((FacadeBuilding.Type.Dto)cboType.Items[i]).Id)
                    {
                        cboType.SelectedIndex = i;
                        break;
                    }
                }

                lblStatus.Text = this.formDto.Dto.Status == null ? String.Empty : this.formDto.Dto.Status.Name;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.cboBuildingList.SelectedIndex == -1)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                }.Show("Please select one building.");
                return;
            }

            if ((this.cboBuildingList.SelectedItem as FacadeBuilding.Dto).Status.Id == Convert.ToInt64(BuildingStatus.Close))
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show("Building is already closed.");
            }
            else
            {
                //todo : userInfo Dto needs to be populated
                new ReasonDialog("Building", this.formDto.Dto, null).ShowDialog(this);

                LoadForm();
                Clear();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.cboBuildingList.SelectedIndex == -1)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                    Heading = "Splash",
                }.Show("Please select one building.");
                return;
            }

            this.formDto.Dto = (FacadeBuilding.Dto)this.cboBuildingList.SelectedItem;
            if (this.formDto.Dto.Status.Id == Convert.ToInt64(BuildingStatus.Open))
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                    Heading = "Splash",
                }.Show("Building is already open.");
                return;
            }

            if ((this.cboBuildingList.SelectedItem as FacadeBuilding.Dto).Status.Id != Convert.ToInt64(BuildingStatus.Close))
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show("Unable to open building. Only closed buildings can be opened.");
                return;
            }

            FacadeBuilding.IBuilding building = new FacadeBuilding.Server(this.formDto);
            building.Open();
            new PresentationLibrary.MessageBox
            {
                DialogueType = PresentationLibrary.MessageBox.Type.Alert,
                Heading = "Splash",
            }.Show((building as FacadeBuilding.Server).DisplayMessageList);

            LoadForm();
            Clear();
        }

        private void LoadForm()
        {
            this.formDto = new FacadeBuilding.FormDto
            {
                Dto = new FacadeBuilding.Dto
                {
                    FloorList = new List<Table>(),
                },
                DtoList = new List<FacadeBuilding.Dto>(),
                TypeList = new List<FacadeBuilding.Type.Dto>(),
            };
            BinAff.Facade.Library.Server facade = new FacadeBuilding.Server(this.formDto);
            facade.LoadForm();

            //Show message
            if (facade.IsError)
            {
                new PresentationLibrary.MessageBox
                {
                    DialogueType = PresentationLibrary.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
            }
            else
            {
                //Populate Building List
                this.cboBuildingList.DataSource = this.formDto.DtoList;
                this.cboBuildingList.DisplayMember = "Name";
                this.cboBuildingList.ValueMember = "Id";
                this.cboBuildingList.SelectedIndex = -1;

                //populate Type List
                this.cboType.DataSource = this.formDto.TypeList;
                this.cboType.DisplayMember = "Name";
                this.cboType.ValueMember = "Id";
            }
        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtFloor.Text = String.Empty;
            this.lstFloorList.DataSource = null;
            this.cboBuildingList.SelectedIndex = -1;
            //this.cboFloor.DataSource = null;
            //this.chkDefault.Checked = false;
        }

        private Boolean IsExist()
        {
            FacadeBuilding.Dto dto = this.formDto.DtoList.FindLast((p) => String.Compare(p.Name, txtName.Text.Trim(), true) == 0 && p.Id != this.formDto.Dto.Id);
            return (dto != null);
        }

        //private Boolean OverWriteDefaultIfExists(FacadeBuilding.Dto data)
        //{
        //    if (chkDefault.Checked)
        //    {
        //        List<FacadeBuilding.Dto> list = (List<FacadeBuilding.Dto>)this.cboBuildingList.DataSource;
        //        foreach (FacadeBuilding.Dto dto in list)
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

        private Boolean ValidateAndShowMessage()
        {
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

            return true;
        }

        private ReturnObject<List<Table>> GetFloorList(String val, List<Table> floor)
        {
            ReturnObject<List<Table>> retObj = new ReturnObject<List<Table>>()
            {
                Value = new List<Table>()
            };

            if (floor == null || floor.Count == 0)
                retObj.Value.Add(new Table { Name = val });
            else
            {
                foreach (Table i in floor)
                {
                    if (Convert.ToInt32(i.Name) == Convert.ToInt32(val))
                    {                        
                        retObj.Value = floor;

                        retObj.MessageList = new List<BinAff.Core.Message>();
                        retObj.MessageList.Add(new BinAff.Core.Message()
                        {
                            Description = "Duplicate",
                            Category = BinAff.Core.Message.Type.Error
                        });
                        return retObj;
                    }
                }
                floor.Add(new Table { Name = val });
                retObj.Value = floor;
            }

            return retObj;
        }

        //private List<Table> ConvertFloorListToTable(List<Int32> floorList)
        //{
        //    List<Table> retFloorList = new List<Table>();
        //    if (floorList != null && floorList.Count > 0)
        //    {
        //        foreach (Int32 i in floorList)
        //            retFloorList.Add(new Table() { 
        //                Name = i.ToString()
        //            });
        //    }

        //    return retFloorList;
        //}
        public enum BuildingStatus
        {
            Open = 10001,
            Close = 10002
        }
    }

}
