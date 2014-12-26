using System;
using System.Text;
using System.Collections.Generic;

using BinAff.Core;

namespace BinAff.Presentation.Library
{

    public partial class MessageBox : System.Windows.Forms.Form
    {

        private Type dialogueType;
        /// <summary>
        /// Type of dialogue box
        /// </summary>
        public Type DialogueType
        {
            get
            {
                return this.dialogueType;
            }
            set
            {
                this.dialogueType = value;
                System.Drawing.Bitmap icon = Properties.Resources.Information;
                switch (value)
                {
                    case Type.Error:
                        icon = Properties.Resources.Error;
                        break;
                    case Type.Information:
                        icon = Properties.Resources.Information;
                        break;
                    case Type.Alert:
                        icon = Properties.Resources.Alert;
                        break;
                    default:
                        icon = Properties.Resources.Information;
                        break;
                }
                this.picIcon.Image = icon;
                if (String.IsNullOrEmpty(this.Text)) this.Heading = value.ToString();
            }
        }

        /// <summary>
        /// Heading of dialogue box
        /// </summary>
        public String Heading
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (this.dialogueType == null)
                    {
                        this.dialogueType = Type.Information;
                    }
                    this.Text = this.dialogueType.ToString();
                }
                else
                {
                    this.Text = value;
                }
            }
        }

        System.Windows.Forms.IWin32Window owner;

        public MessageBox()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        public MessageBox(System.Windows.Forms.IWin32Window owner)
            : this()
        {
            this.owner = owner;
        }

        public void Show(String message)
        {
            this.txtMessage.Text = message;
            if (this.owner != null)
            {
                this.ShowDialog(this.owner);
            }
            else
            {
                this.ShowDialog();
            }
        }

        public void Show(List<String> messageList)
        {
            this.Show(this.CreateString(messageList));
        }

        public void Show(Message message)
        {
            this.dialogueType = this.Convert(message.Category);
            this.Show(message.Description);
        }

        public void Show(List<Message> messageList)
        {
            this.CreateStringAndShow(messageList);
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

        private String CreateString(List<String> messageList)
        {
            StringBuilder str = new StringBuilder();
            Int32 count = messageList.Count;
            for (Int16 i = 0; i < count; i++)
            {
                str.Append(messageList[i]);
                if (i < count - 1) str.Append("\r\n");
            }
            return str.ToString();
        }

        private void CreateStringAndShow(List<Message> messageList)
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
            this.dialogueType = type;
            this.Show(str.ToString());
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
