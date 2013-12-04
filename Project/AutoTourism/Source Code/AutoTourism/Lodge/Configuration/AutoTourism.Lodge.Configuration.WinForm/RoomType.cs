﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class RoomType : Form
    {

        Facade.Room.Type.FormDto formDto;

        public RoomType()
        {
            InitializeComponent();
        }

        private void RoomType_Load(object sender, EventArgs e)
        {
            this.formDto = new Facade.Room.Type.FormDto
            {
                Dto = new Facade.Room.Type.Dto(),
                DtoList = new List<Facade.Room.Type.Dto>(),
            };
            this.LoadForm();
            this.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.Name = this.txtName.Text.Trim();
            BinAff.Facade.Library.Server facade = new Facade.Room.Type.Server(this.formDto);
            facade.Add();
            this.RebindListBox();
            this.Clear();

            new BinAff.Presentation.Library.MessageBox
            {
                DialogueType = facade.IsError ? BinAff.Presentation.Library.MessageBox.Type.Error : BinAff.Presentation.Library.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.Id = (Int64)this.lslList.SelectedValue;
            this.formDto.Dto.Name = this.txtName.Text.Trim();
            BinAff.Facade.Library.Server facade = new Facade.Room.Type.Server(this.formDto);
            facade.Change();
            this.RebindListBox();
            this.Clear();

            new BinAff.Presentation.Library.MessageBox
            {
                DialogueType = facade.IsError ? BinAff.Presentation.Library.MessageBox.Type.Error : BinAff.Presentation.Library.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(facade.DisplayMessageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.formDto.Dto.Id = (Int64)this.lslList.SelectedValue;
            BinAff.Facade.Library.Server facade = new Facade.Room.Type.Server(this.formDto);
            facade.Delete();
            this.RebindListBox();
            this.Clear();

            new BinAff.Presentation.Library.MessageBox
            {
                DialogueType = facade.IsError ? BinAff.Presentation.Library.MessageBox.Type.Error : BinAff.Presentation.Library.MessageBox.Type.Information,
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
            this.txtName.Text = ((Facade.Room.Type.Dto)this.lslList.SelectedItem).Name;
        }

        private void LoadForm()
        {
            BinAff.Facade.Library.Server facade = new Facade.Room.Type.Server(this.formDto);
            facade.LoadForm();
            this.RebindListBox();
            if (facade.IsError)
            {
                new BinAff.Presentation.Library.MessageBox
                {
                    DialogueType = BinAff.Presentation.Library.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show(facade.DisplayMessageList);
            }
        }

        private void Clear()
        {
            this.txtName.Text = String.Empty;
            this.lslList.SelectedIndex = -1;
        }

        private void RebindListBox()
        {
            this.lslList.DataSource = null;
            this.lslList.DisplayMember = "Name";
            this.lslList.ValueMember = "Id";
            this.lslList.DataSource = this.formDto.DtoList;
        }

    }

}
