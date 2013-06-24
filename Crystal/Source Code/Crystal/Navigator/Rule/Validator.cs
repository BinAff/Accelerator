using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Navigator.Rule
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
            Data data = base.Data as Data;

            if (ValidationRule.IsNullOrEmpty(data.ModuleSeperator))
            {
                retMsg.Add(new Message("Module seperator cannot be null.", Message.Type.Error));
            }
            else
            {
                if (ValidationRule.IsLengthExceeded(data.ModuleSeperator, 1))
                {
                    retMsg.Add(new Message("Only one Symbol is available for module seperator.", Message.Type.Error));
                }
                else
                {
                    if(ValidationRule.IsAlphaNumeric(data.ModuleSeperator))
                    {
                        retMsg.Add(new Message("Alphabet/number are not allowed for module seperator. Use special symbol.", Message.Type.Error));
                    }
                }
            }

            if (ValidationRule.IsNullOrEmpty(data.PathSeperator))
            {
                retMsg.Add(new Message("Path seperator cannot be null.", Message.Type.Error));
            }
            else
            {
                if (ValidationRule.IsLengthExceeded(data.PathSeperator, 1))
                {
                    retMsg.Add(new Message("Only one Symbol is available for path seperator.", Message.Type.Error));
                }
                else
                {
                    if (ValidationRule.IsAlphaNumeric(data.PathSeperator))
                    {
                        retMsg.Add(new Message("Alphabet/number are not allowed for path seperator. Use special symbol.", Message.Type.Error));
                    }
                }
            }

            return retMsg;
        }

        public Boolean IsExist()
        {
            return new Dao((Data)base.Data).Read() != null;
        }

    }

}
