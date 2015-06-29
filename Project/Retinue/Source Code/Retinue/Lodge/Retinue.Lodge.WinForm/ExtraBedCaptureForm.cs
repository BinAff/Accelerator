using System;
using System.Collections.Generic;
using System.Windows.Forms;

using RoomFac = Retinue.Lodge.Configuration.Facade.Room;

namespace Retinue.Lodge.WinForm
{

    public partial class ExtraBedCaptureForm : Form
    {

        public List<RoomFac.Dto> DataSource { get; set; }
        public Int32 TotalGuest
        {
            set
            {
                this.txtTotalGuest.Text = value.ToString();
            }
        }

        public ExtraBedCaptureForm()
        {
            InitializeComponent();
            this.DataSource = new List<RoomFac.Dto>();
        }

        private void ExtraBedCaptureForm_Load(object sender, EventArgs e)
        {
            this.PopulateRoomGrid();
        }
        private void PopulateRoomGrid()
        {
            this.dgvRooms.Columns[0].DataPropertyName = "Number";
            this.dgvRooms.Columns[1].DataPropertyName = "Name";
            this.dgvRooms.Columns[2].DataPropertyName = "Accomodation";
            this.dgvRooms.Columns[3].DataPropertyName = "ExtraAccomodation";
            this.dgvRooms.Columns[4].DataPropertyName = "ExtraAccomodation";
            this.dgvRooms.AutoGenerateColumns = false;

            this.dgvRooms.DataSource = this.DataSource;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}