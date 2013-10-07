using BinAffLib = BinAff.Facade.Library;

namespace Vanilla.Navigator.Facade.MenuSummary
{
    public class Dto : BinAffLib.Dto
    {

        public DetailMenu.Dto detailMenu;
        public DetailMenu.Dto DetailMenu
        {
            get
            {
                return this.detailMenu;
            }
            set
            {
                if (value != null && this.detailMenu != value)
                {
                    this.detailMenu = value;
                    //this.detailMenu.Dock = DockStyle.Fill;
                }
            }
        }

        private Body.Dto body;
        public Body.Dto Body
        {
            get
            {
                return this.body;
            }
            set
            {
                if (value != null && this.body != value)
                {
                    this.body = value;
                    //this.body.Dock = DockStyle.Fill;
                    this.body.PathChanged += new Body.ChangePath(Body_PathChange);
                }
            }
        }

    }
}
