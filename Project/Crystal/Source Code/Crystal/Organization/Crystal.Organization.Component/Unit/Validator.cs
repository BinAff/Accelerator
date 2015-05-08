using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Organization.Component.Unit
{

    public abstract class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = base.Data as Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
            {
                retMsg.Add(new Message("Unit name cannot be empty.", Message.Type.Error));
            }

            //if (ValidationRule.IsNullOrEmpty(data.Organization) || (data.Organization.Id == 0))
            //{
            //    retMsg.Add(new Message("Organization is not selected.", Message.Type.Error));
            //}

            if (ValidationRule.IsNullOrEmpty(data.Type) || (data.Type.Id == 0))
            {
                retMsg.Add(new Message("Unit type is not selected.", Message.Type.Error));
            }

            //-- This validation is applicable only for insert
            if ((data.Id == 0) && (ValidationRule.IsNullOrEmpty(data.Status) || (data.Status.Id == 0)))
            {
                retMsg.Add(new Message("Unit status is not selected.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
