using System;
using System.Text;
using System.Collections.Generic;

using BinAff.Core;
using System.Drawing;

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
                switch (value)
                {
                    case Type.Error:
                        this.lblIcon.Text = "U";
                        this.lblIcon.Font = new Font("Wingdings 2", 22);
                        this.lblIcon.ForeColor = Color.Red;
                        break;
                    case Type.Information:
                        this.lblIcon.Text = "i";
                        this.lblIcon.Font = new Font("Webdings", 22);
                        this.lblIcon.ForeColor = Color.Green;
                        break;
                    case Type.Alert:
                        this.lblIcon.Text = "!";
                        this.lblIcon.Font = new Font("Arial", 22);
                        this.lblIcon.ForeColor = Color.Orange;
                        break;
                    case Type.Question:
                        this.lblIcon.Text = "?";
                        this.lblIcon.Font = new Font("Arial", 22);
                        this.lblIcon.ForeColor = Color.Black;
                        this.AcceptButton = this.btnOk;
                        this.CancelButton = this.btnCancel;
                        break;
                    default:
                        this.lblIcon.Text = "i";
                        this.lblIcon.Font = new Font("Webdings", 22);
                        this.lblIcon.ForeColor = Color.Green;
                        break;
                }
                if (String.IsNullOrEmpty(this.Text)) this.Heading = value.ToString();
            }
        }

        //public Boolean IsWithOption
        //{
        //    private get
        //    {
        //        return this.btnCancel.Visible;
        //    }
        //    set
        //    {
        //        this.btnCancel.Visible = false;
        //    }
        //}

        public Confirmation Result { get; set; }

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

        private void MessageBox_Load(object sender, EventArgs e)
        {
            if (!this.btnCancel.Visible) //Move Ok button at end if cancel button is not there
            {
                this.btnOk.Top = this.btnCancel.Top;
                this.btnOk.Left = this.btnCancel.Left;
            }
        }

        private void btnCancel_VisibleChanged(object sender, EventArgs e)
        {
            //if (!this.btnCancel.Visible) //Move Ok button at end if cancel button is not there
            //{
            //    this.btnOk.Top = this.btnCancel.Top;
            //    this.btnOk.Left = this.btnCancel.Left;
            //}
        }

        public void Show(String message)
        {
            this.txtMessage.Text = message;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            System.Windows.Forms.DialogResult result;
            if (this.owner != null)
            {
                this.ShowDialog(this.owner);
            }
            else
            {
                result = this.ShowDialog();
            }
        }

        public System.Windows.Forms.DialogResult Confirm(String message)
        {
            this.txtMessage.Text = message;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.btnCancel.Visible = true;
            System.Windows.Forms.DialogResult result;
            if (this.owner != null)
            {
                result = this.ShowDialog(this.owner);
            }
            else
            {
                result = this.ShowDialog();
            }
            return result;
        }

        public void Show(List<String> messageList)
        {
            this.Show(this.CreateString(messageList));
        }

        public void Show(Message message)
        {
            this.DialogueType = this.Convert(message.Category);
            this.Show(message.Description);
        }

        public System.Windows.Forms.DialogResult Confirm(Message message)
        {
            this.DialogueType = this.Convert(message.Category);
            return this.Confirm(message.Description);
        }

        public void Show(List<Message> messageList)
        {
            this.CreateStringAndShow(messageList);
        }

        private Type Convert(Message.Type type)
        {
            switch (type)
            {
                case Message.Type.Error:
                    return Type.Error;
                case Message.Type.Information:
                    return Type.Information;
                case Message.Type.Question:
                    return Type.Question;
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
            //this.Result = MessageBox.Confirmation.Ok;
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Result = MessageBox.Confirmation.Ok;
            //this.Close();
        }

        public enum Type
        {
            Alert,
            Information,
            Error,
            Question
        }

        public enum Confirmation
        {
            Ok,
            Cancel
        }

    }

}
