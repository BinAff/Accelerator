using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vanilla.Tool.WinForm
{

    public partial class Calender : Form
    {

        Facade.Diary.Calender.FormDto formDto;

        public Calender()
        {
            InitializeComponent();
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            this.formDto = new Facade.Diary.Calender.FormDto
            {
                AppointmentList = new List<Facade.Diary.Calender.Dto>()
            };
            this.dgvAppointmentList.ColumnAdded += dgvAppointmentList_ColumnAdded;
        }

        void dgvAppointmentList_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "Message")
            {
                e.Column.Width = this.dgvAppointmentList.Width - 150;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.RefreshGrid();
        }

        private void dgvAppointmentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && !String.IsNullOrEmpty(Convert.ToString(e.Value)) )
            {
                e.CellStyle.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void dgvAppointmentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Facade.Diary.Appointment.FormDto appointmentFormDto = new Facade.Diary.Appointment.FormDto();
            if (this.formDto.AppointmentList[e.RowIndex].AppointmentList == null)
            {
                DateTime time = Convert.ToDateTime(this.formDto.AppointmentList[e.RowIndex].Time);
                DateTime start = new DateTime(this.dtpDate.Value.Year,this.dtpDate.Value.Month, this.dtpDate.Value.Day,
                    time.Hour, time.Minute, 0);
                appointmentFormDto.Dto = new Facade.Diary.Appointment.Dto
                {
                    Start = start,
                    End = start.AddMinutes(30),
                    Reminder = start.Subtract(new TimeSpan(0, 15, 0)),
                };
            }
            else
            {
                appointmentFormDto.Dto = this.formDto.AppointmentList[e.RowIndex].AppointmentList[0];
            }
            new Appointment(appointmentFormDto).ShowDialog();
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            this.dgvAppointmentList.DataSource = new Facade.Diary.Calender.Server(this.formDto).Search(this.dtpDate.Value).ConvertAll( c =>
            {
                return new
                {
                    c.Time,
                    c.Message
                };
            });
        }

    }

}
