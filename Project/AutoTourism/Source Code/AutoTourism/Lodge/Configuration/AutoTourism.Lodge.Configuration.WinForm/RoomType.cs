using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;
using FacLib = BinAff.Facade.Library;
using BinAff.Presentation.Library.Extension;

using RoomTypeFac = AutoTourism.Lodge.Configuration.Facade.Room.Type;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class RoomType : Form
    {

        RoomTypeFac.FormDto formDto;

        public RoomType()
        {
            InitializeComponent();
        }

        #region Events

        private void RoomType_Load(object sender, EventArgs e)
        {
            this.formDto = new RoomTypeFac.FormDto
            {
                Dto = new RoomTypeFac.Dto(),
                DtoList = new List<RoomTypeFac.Dto>(),
            };
            this.LoadForm();
            this.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.Name = this.txtName.Text.Trim();
            this.formDto.Dto.Accomodation = Convert.ToInt16(this.txtAccomodation.Text.Trim());
            this.formDto.Dto.ExtraAccomodation = Convert.ToInt16(this.txtExtraAccomodation.Text.Trim());
            FacLib.Server facade = new RoomTypeFac.Server(this.formDto);
            facade.Add();
            this.lslList.Items.Add(this.formDto.Dto);
            this.Clear();

            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.formDto.Dto = this.lslList.SelectedItem as RoomTypeFac.Dto;
            this.formDto.Dto.Name = this.txtName.Text.Trim();
            this.formDto.Dto.Accomodation = Convert.ToInt16(this.txtAccomodation.Text.Trim());
            this.formDto.Dto.ExtraAccomodation = Convert.ToInt16(this.txtExtraAccomodation.Text.Trim());
            FacLib.Server facade = new RoomTypeFac.Server(this.formDto);
            facade.Change();
            this.Clear();

            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.Id = (Int64)this.lslList.SelectedValue;
            FacLib.Server facade = new RoomTypeFac.Server(this.formDto);
            facade.Delete();
            this.lslList.Items.Remove(this.lslList.SelectedItem);
            this.Clear();

            new PresLib.MessageBox
            {
                DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadForm();
            this.Clear();
        }

        private void lslList_Click(object sender, EventArgs e)
        {
            RoomTypeFac.Dto dto = this.lslList.SelectedItem as RoomTypeFac.Dto;
            this.txtName.Text = dto.Name;
            this.txtAccomodation.Text = dto.Accomodation.ToString();
            this.txtExtraAccomodation.Text = dto.ExtraAccomodation.ToString();
        }

        #endregion

        private void LoadForm()
        {
            FacLib.Server facade = new RoomTypeFac.Server(this.formDto);
            facade.LoadForm();
            this.lslList.Bind(this.formDto.DtoList, "Name");
            if (facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Error",
                }.Show(facade.DisplayMessageList);
            }
        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.txtAccomodation.Text = String.Empty;
            this.txtExtraAccomodation.Text = String.Empty;
            this.lslList.Items.Clear();
            this.lslList.Bind(this.formDto.DtoList);
            this.lslList.SelectedIndex = -1;
        }

    }

}