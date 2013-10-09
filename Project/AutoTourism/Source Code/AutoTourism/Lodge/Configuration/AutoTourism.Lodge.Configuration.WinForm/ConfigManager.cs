using System;
using System.Windows.Forms;

using BinAff.Core;

using BuildingTypeFacade = AutoTourism.Lodge.Configuration.Facade.Building.Type;
using FacadeRoom = AutoTourism.Lodge.Configuration.Facade.Room;
using PresentationLibrary = BinAff.Presentation.Library;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class ConfigManager : Form
    {

        private BuildingTypeFacade.FormDto buildingTypeFormDto;

        public ConfigManager()
        {
            InitializeComponent();
            buildingTypeFormDto = new BuildingTypeFacade.FormDto();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            this.Clear();
            this.LoadForm();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReturnObject<Boolean> ret = null;
            switch (trvOption.SelectedNode.Text)
            {
                case "Building Type":
                    this.buildingTypeFormDto.BuildingType = new BuildingTypeFacade.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    };
                    BinAff.Facade.Library.Server facade = new BuildingTypeFacade.Server(this.buildingTypeFormDto);
                    facade.Add();
                    if (facade.IsError)
                    {
                        //Show message
                        MessageBox.Show(this, "Error", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Error);//TO DO : Change
                    }
                    else
                    {
                        MessageBox.Show(this, "Data saved successfully", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "Room Category":
                    FacadeRoom.Category.IRoomCategory roomCategory = new FacadeRoom.Category.Server();
                    ret = roomCategory.Add(new FacadeRoom.Category.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    });
                    break;
                case "Room Type":
                    FacadeRoom.Type.IRoomType roomType = new FacadeRoom.Type.Server();
                    ret = roomType.Add(new FacadeRoom.Type.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    });
                    break;              
                default:
                    this.Clear();
                    break;
            }            
            new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message  
            this.Clear();
            this.LoadForm();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.lslList.SelectedIndex == -1)
            { 
                new PresentationLibrary.MessageBox("Please select one item", PresentationLibrary.MessageBox.Type.Alert).ShowDialog(this);//Show message
                return;
            }

            ReturnObject<Boolean> ret = null;
            BinAff.Facade.Library.Server facade;
            switch (trvOption.SelectedNode.Text)
            {
                case "Building Type":
                    this.buildingTypeFormDto.BuildingType = new BuildingTypeFacade.Dto
                    {
                        Id = ((BuildingTypeFacade.Dto)this.lslList.SelectedItem).Id,
                        Name = this.txtName.Text.Trim()
                    };
                    facade = new BuildingTypeFacade.Server(this.buildingTypeFormDto);
                    facade.Change();
                    if (facade.IsError)
                    {
                        MessageBox.Show(this, "Error", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Error);//TO DO : Change
                    }
                    else
                    {
                        MessageBox.Show(this, "Data changed successfully", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "Room Category":
                    {
                        FacadeRoom.Category.IRoomCategory roomCategory = new FacadeRoom.Category.Server();
                        ret = roomCategory.Change(new FacadeRoom.Category.Dto
                        {
                            Id = ((FacadeRoom.Category.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                case "Room Type":
                    {
                        FacadeRoom.Type.IRoomType roomType = new FacadeRoom.Type.Server();
                        ret = roomType.Change(new FacadeRoom.Type.Dto
                        {
                            Id = ((FacadeRoom.Type.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;               
                default:
                    this.Clear();
                    break;
            }
            new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message  
            this.Clear();
            this.LoadForm();
        }

        //protected override void btnDelete_Click(object sender, EventArgs e)
        //{
            //if (this.lslList.SelectedIndex == -1)
            //{
            //    new MessageBox("Please select one item", MessageBox.Type.Alert);
            //    return;
            //}

            //Boolean blnDelete = true;
            //ReturnObject<Boolean> ret = null;
            //switch (trvOption.SelectedNode.Text)
            //{
            //    case "State":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "State delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IState state = new StateServer();
            //                ret = state.Delete(new Facade.Configuration.State.Dto
            //                {
            //                    Id = ((Facade.Configuration.State.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
                        
            //        }
            //        break;
            //    case "Name Initial":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Name initial delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IInitial initial = new InitialServer();
            //                ret = initial.Delete(new Facade.Configuration.Initial.Dto
            //                {
            //                    Id = ((Facade.Configuration.Initial.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "Identity Proof Type":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Identity proof type Delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IIdentityProofType IdentityProof = new IdentityProofTypeServer();
            //                ret = IdentityProof.Delete(new Facade.Configuration.IdentityProofType.Dto
            //                {
            //                    Id = ((Facade.Configuration.IdentityProofType.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "Security Question":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Security question delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IQuestion question = new QuestionServer();
            //                ret = question.Delete(new Facade.Configuration.SecurityQuestion.Dto
            //                {
            //                    Id = ((Facade.Configuration.SecurityQuestion.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "Building Type":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Building type delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IBuildingType building = new BuildingTypeServer();
            //                ret = building.Delete(new Facade.Configuration.BuildingType.Dto
            //                {
            //                    Id = ((Facade.Configuration.BuildingType.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "Room Category":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Room category Delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IRoomCategory roomCategory = new RoomCategoryServer();
            //                ret = roomCategory.Delete(new Facade.Configuration.RoomCategory.Dto
            //                {
            //                    Id = ((Facade.Configuration.RoomCategory.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "Room Type":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "Room type delete",
            //                System.Windows.Forms.MessageBoxButtons.YesNo,
            //                System.Windows.Forms.MessageBoxIcon.Question)
            //                  == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IRoomType roomType = new RoomTypeServer();
            //                ret = roomType.Delete(new Facade.Configuration.RoomType.Dto
            //                {
            //                    Id = ((Facade.Configuration.RoomType.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    case "PaymentType":
            //        {
            //            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the payment type.?", "Payment type delete",
            //                    System.Windows.Forms.MessageBoxButtons.YesNo,
            //                    System.Windows.Forms.MessageBoxIcon.Question)
            //                      == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                IPaymentType paymentType = new PaymentTypeServer();
            //                ret = paymentType.Delete(new Facade.Configuration.PaymentType.Dto
            //                {
            //                    Id = ((Facade.Configuration.PaymentType.Dto)this.lslList.SelectedItem).Id
            //                });
            //            }
            //            else blnDelete = false;
            //        }
            //        break;
            //    default:
            //        this.Clear();
            //        break;
            //}

            //if(blnDelete)
            //    base.ShowMessage(ret); //Show message
            //else
            //    this.Clear();
        //}

        private void LoadForm()
        {
            this.Clear();
            if (trvOption.SelectedNode != null)
            {
                switch (trvOption.SelectedNode.Text)
                {
                    case "Building Type":
                        {
                            BinAff.Facade.Library.Server facade = new BuildingTypeFacade.Server(this.buildingTypeFormDto);
                            facade.LoadForm();
                            if (facade.IsError)
                            {
                                MessageBox.Show(this, "Error", "Splash", MessageBoxButtons.OK, MessageBoxIcon.Error);//TO DO : Change
                                return;
                            }

                            this.lslList.DataSource = this.buildingTypeFormDto.BuildingTypeList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;
                    case "Room Category":
                        {
                            FacadeRoom.Category.IRoomCategory roomCategory = new FacadeRoom.Category.Server();
                            ReturnObject<FacadeRoom.Category.FormDto> ret = roomCategory.LoadForm();
                            this.lslList.DataSource = ret.Value.RoomCategoryList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;
                    case "Room Type":
                        {
                            FacadeRoom.Type.IRoomType roomType = new FacadeRoom.Type.Server();
                            ReturnObject<FacadeRoom.Type.FormDto> ret = roomType.LoadForm();
                            this.lslList.DataSource = ret.Value.RoomTypeList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;                   
                    default:
                        this.Clear();
                        this.lslList.DataSource = null;
                        break;
                }
                if (this.lslList.DataSource != null)
                {
                    this.lslList.ValueMember = "Id";
                    this.lslList.SelectedIndex = -1;
                }
            }
        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.lslList.SelectedIndex = -1;
        }

        private void lslList_Click(object sender, EventArgs e)
        {
            if (this.lslList.SelectedIndex != -1)
            {
                switch (trvOption.SelectedNode.Text)
                {                   
                    case "Building Type":
                        this.txtName.Text = ((BuildingTypeFacade.Dto)this.lslList.SelectedItem).Name;
                        break;
                    case "Room Category":
                        this.txtName.Text = ((FacadeRoom.Category.Dto)this.lslList.SelectedItem).Name;
                        break;
                    case "Room Type":
                        this.txtName.Text = ((FacadeRoom.Type.Dto)this.lslList.SelectedItem).Name;
                        break;                 
                    default:
                        this.Clear();
                        break;
                }
            }
        }

        private void txtName_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                //this.btnDelete_Click(sender, e);
            }
        }

        private void trvOption_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.LoadForm();
        }

    }

}
