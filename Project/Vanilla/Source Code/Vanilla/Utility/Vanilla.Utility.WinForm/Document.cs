using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Document : Form
    {

        protected Facade.Document.FormDto formDto;
        protected Facade.Document.Server facade;

        public Boolean IsModified { get; protected set; }

        public String DocumentPath
        {
            get
            {
                return this.formDto.DocumentPath;
            }
        }

        public Document()
        {
            InitializeComponent();
        }

        public Document(Facade.Document.FormDto formDto, Facade.Document.Server facade)
            : this()
        {
            this.formDto = formDto;
            this.facade = facade;
        }

    }

}
