using System;

using AccFac = Vanilla.Guardian.Facade.Account;
using UtilWin = Vanilla.Utility.WinForm;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.CommercialInstrument.WinForm
{

    public partial class Container : UtilWin.Container
    {

        protected Container()
            : base()
        {
            InitializeComponent();
            this.Text = "Instruments";
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {
            InitializeComponent();
            this.Text = "Instruments";
        }

        private static Container currentInstance;

        public static Container CreateInstance(AccFac.Dto account)
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container(account);
            return currentInstance;
        }

        public static Container CreateInstance()
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container();
            return currentInstance;
        }

        protected override void Compose()
        {
            base.facade = new Facade.Container.Server(null);
        }

        protected override UtilWin.Container CreateExecutableInstance(AccFac.Dto dto)
        {
            return Vanilla.CommercialInstrument.WinForm.Container.CreateInstance(dto);
        }

        protected override UtilWin.Open GetOpenDialogue()
        {
            return new Open
            {
                Text = "Open Commercial Instrument",
                Owner = this,
            };
        }

        protected override UtilWin.SaveDialog GetNewDialogue()
        {
            return new SaveDialogue
            {
                Text = "Save Commercial Instrument",
                Owner = this,
            };
        }

    }

}
