using System;
using System.Windows.Forms;

//using BinAff.Core;

//using AutoTourism.Presentation.Library;

//using AutoTourism.Facade.Configuration.BuildingType;
//using AutoTourism.Facade.Configuration.IdentityProofType;
//using AutoTourism.Facade.Configuration.Initial;
//using AutoTourism.Facade.Configuration.RoomCategory;
//using AutoTourism.Facade.Configuration.RoomType;
//using AutoTourism.Facade.Configuration.SecurityQuestion;
//using AutoTourism.Facade.Configuration.State;
//using AutoTourism.Facade.Configuration.PaymentType;

namespace AutoTourism.Presentation.Configuration
{

    public partial class ConfigManager : Form
    {

        public ConfigManager()
        {
            InitializeComponent();
        }

        protected override void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.LoadForm();
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            //ReturnObject<Boolean> ret = null;
            //switch (trvOption.SelectedNode.Text)
            //{
            //    case "State":
            //        IState state = new StateServer();
            //        ret = state.Add(new Facade.Configuration.State.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Name Initial":
            //        IInitial initial = new InitialServer();
            //        ret = initial.Add(new Facade.Configuration.Initial.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Identity Proof Type":
            //        IIdentityProofType IdentityProof = new IdentityProofTypeServer();
            //        ret = IdentityProof.Add(new Facade.Configuration.IdentityProofType.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Security Question":
            //        IQuestion question = new QuestionServer();
            //        ret = question.Add(new Facade.Configuration.SecurityQuestion.Dto
            //        {
            //            Question = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Building Type":
            //        IBuildingType building = new BuildingTypeServer();
            //        ret = building.Add(new Facade.Configuration.BuildingType.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Room Category":
            //        IRoomCategory roomCategory = new RoomCategoryServer();
            //        ret = roomCategory.Add(new Facade.Configuration.RoomCategory.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "Room Type":
            //        IRoomType roomType = new RoomTypeServer();
            //        ret = roomType.Add(new Facade.Configuration.RoomType.Dto
            //        {
            //            Name = this.txtName.Text.Trim()
            //        });
            //        break;
            //    case "PaymentType":
            //        {
            //            IPaymentType paymentType = new PaymentTypeServer();
            //            ret = paymentType.Add(new Facade.Configuration.PaymentType.Dto { 
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    default:
            //        this.Clear();
            //        break;
            //}
            //base.ShowMessage(ret); //Show message
        }

        protected override void btnChange_Click(object sender, EventArgs e)
        {
            //if (this.lslList.SelectedIndex == -1)
            //{
            //    new MessageBox("Please select one item", MessageBox.Type.Alert);
            //    return;
            //}

            //ReturnObject<Boolean> ret = null;
            //switch (trvOption.SelectedNode.Text)
            //{
            //    case "State":
            //        {
            //            IState state = new StateServer();
            //            ret = state.Change(new Facade.Configuration.State.Dto
            //            {
            //                Id = ((Facade.Configuration.State.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Name Initial":
            //        {
            //            IInitial initial = new InitialServer();
            //            ret = initial.Change(new Facade.Configuration.Initial.Dto
            //            {
            //                Id = ((Facade.Configuration.Initial.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Identity Proof Type":
            //        {
            //            IIdentityProofType IdentityProof = new IdentityProofTypeServer();
            //            ret = IdentityProof.Change(new Facade.Configuration.IdentityProofType.Dto
            //            {
            //                Id = ((Facade.Configuration.IdentityProofType.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Security Question":
            //        {
            //            IQuestion question = new QuestionServer();
            //            ret = question.Change(new Facade.Configuration.SecurityQuestion.Dto
            //            {
            //                Id = ((Facade.Configuration.SecurityQuestion.Dto)this.lslList.SelectedItem).Id,
            //                Question = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Building Type":
            //        {
            //            IBuildingType building = new BuildingTypeServer();
            //            ret = building.Change(new Facade.Configuration.BuildingType.Dto
            //            {
            //                Id = ((Facade.Configuration.BuildingType.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Room Category":
            //        {
            //            IRoomCategory roomCategory = new RoomCategoryServer();
            //            ret = roomCategory.Change(new Facade.Configuration.RoomCategory.Dto
            //            {
            //                Id = ((Facade.Configuration.RoomCategory.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "Room Type":
            //        {
            //            IRoomType roomType = new RoomTypeServer();
            //            ret = roomType.Change(new Facade.Configuration.RoomType.Dto
            //            {
            //                Id = ((Facade.Configuration.RoomType.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    case "PaymentType":
            //        {
            //            IPaymentType paymentType = new PaymentTypeServer();
            //            ret = paymentType.Change(new Facade.Configuration.PaymentType.Dto
            //            {
            //                Id = ((Facade.Configuration.PaymentType.Dto)this.lslList.SelectedItem).Id,
            //                Name = this.txtName.Text.Trim()
            //            });
            //        }
            //        break;
            //    default:
            //        this.Clear();
            //        break;
            //}
            //base.ShowMessage(ret); //Show message
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
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
        }

