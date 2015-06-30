using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

using RoomFac = Retinue.Lodge.Configuration.Facade.Room;

namespace Retinue.Lodge.WinForm
{

    public partial class ExtraBedCaptureForm : Form
    {

        public List<RoomFac.Dto> DataSource { get; set; }

        public Int32 TotalGuest
        {
            private get
            {
                return Convert.ToInt32(this.txtTotalGuest.Text);
            }
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            BinAff.Core.Message msg = this.ValidateForm();
            if (msg == null)
            {
                foreach (DataGridViewRow row in this.dgvRooms.Rows)
                {
                    row.Cells[3].Value = row.Cells[4].Value;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                new PresLib.MessageBox(this).Show(msg);
            }
        }

        private void PopulateRoomGrid()
        {
            this.dgvRooms.Columns[0].DataPropertyName = "Number";
            this.dgvRooms.Columns[1].DataPropertyName = "Name";
            this.dgvRooms.Columns[2].DataPropertyName = "Accomodation";
            this.dgvRooms.Columns[3].DataPropertyName = "ExtraAccomodation";
            this.dgvRooms.AutoGenerateColumns = false;

            this.dgvRooms.DataSource = this.DataSource;
        }

        private BinAff.Core.Message ValidateForm()
        {
            Int32 occupiedExtraBed = 0, availableBed = 0;
            foreach(DataGridViewRow row in this.dgvRooms.Rows)
            {
                if (Convert.ToInt32(row.Cells[3].Value) < Convert.ToInt32(row.Cells[4].Value))
                {
                    return new BinAff.Core.Message
                    {
                        Category = BinAff.Core.Message.Type.Error,
                        Description = String.Format("Extra accomodation available in room ({0}) is {1}, where assigned ({2}).",
                            row.Cells[0].Value, row.Cells[3].Value, row.Cells[4].Value),
                    };
                }
                occupiedExtraBed += Convert.ToInt32(row.Cells[4].Value);
                availableBed += Convert.ToInt32(row.Cells[2].Value);
            }
            if (this.TotalGuest != availableBed + occupiedExtraBed)
            {
                return new BinAff.Core.Message
                {
                    Category = BinAff.Core.Message.Type.Error,
                    Description = String.Format("Total number of accomodation ({0}) is not matching with occupied ({1}) accomodation(s).",
                        this.TotalGuest, availableBed + occupiedExtraBed),
                };
            }
            return null;
        }

    }

}