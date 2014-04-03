using System;
using System.Windows.Forms;

using BinAff.Core;

using FacadeAccount = Vanilla.Guardian.Facade.Account;

using FacadeBuilding = AutoTourism.Lodge.Configuration.Facade.Building;
using FacadeRoom = AutoTourism.Lodge.Configuration.Facade.Room;

namespace AutoTourism.Lodge.Configuration.WinForm
{

    public partial class ReasonDialog : Form
    {

        private String FormName;        
        private BinAff.Facade.Library.Dto dto;
        private FacadeAccount.Dto userDto;

        public ReasonDialog(String formName, BinAff.Facade.Library.Dto dto, FacadeAccount.Dto userDto)
        {
            InitializeComponent();
            this.FormName = formName;
            this.dto = dto;
            this.userDto = userDto;
        }

        private void bttnOk_Click(object sender, EventArgs e)
        {
            if (ValidateReason())
            {
                ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
                FacadeBuilding.ReasonDto dto = new FacadeBuilding.ReasonDto()
                {
                    Reason = this.txtReason.Text.Trim(),
                    //Building = this.dto as FacadeBuilding.Dto,
                    UserAccount = userDto
                };

                if (this.FormName == "Building")
                {
                    dto.Building = this.dto as FacadeBuilding.Dto;
                    FacadeBuilding.IBuilding buildingServer = new FacadeBuilding.Server(new FacadeBuilding.FormDto
                    {
                        Dto = dto.Building
                    });
                    buildingServer.Close(dto);
                }
                else if (this.FormName == "Room")
                {
                    dto.Id = this.dto.Id; //Room ID
                    dto.Building = new FacadeBuilding.Dto 
                    { 
                        Id = ((FacadeRoom.Dto)this.dto).Building.Id
                    };

                    FacadeRoom.IRoom roomServer = new FacadeRoom.Server(new FacadeRoom.FormDto()); //Need to 
                    ret = roomServer.Close(dto);
                }

                //new PresentationLibrary.MessageBox(ret.MessageList).ShowDialog(this); //Show message 
                this.Close();
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidateReason()
        {            
            errorProvider.Clear();

            if (String.IsNullOrEmpty(txtReason.Text.Trim()))
            {
                errorProvider.SetError(txtReason, "Please enter closure reason.");
                txtReason.Focus();
                return false;
            }

            return true;
        }

    }

}