        protected override void LoadForm()
        {
            //this.Clear();
            //if (trvOption.SelectedNode != null)
            //{
            //    switch (trvOption.SelectedNode.Text)
            //    {
            //        case "State":
            //            {
            //                IState state = new StateServer();
            //                ReturnObject<Facade.Configuration.State.FormDto> ret = state.LoadForm();
            //                this.lslList.DataSource = ret.Value.StateList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "Name Initial":
            //            {
            //                IInitial initial = new InitialServer();
            //                ReturnObject<Facade.Configuration.Initial.FormDto> ret = initial.LoadForm();
            //                this.lslList.DataSource = ret.Value.InitialList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "Identity Proof Type":
            //            {
            //                IIdentityProofType IdentityProof = new IdentityProofTypeServer();
            //                ReturnObject<Facade.Configuration.IdentityProofType.FormDto> ret = IdentityProof.LoadForm();
            //                this.lslList.DataSource = ret.Value.IdentityProofList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "Security Question":
            //            {
            //                IQuestion question = new QuestionServer();
            //                ReturnObject<Facade.Configuration.SecurityQuestion.FormDto> ret = question.LoadForm();
            //                this.lslList.DataSource = ret.Value.QuestionList;
            //                this.lslList.DisplayMember = "Question";
            //            }
            //            break;
            //        case "Building Type":
            //            {
            //                IBuildingType building = new BuildingTypeServer();
            //                ReturnObject<Facade.Configuration.BuildingType.FormDto> ret = building.LoadForm();
            //                this.lslList.DataSource = ret.Value.BuildingTypeList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "Room Category":
            //            {
            //                IRoomCategory roomCategory = new RoomCategoryServer();
            //                ReturnObject<Facade.Configuration.RoomCategory.FormDto> ret = roomCategory.LoadForm();
            //                this.lslList.DataSource = ret.Value.RoomCategoryList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "Room Type":
            //            {
            //                IRoomType roomType = new RoomTypeServer();
            //                ReturnObject<Facade.Configuration.RoomType.FormDto> ret = roomType.LoadForm();
            //                this.lslList.DataSource = ret.Value.RoomTypeList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        case "PaymentType":
            //            {
            //                IPaymentType paymentType = new PaymentTypeServer();
            //                ReturnObject<Facade.Configuration.PaymentType.FormDto> ret = paymentType.LoadForm();
            //                this.lslList.DataSource = ret.Value.PaymentTypeList;
            //                this.lslList.DisplayMember = "Name";
            //            }
            //            break;
            //        default:
            //            this.Clear();
            //            this.lslList.DataSource = null;
            //            break;
            //    }
            //    if (this.lslList.DataSource != null)
            //    {
            //        this.lslList.ValueMember = "Id";
            //        this.lslList.SelectedIndex = -1;
            //    }
            //}
        }

        protected override void Clear()
        {
            this.txtName.Text = String.Empty;
            this.lslList.SelectedIndex = -1;
        }

        private void lslList_Click(object sender, EventArgs e)
        {
            //if (this.lslList.SelectedIndex != -1)
            //{
            //    switch (trvOption.SelectedNode.Text)
            //    {
            //        case "State":
            //            this.txtName.Text = ((Facade.Configuration.State.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "Name Initial":
            //            this.txtName.Text = ((Facade.Configuration.Initial.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "Identity Proof Type":
            //            this.txtName.Text = ((Facade.Configuration.IdentityProofType.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "Security Question":
            //            this.txtName.Text = ((Facade.Configuration.SecurityQuestion.Dto)this.lslList.SelectedItem).Question;
            //            break;
            //        case "Building Type":
            //            this.txtName.Text = ((Facade.Configuration.BuildingType.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "Room Category":
            //            this.txtName.Text = ((Facade.Configuration.RoomCategory.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "Room Type":
            //            this.txtName.Text = ((Facade.Configuration.RoomType.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        case "PaymentType":
            //            this.txtName.Text = ((Facade.Configuration.PaymentType.Dto)this.lslList.SelectedItem).Name;
            //            break;
            //        default:
            //            this.Clear();
            //            break;
            //    }
            //}
        }

        private void txtName_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                this.btnDelete_Click(sender, e);
            }
        }

        private void trvOption_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.LoadForm();
        }

    }

}
