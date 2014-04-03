using System;
using System.Windows.Forms;

namespace Vanilla.Tool.WinForm
{
    public partial class Calender : Form
    {

        Facade.Diary.Appointment.FormDto formDto;

        public Calender()
        {
            InitializeComponent();
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.dgvAppointmentList.DataSource = new Facade.Diary.Calender.Server(null).Search(this.dtpDate.Value).ConvertAll(c => new
            {
                c.Start,
                c.Description
            });
        }

        private void dgvAppointmentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && !String.IsNullOrEmpty(Convert.ToString(e.Value)) )
            {
                e.CellStyle.BackColor = System.Drawing.Color.Gray;
            }
        }

    }

}
