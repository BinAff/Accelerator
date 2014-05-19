using System;
using System.Collections.Generic;

using BinAff.Core;

using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.WinForm
{

    public partial class SaveDialogue : UtilWin.SaveDialog
    {

        public SaveDialogue()
            : base()
        {
            InitializeComponent();
            base.Category = ArtfFac.Category.Form;
        }

        protected override List<Table> GetExtensionList()
        {
            //Need to read from database
            return new List<Table>
            {
                new Table { Id = 0, Name = "All Forms (*.frm)" },
                new Table { Id = 100, Name = "All Files (*.*)" },
            };
        }

    }

}
