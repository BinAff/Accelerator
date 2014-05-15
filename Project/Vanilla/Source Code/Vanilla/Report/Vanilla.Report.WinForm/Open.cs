using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using System.Collections.Generic;
using BinAff.Core;

namespace Vanilla.Report.WinForm
{

    public partial class Open : UtilWin.Open
    {

        public Open()
        {
            InitializeComponent();
            base.Category = ArtfFac.Category.Report;
        }

        protected override UtilWin.Document GetDocumentForm(ArtfFac.Dto document)
        {
            return new Document(document);
        }
        
        protected override List<Table> GetExtensionList()
        {
            //Need to read from database
            return new List<Table>
            {
                new Table { Id = 0, Name = "All Reports (*.drpt, *.wrpt, *.mrpt, *.qrpt, *.yrpt)" },
                new Table { Id = 1, Name = "Daily Reports (*.drpt)"},
                new Table { Id = 2, Name = "Weekly Reports (*.wrpt)" },
                new Table { Id = 3, Name = "Monthly Reports (*.mrpt)" },
                new Table { Id = 4, Name = "Quarterly Reports (*.qrpt)" },
                new Table { Id = 5, Name = "Yearly Reports (*.yrpt)" },
                new Table { Id = 100, Name = "All Files (*.*)" },
            };
        }

    }

}
