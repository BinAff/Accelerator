

using AccFac = Vanilla.Guardian.Facade.Account;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Form.WinForm
{

    public partial class Container : UtilWin.Container
    {

        protected Container()
            : base()
        {
            InitializeComponent();
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {


        }

        private static Container currentInstance;

        public static Container CreateInstance(AccFac.Dto account)
        {
            if (currentInstance == null) currentInstance = new Container(account);
            return currentInstance;
        }

        public static Container CreateInstance()
        {
            if (currentInstance == null) currentInstance = new Container();
            return currentInstance;
        }

    }

}
