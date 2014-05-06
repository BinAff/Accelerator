﻿using AccFac = Vanilla.Guardian.Facade.Account;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Report.WinForm
{

    public partial class Container : UtilWin.Container
    {

        protected Container()
            : base()
        {
            InitializeComponent();
            this.Text = "Reports";
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {
            this.Text = "Reports";
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

        protected override void AddClickEvent(object sender, System.EventArgs e)
        {
            //Get artifact
            //Create mdi child
            //Show as mdi child
        }
        
    }

}
