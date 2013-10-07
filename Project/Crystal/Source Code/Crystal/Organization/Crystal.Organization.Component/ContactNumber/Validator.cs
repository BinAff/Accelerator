using System.Collections.Generic;
using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Organization.Component.ContactNumber
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

            if (!ValidationRule.IsNullOrEmpty(data.ContactNumber))
            {
                 if (data.ContactNumber.Split('-').Length == 1) 
                 {
                   if (!(ValidationRule.IsMobileNo(data.ContactNumber) || !ValidationRule.IsTelephoneNumber(data.ContactNumber)))
                        retMsg.Add(new Message("Contact number is not valid.", Message.Type.Error));
                 }
                 else if (data.ContactNumber.Split('-').Length == 3) //landline
                 {   
                     if (!(ValidationRule.IsSTDCode(data.ContactNumber.Split('-')[1]) || !ValidationRule.IsTelephoneNumber(data.ContactNumber.Split('-')[2])))
                            retMsg.Add(new Message("Contact number is not valid.", Message.Type.Error));
                 }
                 else if (data.ContactNumber.Split('-').Length == 2) //Mobile
                 {
                    if (!ValidationRule.IsMobileNo(data.ContactNumber.Split('-')[1]))
                        retMsg.Add(new Message("Contact number is not valid.", Message.Type.Error));
                 }
               
            }                

            return retMsg;
        }
    }
}

 //Validate STD
                
