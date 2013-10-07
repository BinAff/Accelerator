using System;
using System.Text;
using System.Collections.Generic;

using BinAff.Core;

namespace BinAff.Presentation.Library
{

    public partial class MessageBox : System.Windows.Forms.Form
    {

        public MessageBox(String message, Type type)
        {
            this.Initiate();
            this.Show(message, type, null);
        }

        public MessageBox(String message, Type type, String heading)
        {
            this.Initiate();
            this.Show(message, type, heading);
        }

        public MessageBox(BinAff.Core.Message message)
        {
            this.Initiate();
            this.Show(message.Description, this.Convert(message.Category), null);
        }

        public MessageBox(BinAff.Core.Message message, String heading)
        {
            this.Initiate();
            this.Show(message.Description, this.Convert(message.Category), heading);
        }

        public MessageBox(List<Message> messageList)
        {
            this.Initiate();
            this.MakeString(messageList, null);
        }

        public MessageBox(List<Message> messageList, String heading)
        {
            this.Initiate();
            this.MakeString(messageList, heading);
        }

        private void Show(String message, Type type, String heading)
        {
            this.txtMessage.Text = message;
            String title;
            switch (type)
            {
                case Type.Error:
                    this.picIcon.Image = Properties.Resources.Error;
                    title = "Error";
                    break;
                case Type.Information:
                    this.picIcon.Image = Properties.Resources.Information;
                    title = "Information";
                    break;
                case Type.Alert:
                    this.picIcon.Image = Properties.Resources.Alert;
                    title = "Alert";
                    break;
                default:
                    this.picIcon.Image = Properties.Resources.Information;
                    title = "Information";
                    break;
            }
            this.Text = heading == null ? title : heading;
        }

        private void Initiate()
        {
            InitializeComponent();
        }

        private Type Convert(Message.Type type)
        {
            switch (type)
            {
                case BinAff.Core.Message.Type.Error:
                    return Type.Error;
                case BinAff.Core.Message.Type.Information:
                    return Type.Information;
                default:
                    return Type.Information;
            }
        }

        private void MakeString(List<Message> messageList, String heading)
        {
            StringBuilder str = new StringBuilder();
            Type type = Type.Information;
            Int32 count = messageList.Count;
            for (Int16 i = 0; i < count; i++)
            {
                str.Append(messageList[i].Description);
                if (i < count - 1) str.Append("\r\n");
                if (type != Type.Error) type = Convert(messageList[i].Category);
            }
            this.Show(str.ToString(), type, heading);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public enum Type
        {
            Alert,
            Information,
            Error
        }

    }

}
