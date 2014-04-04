using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using BinAff.Core;
using BinAff.Presentation.Library.Extension;
using PresLib = BinAff.Presentation.Library;

namespace Vanilla.Tool.WinForm
{

    public partial class Appointment : Form
    {

        Facade.Diary.Appointment.FormDto formDto;

        public Appointment()
        {
            InitializeComponent();
        }

        public Appointment(Facade.Diary.Appointment.FormDto formDto)
            : this()
        {
            this.formDto = formDto;
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            this.LoadForm();
        }

        private void LoadForm()
        {
            Boolean isPopulationOfDataRequired = false;
            if (this.formDto == null)
            {
                this.formDto = new Facade.Diary.Appointment.FormDto
                {
                    TypeList = new List<Table>(),
                };
            }
            else
            {
                if (this.formDto.Dto != null)
                {
                    isPopulationOfDataRequired = true;
                }                
            }
            new Facade.Diary.Appointment.Server(this.formDto).LoadForm();

            this.cboType.DisplayMember = "Name";
            this.cboType.Bind(this.formDto.TypeList);

            this.cboImportance.DisplayMember = "Name";
            this.cboImportance.Bind(this.formDto.ImportanceList);
            if (isPopulationOfDataRequired)
            {
                this.PopulateForm();
            }
            else
            {
                this.Clear();
            }
        }

        private void PopulateForm()
        {
            this.txtTitle.Text = this.formDto.Dto.Title;
            if (this.formDto.Dto.Type != null)
            {
                this.cboType.SelectedIndex = this.cboType.FindStringExact(this.formDto.Dto.Type.Name);
            }
            this.txtDescription.Text = this.formDto.Dto.Description;
            this.txtLocation.Text = this.formDto.Dto.Location;
            this.SetDate(this.formDto.Dto.Start, this.dtpStart, this.cboStartTime);
            this.SetDate(this.formDto.Dto.End, this.dtpEnd, this.cboEndTime);

            if (this.formDto.Dto.Importance != null)
            {
                this.cboImportance.SelectedIndex = this.cboImportance.FindStringExact(this.formDto.Dto.Importance.Name);
            }

            if(this.formDto.Dto.Reminder == null)
            {
                this.dtpReminder.Value = DateTime.Today;
                this.cboReminderTime.SelectedIndex = -1;
            }
            else
            {
                this.SetDate((DateTime)this.formDto.Dto.Reminder, this.dtpReminder, this.cboReminderTime);
                //this.dtpReminder.Value = (DateTime)this.formDto.Dto.Reminder;
                //this.cboReminderTime.SelectedIndex = this.cboReminderTime.FindStringExact(((DateTime)this.formDto.Dto.Reminder).ToShortTimeString());
            }   
        }

        private void Clear()
        {
            this.txtTitle.Text = String.Empty;
            this.txtLocation.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.cboImportance.SelectedIndex = 1;
            this.cboType.SelectedIndex = 1;
            this.dtpStart.Value = DateTime.Now;
            this.dtpEnd.Value = DateTime.Now;
            this.dtpReminder.Value = DateTime.Now;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
            {
                if (this.formDto.Dto == null) this.formDto.Dto = new Facade.Diary.Appointment.Dto();
                this.formDto.Dto.Title = this.txtTitle.Text.Trim();
                this.formDto.Dto.Start = this.GetDate(this.dtpStart.Value, this.cboStartTime.Text);
                this.formDto.Dto.End = this.GetDate(this.dtpEnd.Value, this.cboEndTime.Text);
                this.formDto.Dto.Type = this.cboType.SelectedItem as Table;
                this.formDto.Dto.Importance = this.cboImportance.SelectedItem as Table;
                this.formDto.Dto.Location = this.txtLocation.Text.Trim();
                this.formDto.Dto.Description = this.txtDescription.Text.Trim();
                this.formDto.Dto.Reminder = this.GetDate(this.dtpReminder.Value, this.cboReminderTime.Text);

                Facade.Diary.Appointment.Server facade = new Facade.Diary.Appointment.Server(this.formDto);
                if (this.formDto.Dto.Id == 0)
                {
                    facade.Add();
                }
                else
                {
                    facade.Change();
                }
                if (facade.DisplayMessageList != null || facade.DisplayMessageList.Count > 0)
                {
                    new PresLib.MessageBox
                    {
                        DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                        Heading = "Splash",
                    }.Show(facade.DisplayMessageList);
                }
            }
        }

        private DateTime GetDate(DateTime date, String time)
        {
            return new DateTime(date.Year, date.Month, date.Day,
                Convert.ToInt32(time.Split(':')[0]) + Convert.ToInt32(String.Compare(time.Split(':')[1].Split(' ')[1], "PM") == 0 ? 12 : 0),
                Convert.ToInt32(time.Split(':')[1].Split(' ')[0]),
                0);
        }

        private void SetDate(DateTime dateTime, DateTimePicker dtp, ComboBox time)
        {
            dtp.Value = dateTime;
            time.SelectedIndex = time.FindStringExact(dateTime.ToString("h:mm tt"));
        }        

        private Boolean ValidateForm()
        {
            this.errorProvider.Clear();

            //validate mandatory
            if (String.IsNullOrEmpty(this.txtTitle.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtTitle, "Please enter Title.");
                this.txtTitle.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtLocation.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtLocation, "Please enter Location.");
                this.txtLocation.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtDescription.Text.Trim()))
            {
                this.errorProvider.SetError(this.txtDescription, "Please enter Description.");
                this.txtDescription.Focus();
                return false;
            }

            if (DateTime.Compare(DateTime.Now, this.GetDate(this.dtpStart.Value, this.cboEndTime.Text)) > 0)
            {
                this.errorProvider.SetError(this.dtpEnd, "Start of appointment cannot be before current date and time.");
                this.dtpStart.Focus();
                return false;
            }
            if (DateTime.Compare(DateTime.Now, this.GetDate(this.dtpEnd.Value, this.cboEndTime.Text)) > 0)
            {
                this.errorProvider.SetError(this.dtpEnd, "End of appointment cannot be before current date and time.");
                this.dtpEnd.Focus();
                return false;
            }
            if (DateTime.Compare(DateTime.Now, this.GetDate(this.dtpReminder.Value, this.cboEndTime.Text)) > 0)
            {
                this.errorProvider.SetError(this.dtpEnd, "Reminder of appointment cannot be before current date and time.");
                this.dtpReminder.Focus();
                return false;
            }

            if (DateTime.Compare(this.GetDate(this.dtpStart.Value, this.cboStartTime.Text), this.GetDate(this.dtpEnd.Value, this.cboEndTime.Text)) > 0)
            {
                this.errorProvider.SetError(this.dtpEnd, "Start of appointment cannot be later than End of appointment.");
                this.dtpEnd.Focus();
                return false;
            }
            if (DateTime.Compare(this.GetDate(this.dtpReminder.Value, this.cboReminderTime.Text), this.GetDate(this.dtpStart.Value, this.cboStartTime.Text)) > 0)
            {
                this.errorProvider.SetError(this.dtpReminder, "Reminder of appointment cannot be later than Start of appointment.");
                this.dtpReminder.Focus();
                return false;
            }

            return true;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpStart.Value > this.dtpEnd.Value)
            {
                this.dtpEnd.Value = this.dtpStart.Value;
            }
            if (this.dtpStart.Value > this.dtpReminder.Value)
            {
                this.dtpReminder.Value = this.dtpStart.Value;
            }
        }

    }

}