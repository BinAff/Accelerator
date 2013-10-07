using System;
using System.Windows.Forms;

using BinAff.Core;

using Vanilla.Configuration.Facade.State;
using Vanilla.Configuration.Facade.Initial;
using Vanilla.Configuration.Facade.IdentityProofType;
using Vanilla.Configuration.Facade.PaymentType;
using Vanilla.Configuration.Facade.SecurityQuestion;


namespace Vanilla.Configuration.WinForm
{

    public partial class ConfigManager : Form
    {

        public ConfigManager()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //this.Clear();          
            this.LoadForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReturnObject<Boolean> ret = null;
            switch (trvOption.SelectedNode.Text)
            {
                case "State":
                    IState state = new StateServer();
                    ret = state.Add(new Vanilla.Configuration.Facade.State.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    });
                    break;
                case "Name Initial":
                    IInitial initial = new InitialServer();
                    ret = initial.Add(new Vanilla.Configuration.Facade.Initial.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    });
                    break;
                case "Identity Proof Type":
                    IIdentityProofType IdentityProof = new IdentityProofTypeServer();
                    ret = IdentityProof.Add(new Vanilla.Configuration.Facade.IdentityProofType.Dto
                    {
                        Name = this.txtName.Text.Trim()
                    });
                    break;
                case "Security Question":
                    IQuestion question = new QuestionServer();
                    ret = question.Add(new Vanilla.Configuration.Facade.SecurityQuestion.Dto
                    {
                        Question = this.txtName.Text.Trim()
                    });
                    break;                
                case "PaymentType":
                    {
                        IPaymentType paymentType = new PaymentTypeServer();
                        ret = paymentType.Add(new Vanilla.Configuration.Facade.PaymentType.Dto
                        {
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                default:
                    this.Clear();
                    break;
            }
            this.ShowMessage(ret); //Show message
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.lslList.SelectedIndex == -1)
            {
                //new MessageBox("Please select one item", MessageBox.Type.Alert);                
                MessageBox.Show("Please select one item");
                return;
            }

            ReturnObject<Boolean> ret = null;
            switch (trvOption.SelectedNode.Text)
            {
                case "State":
                    {
                        IState state = new StateServer();
                        ret = state.Change(new Vanilla.Configuration.Facade.State.Dto
                        {
                            Id = ((Vanilla.Configuration.Facade.State.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                case "Name Initial":
                    {
                        IInitial initial = new InitialServer();
                        ret = initial.Change(new Vanilla.Configuration.Facade.Initial.Dto
                        {
                            Id = ((Vanilla.Configuration.Facade.Initial.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                case "Identity Proof Type":
                    {
                        IIdentityProofType IdentityProof = new IdentityProofTypeServer();
                        ret = IdentityProof.Change(new Vanilla.Configuration.Facade.IdentityProofType.Dto
                        {
                            Id = ((Vanilla.Configuration.Facade.IdentityProofType.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                case "Security Question":
                    {
                        IQuestion question = new QuestionServer();
                        ret = question.Change(new Vanilla.Configuration.Facade.SecurityQuestion.Dto
                        {
                            Id = ((Vanilla.Configuration.Facade.SecurityQuestion.Dto)this.lslList.SelectedItem).Id,
                            Question = this.txtName.Text.Trim()
                        });
                    }
                    break;                
                case "PaymentType":
                    {
                        IPaymentType paymentType = new PaymentTypeServer();
                        ret = paymentType.Change(new Vanilla.Configuration.Facade.PaymentType.Dto
                        {
                            Id = ((Vanilla.Configuration.Facade.PaymentType.Dto)this.lslList.SelectedItem).Id,
                            Name = this.txtName.Text.Trim()
                        });
                    }
                    break;
                default:
                    this.Clear();
                    break;
            }
            this.ShowMessage(ret); //Show message
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lslList.SelectedIndex == -1)
            {
                //new MessageBox("Please select one item", MessageBox.Type.Alert);
                MessageBox.Show("Please select one item");
                return;
            }

            Boolean blnDelete = true;
            ReturnObject<Boolean> ret = null;
            switch (trvOption.SelectedNode.Text)
            {
                case "State":
                    {
                        if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the state.?", "State delete",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question)
                              == System.Windows.Forms.DialogResult.Yes)
                        {
                            IState state = new StateServer();
                            ret = state.Delete(new Vanilla.Configuration.Facade.State.Dto
                            {
                                Id = ((Vanilla.Configuration.Facade.State.Dto)this.lslList.SelectedItem).Id
                            });
                        }
                        else blnDelete = false;

                    }
                    break;
                case "Name Initial":
                    {
                        if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the initial.?", "Name initial delete",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question)
                              == System.Windows.Forms.DialogResult.Yes)
                        {
                            IInitial initial = new InitialServer();
                            ret = initial.Delete(new Vanilla.Configuration.Facade.Initial.Dto
                            {
                                Id = ((Vanilla.Configuration.Facade.Initial.Dto)this.lslList.SelectedItem).Id
                            });
                        }
                        else blnDelete = false;
                    }
                    break;
                case "Identity Proof Type":
                    {
                        if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the Identity Proof Type.?", "Identity proof type Delete",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question)
                              == System.Windows.Forms.DialogResult.Yes)
                        {
                            IIdentityProofType IdentityProof = new IdentityProofTypeServer();
                            ret = IdentityProof.Delete(new Vanilla.Configuration.Facade.IdentityProofType.Dto
                            {
                                Id = ((Vanilla.Configuration.Facade.IdentityProofType.Dto)this.lslList.SelectedItem).Id
                            });
                        }
                        else blnDelete = false;
                    }
                    break;
                case "Security Question":
                    {
                        if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the Security Question.?", "Security question delete",
                            System.Windows.Forms.MessageBoxButtons.YesNo,
                            System.Windows.Forms.MessageBoxIcon.Question)
                              == System.Windows.Forms.DialogResult.Yes)
                        {
                            IQuestion question = new QuestionServer();
                            ret = question.Delete(new Vanilla.Configuration.Facade.SecurityQuestion.Dto
                            {
                                Id = ((Vanilla.Configuration.Facade.SecurityQuestion.Dto)this.lslList.SelectedItem).Id
                            });
                        }
                        else blnDelete = false;
                    }
                    break;


                case "PaymentType":
                    {
                        if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the payment type.?", "Payment type delete",
                                System.Windows.Forms.MessageBoxButtons.YesNo,
                                System.Windows.Forms.MessageBoxIcon.Question)
                                  == System.Windows.Forms.DialogResult.Yes)
                        {
                            IPaymentType paymentType = new PaymentTypeServer();
                            ret = paymentType.Delete(new Vanilla.Configuration.Facade.PaymentType.Dto
                            {
                                Id = ((Vanilla.Configuration.Facade.PaymentType.Dto)this.lslList.SelectedItem).Id
                            });
                        }
                        else blnDelete = false;
                    }
                    break;
                default:
                    this.Clear();
                    break;
            }

            if (blnDelete)
                this.ShowMessage(ret); //Show message
            else
                this.Clear();
        }

        private void LoadForm()
        {
            this.Clear();
            if (trvOption.SelectedNode != null)
            {
                switch (trvOption.SelectedNode.Text)
                {
                    case "State":
                        {
                            IState state = new StateServer();
                            ReturnObject<Vanilla.Configuration.Facade.State.FormDto> ret = state.LoadForm();
                            this.lslList.DataSource = ret.Value.StateList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;
                    case "Name Initial":
                        {
                            IInitial initial = new InitialServer();
                            ReturnObject<Vanilla.Configuration.Facade.Initial.FormDto> ret = initial.LoadForm();
                            this.lslList.DataSource = ret.Value.InitialList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;
                    case "Identity Proof Type":
                        {
                            IIdentityProofType IdentityProof = new IdentityProofTypeServer();
                            ReturnObject<Vanilla.Configuration.Facade.IdentityProofType.FormDto> ret = IdentityProof.LoadForm();
                            this.lslList.DataSource = ret.Value.IdentityProofList;
                            this.lslList.DisplayMember = "Name";
                        }
                        break;
                    case "Security Question":
                        {
                            IQuestion question = new QuestionServer();
                            ReturnObject<Vanilla.Configuration.Facade.SecurityQuestion.FormDto> ret = question.LoadForm();
                            this.lslList.DataSource = ret.Value.QuestionList;
                            this.lslList.DisplayMember = "Question";
                        }
                        break;                   
                    case "PaymentType":
                        {
                            IPaymentType paymentType = new PaymentTypeServer();
                            ReturnObject<Vanilla.Configuration.Facade.PaymentType.FormDto> ret = paymentType.LoadForm();
                            this.lslList.DataSource = ret.Value.PaymentTypeList;
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

        protected void Clear()
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
                    case "State":
                        this.txtName.Text = ((Vanilla.Configuration.Facade.State.Dto)this.lslList.SelectedItem).Name;
                        break;
                    case "Name Initial":
                        this.txtName.Text = ((Vanilla.Configuration.Facade.Initial.Dto)this.lslList.SelectedItem).Name;
                        break;
                    case "Identity Proof Type":
                        this.txtName.Text = ((Vanilla.Configuration.Facade.IdentityProofType.Dto)this.lslList.SelectedItem).Name;
                        break;
                    case "Security Question":
                        this.txtName.Text = ((Vanilla.Configuration.Facade.SecurityQuestion.Dto)this.lslList.SelectedItem).Question;
                        break;
                    case "PaymentType":
                        this.txtName.Text = ((Vanilla.Configuration.Facade.PaymentType.Dto)this.lslList.SelectedItem).Name;
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
                this.btnDelete_Click(sender, e);
            }
        }

        private void trvOption_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.LoadForm();
        }
        
        private void ShowMessage(ReturnObject<Boolean> ret)
        {
            MessageBox.Show(ret.MessageList[0].Description);

            //new MessageBox(ret.MessageList).ShowDialog(this);
            if (!ret.HasError())
            {
                this.LoadForm();
                this.Clear();
            }
        }
                       
    }

}
