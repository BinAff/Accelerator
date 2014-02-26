using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Customer.Component
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;

            this.ValidateRule(retMsg, data);

            if (ValidationRule.IsNullOrEmpty(data.FirstName))
            {
                retMsg.Add(new Message("First name cannot be empty.", Message.Type.Error));
            }
            else if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(data.FirstName)))
            {
                retMsg.Add(new Message("First name is not valid.", Message.Type.Error));
            }
            else if (data.FirstName.Length > 50)
            {
                retMsg.Add(new Message("First name cannot be more than 50 characters.", Message.Type.Error));
            }

            if (!ValidationRule.IsNullOrEmpty(data.MiddleName))
            {
                if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(data.MiddleName)))
                {
                    retMsg.Add(new Message("Middle name is not valid.", Message.Type.Error));
                }
                else if (data.MiddleName.Length > 50)
                {
                    retMsg.Add(new Message("Middle name cannot be more than 50 characters.", Message.Type.Error));
                }
            }

            if (!ValidationRule.IsNullOrEmpty(data.LastName))
            {
                if (!(new Regex(@"^[a-zA-Z\s]*$").IsMatch(data.LastName)))
                {
                    retMsg.Add(new Message("Last name is not valid.", Message.Type.Error));
                }
                else if (data.LastName.Length > 50)
                {
                    retMsg.Add(new Message("Last name cannot be more than 50 characters.", Message.Type.Error));
                }
            }

            if (ValidationRule.IsNullOrEmpty(data.Address))
            {
                retMsg.Add(new Message("Address cannot be empty.", Message.Type.Error));
            }
            if (ValidationRule.IsNullOrEmpty(data.City))
            {
                retMsg.Add(new Message("City cannot be empty.", Message.Type.Error));
            }
            if (!ValidationRule.IsNullOrEmpty(data.Pin))
            {
                if (!ValidationRule.IsPinCode(data.Pin.ToString()))
                {
                    retMsg.Add(new Message("Invalid pin code.", Message.Type.Error));
                }
            }

            if (!ValidationRule.IsNullOrEmpty(data.Email))
            {
                if (!ValidationRule.IsEmailId(data.Email))
                {
                    retMsg.Add(new Message("Invalid Email.", Message.Type.Error));
                }
            }

            if (data.State == null || data.State.Id == 0)
            {
                retMsg.Add(new Message("State cannot be empty.", Message.Type.Error));
            }
            if (data.ContactNumberList != null && data.ContactNumberList.Count > 0 && !ValidatePhoneNumber(data.ContactNumberList))
            {
                retMsg.Add(new Message("Invalid phone number exists.", Message.Type.Error));
            }
            if (data.IdentityProofType != null && !ValidationRule.IsNullOrEmpty(data.IdentityProofType.Name) && data.IdentityProofType.Name.Length > 50)
            {
                retMsg.Add(new Message("Identity Proof name cannot be more than 50 characters.", Message.Type.Error));
            }

            //Find duplication
            String duplicateCustomerInfo = this.IsExists(data);
            if (!ValidationRule.IsNullOrEmpty(duplicateCustomerInfo))
            {
                retMsg.Add(new Message(duplicateCustomerInfo, Message.Type.Error));
            }

            return retMsg;
        }

        private String IsExists(Data data)
        {
            StringBuilder ret = new StringBuilder();
            List<Int64> duplicateIdList = new Dao(data).ReadDuplicate();
            if (duplicateIdList != null && duplicateIdList.Count > 0)
            {
                ret.Append("Customer with similar information exists. Customer Info:\r\n");

                Int64 customerId = this.Data.Id; 
                this.Data.Id = duplicateIdList[0];
                ICrud server = this.Server;
                server.Read();

                //reset customer id
                this.Data.Id = customerId;

                Crystal.Customer.Component.Data customer = this.Data as Crystal.Customer.Component.Data;
                String customerName = customer.FirstName;
                ret.Append("Name: " + customerName + "\r\n");

                if (customer.Email != String.Empty)                
                    ret.Append("Email: " + customer.Email + "\r\n");
                
                if(customer.ContactNumberList != null && customer.ContactNumberList.Count > 0)
                    ret.Append("Contact Number: " + this.GetContactNumber(customer.ContactNumberList) + "\r\n");

                if(customer.IdentityProofType != null && customer.IdentityProofType.Name != string.Empty && customer.IdentityProof != String.Empty)
                    ret.Append("Identity Proof: " + customer.IdentityProofType.Name + " - " + customer.IdentityProof);

                
                //Data d;
                //foreach (Int64 id in duplicateIdList)
                //{
                //    d = new Data { Id = id };                    
                //    ICrud server = this.Server;
                //    server.Read();
                //    ret.Append(d.FirstName + ":: ");
                //    if (!String.IsNullOrEmpty(d.Email) && String.Compare(d.Email, data.Email, StringComparison.OrdinalIgnoreCase) == 0)
                //    {
                //        ret.Append("Email: '" + d.Email + "' ");
                //    }
                //    if (d.IdentityProofType != null && d.IdentityProofType.Id != 0 && d.IdentityProofType.Id == data.IdentityProofType.Id && String.Compare(d.IdentityProof, data.IdentityProof, StringComparison.OrdinalIgnoreCase) == 0)
                //    {
                //        ret.Append("Identity: '" + d.IdentityProofType.Name + " " + d.IdentityProof + "' ");
                //    }
                //    //Int32 len = d.ContactNumberList.Count;
                //    Boolean isFirst = true;
                //    if (d.ContactNumberList != null)
                //    {
                //        foreach (ContactNumber.Data phone in d.ContactNumberList)
                //        {
                //            String phoneNumber = phone.ContactNumber;
                //            if (data.ContactNumberList.Exists((p) => p.ContactNumber == phoneNumber))
                //            {
                //                if (isFirst) { ret.Append("Matching contact number: "); isFirst = false; }
                //                ret.Append("'" + phoneNumber + "' ");
                //            }
                //        }
                //    }
                //    ret.Append("\r\n");
                //}
            }

            return ret.ToString();
        }

        private void ValidateRule(List<Message> retMsg, Data customerData)
        {
            ReturnObject<BinAff.Core.Data> retVal = (new Rule.Server(new Rule.Data()) as ICrud).Read();

            if (retVal.Value != null)
            {
                Rule.Data rule = (Rule.Data)retVal.Value;

                if (rule.IsPinNumber)
                {
                    if (ValidationRule.IsNullOrEmpty(customerData.Pin))
                    {
                        retMsg.Add(new Message("Pin cannot be empty.", Message.Type.Error));
                    }
                    else if (!ValidationRule.IsPinCode(customerData.Pin.ToString()))
                    {
                        retMsg.Add(new Message("Pin is not valid.", Message.Type.Error));
                    }
                }
                else if (!ValidationRule.IsNullOrEmpty(customerData.Pin) && !ValidationRule.IsPinCode(customerData.Pin.ToString()))
                {
                    retMsg.Add(new Message("Pin is not valid.", Message.Type.Error));
                }
                if (rule.IsAlternateContactNumber) //Alternate Contact Number Mandatory
                {
                    if (customerData.ContactNumberList == null || customerData.ContactNumberList.Count < 2)
                    {
                        retMsg.Add(new Message("AlternateContactNumber cannot be empty.", Message.Type.Error));
                    }
                    else if (customerData.ContactNumberList != null && !ValidatePhoneNumber(customerData.ContactNumberList))
                    {
                        retMsg.Add(new Message("Phone number is not valid.", Message.Type.Error));
                    }
                }
                else if (customerData.ContactNumberList != null && customerData.ContactNumberList.Count > 0 && !ValidatePhoneNumber(customerData.ContactNumberList))
                {
                    retMsg.Add(new Message("Phone number is not valid.", Message.Type.Error));
                }
                if (rule.IsEmail) //Email Mandatory
                {
                    if (ValidationRule.IsNullOrEmpty(customerData.Email))
                    {
                        retMsg.Add(new Message("Email cannot be empty.", Message.Type.Error));
                    }
                    else if (!ValidationRule.IsEmailId(customerData.Email))
                    {
                        retMsg.Add(new Message("Email is not valid.", Message.Type.Error));
                    }
                }
                else if (!ValidationRule.IsNullOrEmpty(customerData.Email) && !ValidationRule.IsEmailId(customerData.Email))
                {
                    retMsg.Add(new Message("Email is not valid.", Message.Type.Error));
                }
                if (rule.IsIdentityProof && ValidationRule.IsNullOrEmpty(customerData.IdentityProof)) //IdentityProof Mandatory
                {
                    retMsg.Add(new Message("Identity Proof cannot be empty.", Message.Type.Error));
                }
            }
        }

        private Boolean ValidatePhoneNumber(List<ContactNumber.Data> contactData)
        {
            foreach (ContactNumber.Data data in contactData)
            {
                if (!(ValidationRule.IsMobileNo(data.ContactNumber) || ValidationRule.IsTelephoneNumber(data.ContactNumber)))
                {
                    return false;
                }
            }
            return true;
        }

        private String GetContactNumber(List<Crystal.Customer.Component.ContactNumber.Data> contactNumberList)
        {
            StringBuilder strbContactNumber = new StringBuilder();

            foreach (Crystal.Customer.Component.ContactNumber.Data data in contactNumberList)
                strbContactNumber.Append(data.ContactNumber + " ,");
            
            return strbContactNumber.ToString().Substring(0,strbContactNumber.ToString().Length -2);        
        }

    }

}
