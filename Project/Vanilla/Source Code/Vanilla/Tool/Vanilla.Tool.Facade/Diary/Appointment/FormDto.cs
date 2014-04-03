using System.Collections.Generic;

using BinAff.Core;
namespace Vanilla.Tool.Facade.Diary.Appointment
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public List<Table> ImportanceList { get; set; }
        public List<Table> TypeList { get; set; }

    }

}