//using AutoTourism.Presentation.Library;
//using AutoTourism.Facade.Rule;
//using BinAff.Core;
using System;
using System.Windows.Forms;
//using BinAff.Utility;

namespace AutoTourism.Lodge.Configuration.WinForm
{
    //public partial class Rule : OkForm
    public partial class Rule : Form
    {
        public Rule()
        {
            InitializeComponent();

            //LoadForm();
            //Clear();
        }
        
        //protected override void LoadForm()
        //{
            //IRule rule = new RuleServer();            
            //ReturnObject<FormDto> ret = rule.LoadForm();

            ////Populate Customer rule
            //if(ret.Value.RuleDto != null && ret.Value.RuleDto.CustomerRule != null)
            //{
            //    this.chkIsPin.Checked = ret.Value.RuleDto.CustomerRule.IsPinNumber;
            //    this.chkIsAltContactNo.Checked = ret.Value.RuleDto.CustomerRule.IsAlternateContactNumber;
            //    this.chkIsEmail.Checked = ret.Value.RuleDto.CustomerRule.IsEmail;
            //    this.chkIsIdProof.Checked = ret.Value.RuleDto.CustomerRule.IsIdentityProof;
            //}
           
            ////populate User rule
            //if (ret.Value.RuleDto != null && ret.Value.RuleDto.UserRule != null)
            //{
            //    this.txtPassword.Text = ret.Value.RuleDto.UserRule.DefaultUserPassword;
            //}    
       
            ////populate Tax Rule
            //if (ret.Value.RuleDto != null && ret.Value.RuleDto.TaxRule != null)
            //{
            //    this.txtServiceTax.Text = ret.Value.RuleDto.TaxRule.ServiceTax == 0 ? String.Empty : ret.Value.RuleDto.TaxRule.ServiceTax.ToString();
            //    this.txtLuxuryTax.Text = ret.Value.RuleDto.TaxRule.LuxuryTax == 0 ? String.Empty : ret.Value.RuleDto.TaxRule.LuxuryTax.ToString();
            //}    
        //}
        
        //protected override void Clear()
        //{
            
        //}        

        //protected override void btnOk_Click(object sender, System.EventArgs e)
        //{
            //if (!ValidateRule()) return;

            //Dto RuleDto = new Dto()
            //{
            //    CustomerRule = new Facade.CustomerManagement.Rule.Dto()
            //    {
            //        IsPinNumber = this.chkIsPin.Checked,
            //        IsAlternateContactNumber = this.chkIsAltContactNo.Checked,
            //        IsEmail = this.chkIsEmail.Checked,
            //        IsIdentityProof = this.chkIsIdProof.Checked
            //    },
            //    UserRule = new Facade.UserManagement.Rule.Dto()
            //    {
            //        DefaultUserPassword = this.txtPassword.Text.Trim()
            //    },
            //    TaxRule = new TaxRuleDto() { 
            //        LuxuryTax = Convert.ToDouble(this.txtLuxuryTax.Text),
            //        ServiceTax = Convert.ToDouble(this.txtServiceTax.Text),
            //    }
            //};

            //IRule rule = new RuleServer();
            //base.ShowMessage(rule.Save(RuleDto));//Show message  
            //this.Close();
        //}

        private Boolean ValidateRule()
        {
            errorProvider.Clear();
                        
            //if (String.IsNullOrEmpty(txtServiceTax.Text.Trim()))
            //{
            //    errorProvider.SetError(txtServiceTax, "Please enter service tax.");
            //    txtServiceTax.Focus();
            //    return false;
            //}
            //else if (!ValidationRule.IsDouble(txtServiceTax.Text.Trim()))
            //{
            //    errorProvider.SetError(txtServiceTax, "Please enter valid data.");
            //    txtServiceTax.Focus();
            //    return false;
            //}
            //else if (String.IsNullOrEmpty(txtLuxuryTax.Text.Trim()))
            //{
            //    errorProvider.SetError(txtLuxuryTax, "Please enter luxury tax.");
            //    txtLuxuryTax.Focus();
            //    return false;
            //}
            //else if (!ValidationRule.IsDouble(txtLuxuryTax.Text.Trim()))
            //{
            //    errorProvider.SetError(txtLuxuryTax, "Please enter valid data.");
            //    txtLuxuryTax.Focus();
            //    return false;
            //}
           

            return true;
        }

    }
}
