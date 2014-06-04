using System;
using System.Collections.Generic;

using BinAff.Core;

using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.CommercialInstrument.WinForm
{

    public partial class SaveDialogue : UtilWin.SaveDialog
    {

        public SaveDialogue()
            : base()
        {
            InitializeComponent();
            base.Category = ArtfFac.Category.CommercialInstrument;
        }

        protected override List<Table> GetExtensionList()
        {
            //Need to read from database
            return new List<Table>
            {
                new Table { Id = 0, Name = "All Instruments (*.ins)" },
                new Table { Id = 100, Name = "All Files (*.*)" },
            };
        }

    }

}
