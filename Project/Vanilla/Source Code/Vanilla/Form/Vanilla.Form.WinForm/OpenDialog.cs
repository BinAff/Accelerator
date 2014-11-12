using System;
using System.Collections.Generic;

using BinAff.Core;

using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.Form.WinForm
{

    public partial class OpenDialog : UtilWin.OpenDialog
    {

        public OpenDialog()
        {
            InitializeComponent();
            base.Category = ArtfFac.Category.Form;
        }

        protected override UtilWin.Document GetDocumentForm(ArtfFac.Dto document)
        {
            Type type = Type.GetType(document.ComponentDefinition.ComponentFormType, true);
            return (Document)Activator.CreateInstance(type, document);
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
