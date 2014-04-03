using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using System;

namespace Crystal.Diary.Component.Appointment
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
            if (ValidationRule.IsNullOrEmpty(data.Title))
            {
                retMsg.Add(new Message("Title cannot be empty.", Message.Type.Error));
            }
            else if (ValidationRule.IsLengthExceeded(data.Title, 50))
            {
                retMsg.Add(new Message("Title cannot be more than 50 characters.", Message.Type.Error));
            }

            if (ValidationRule.IsNullOrEmpty(data.Location))
            {
                retMsg.Add(new Message("Location cannot be empty.", Message.Type.Error));
            }
            else if (ValidationRule.IsLengthExceeded(data.Location, 50))
            {
                retMsg.Add(new Message("Location cannot be more than 50 characters.", Message.Type.Error));
            }

            if (ValidationRule.IsNullOrEmpty(data.Description))
            {
                retMsg.Add(new Message("Description cannot be empty.", Message.Type.Error));
            }
            else if (ValidationRule.IsLengthExceeded(data.Description, 250))
            {
                retMsg.Add(new Message("Description cannot be more than 250 characters.", Message.Type.Error));
            }

            if (ValidationRule.IsDateGreater(DateTime.Now, data.Start))
            {
                retMsg.Add(new Message("Start date and time must be later.", Message.Type.Error));
            }
            if (ValidationRule.IsDateGreater(DateTime.Now, data.End))
            {
                retMsg.Add(new Message("End date and time must be later.", Message.Type.Error));
            }
            if (ValidationRule.IsDateGreater(data.Start, data.End))
            {
                retMsg.Add(new Message("Start date and time must be greater than end date and time.", Message.Type.Error));
            }
            if (data.Reminder != null)
            {
                DateTime reminder = (DateTime)data.Reminder;
                if (ValidationRule.IsDateGreater(reminder, data.Start))
                {
                    retMsg.Add(new Message("Reminder must be before appointment start.", Message.Type.Error));
                }
            }

            return retMsg;
        }

    }

}
