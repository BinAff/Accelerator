﻿using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Tool.Facade.Diary.Calender
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public List<Appointment.Dto> AppointmentList { get; set; }

    }

}