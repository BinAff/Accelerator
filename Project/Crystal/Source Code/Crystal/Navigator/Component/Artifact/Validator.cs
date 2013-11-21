using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Navigator.Component.Artifact
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            :base(data)
        {
            
        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.FileName))
                retMsg.Add(new Message("File/Directory name cannot be empty.", Message.Type.Error));
            if (data.Id == 0)
            {
                if (data.CreatedBy == null)
                    retMsg.Add(new Message("Creator of File/Directory cannot be empty.", Message.Type.Error));
                //if (data.CreatedAt == System.DateTime.MinValue)
                //    retMsg.Add(new Message("Creation time of File/Directory cannot be empty.", Message.Type.Error));
            }
            else //Data is getting modified
            {
                if (data.ModifiedBy == null)
                    retMsg.Add(new Message("Modifier of File/Directory cannot be empty.", Message.Type.Error));
                if (data.ModifiedAt == null)
                    retMsg.Add(new Message("Modification time of File/Directory cannot be empty.", Message.Type.Error));
            }
            //if (ValidationRule.IsNullOrEmpty(data.Style) || data.Style == 0)
            //    retMsg.Add(new Message("Style cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Style))
                retMsg.Add(new Message("Style cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
