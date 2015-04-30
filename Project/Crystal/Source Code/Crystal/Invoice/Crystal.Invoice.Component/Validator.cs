using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Invoice.Component
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

            if (data.Id != 0 && ValidationRule.IsNullOrEmpty(data.InvoiceNumber))
            {
                retMsg.Add(new Message("Invoice number cannot be empty.", Message.Type.Error));
            }
            else if (data.Id != 0 && data.InvoiceNumber.Length > 50)
            {
                retMsg.Add(new Message("Invoice number length cannot be greater than 50.", Message.Type.Error));
            }

            if (data.Advance < 0)
            {
                retMsg.Add(new Message("Advance cannot be less than 0.", Message.Type.Error));
            }
            if (data.Discount < 0)
            {
                retMsg.Add(new Message("Discount cannot be less than 0.", Message.Type.Error));
            }
            if (data.Seller == null)
            {
                retMsg.Add(new Message("Seller is mandatory.", Message.Type.Error));
            }
            else
            {
                if (ValidationRule.IsNullOrEmpty(data.Seller.Name))
                {
                    retMsg.Add(new Message("Seller name cannot be empty.", Message.Type.Error));
                }
                else if (data.Seller.Name.Length > 50)
                {
                    retMsg.Add(new Message("Seller name length cannot be greater than 50.", Message.Type.Error));
                }
                if (ValidationRule.IsNullOrEmpty(data.Seller.Address))
                {
                    retMsg.Add(new Message("Seller address cannot be empty.", Message.Type.Error));
                }
                else if (data.Seller.Address.Length > 250)
                {
                    retMsg.Add(new Message("Seller address length cannot be greater than 250.", Message.Type.Error));
                }
                if (ValidationRule.IsNullOrEmpty(data.Seller.Liscence))
                {
                    retMsg.Add(new Message("Seller liscence cannot be empty.", Message.Type.Error));
                }
                else if (data.Seller.Liscence.Length > 50)
                {
                    retMsg.Add(new Message("Seller liscence length cannot be greater than 50.", Message.Type.Error));
                }
                if (ValidationRule.IsNullOrEmpty(data.Seller.ContactNumber))
                {
                    retMsg.Add(new Message("Seller contact Number cannot be empty.", Message.Type.Error));
                }
                else if (data.Seller.ContactNumber.Length > 50)
                {
                    retMsg.Add(new Message("Seller contact Number length cannot be greater than 50.", Message.Type.Error));
                }
                if (!ValidationRule.IsNullOrEmpty(data.Seller.Email) && !ValidationRule.IsEmailId(data.Seller.Email))
                {
                    retMsg.Add(new Message("Seller Email is not valid.", Message.Type.Error));
                }
            }
            if (data.Buyer == null)
            {
                retMsg.Add(new Message("Buyer is mandatory.", Message.Type.Error));
            }
            else
            {
                if (ValidationRule.IsNullOrEmpty(data.Buyer.Name))
                {
                    retMsg.Add(new Message("Buyer name cannot be empty.", Message.Type.Error));
                }
                else if (data.Buyer.Name.Length > 50)
                {
                    retMsg.Add(new Message("Buyer name length cannot be greater than 50.", Message.Type.Error));
                }
                if (!ValidationRule.IsNullOrEmpty(data.Buyer.Address) && data.Buyer.Address.Length > 250)
                {
                    retMsg.Add(new Message("Buyer address length cannot be greater than 250.", Message.Type.Error));
                }
                if (!ValidationRule.IsNullOrEmpty(data.Buyer.ContactNumber) && data.Buyer.ContactNumber.Length > 50)
                {
                    retMsg.Add(new Message("Buyer contact number length cannot be greater than 50.", Message.Type.Error));
                }
                if (!ValidationRule.IsNullOrEmpty(data.Buyer.Email) && !ValidationRule.IsEmailId(data.Buyer.Email))
                {
                    retMsg.Add(new Message("Buyer Email is not valid.", Message.Type.Error));
                }
            }
            if (data.LineItemList == null || data.LineItemList.Count <= 0)
            {
                retMsg.Add(new Message("Invoice line item cannot be 0.", Message.Type.Error));
            }
            if (data.Id != 0 && this.IsExist(data))
            {
                retMsg.Add(new Message("Same Invoice already exists.", Message.Type.Error));
            }
            return retMsg;
        }

        private Boolean IsExist(Data data)
        {
            return new Dao(data).ReadDuplicate();
        }

    }

}
