using System.Windows.Forms;

namespace AutoTourism.Lodge.WinForm
{
    public partial class RoomCatalogue : Form
    {
        private static RoomCatalogue roomCatalogue;

        private RoomCatalogue()
        {
            InitializeComponent();
        }

        public static RoomCatalogue Create(Form mdiParent)
        {
            if (roomCatalogue == null || roomCatalogue.IsDisposed)
                roomCatalogue = new RoomCatalogue
                {
                    ShowInTaskbar = false,
                    MdiParent = mdiParent
                };
            else
                roomCatalogue.Focus();
            return roomCatalogue;
        }
    }
}
