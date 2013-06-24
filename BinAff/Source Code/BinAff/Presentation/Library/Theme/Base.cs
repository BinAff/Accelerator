using System.Drawing;

namespace BinAff.Presentation.Library.Theme
{

    public abstract class Base
    {

        private Color formColor;
        public Color FormColor
        {
            get
            {
                return formColor;
            }
            protected set
            {
                formColor = value;
            }
        }

    }
}
