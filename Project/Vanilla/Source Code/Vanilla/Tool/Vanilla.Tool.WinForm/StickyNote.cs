using System;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Vanilla.Tool.WinfForm
{
    public partial class StickyNote : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private static List<StickyNote> notes;
        private Int32 shownHeight;
        private Boolean isInternallyClosed;

        private static Control.ControlCollection containerControl;

        private StickyNote()
        {
            InitializeComponent();
            pnlTitleBar.MouseDown += new MouseEventHandler(pnlTitleBar_MouseDown);
            this.FormClosed += new FormClosedEventHandler(StickyNote_FormClosed);
        }

        private void StickyNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.isInternallyClosed) Quit();
        }

        static StickyNote()
        {
            notes = new List<StickyNote>();
        }

        public static StickyNote Create(Form mdiParent)
        {
            StickyNote note = new StickyNote
            {
                ShowInTaskbar = false,
                MdiParent = mdiParent
            };
            notes.Add(note);
            return note;
        }

        public static StickyNote Create(Control.ControlCollection controlCollection)
        {
            containerControl = controlCollection;
            StickyNote note = new StickyNote
            {
                ShowInTaskbar = false,
                TopLevel = false,
            };
            notes.Add(note);
            controlCollection.Add(note);
            return note;
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ((StickyNote)((Panel)sender).Parent).BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void Quit()
        {
            if (notes.Count > 0)
            {
                if (MessageBox.Show("There are unsaved notes. Do you want to save those?", "Alert!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StringBuilder strbNoteXML = new StringBuilder();
                    strbNoteXML.Append("<root>");
                    foreach (StickyNote note in notes)
                    {
                        //Save in file / database
                        strbNoteXML.Append(note.GetNoteXMLData(note));

                        note.isInternallyClosed = true;
                        note.Close();
                    }
                    strbNoteXML.Append("</root>");

                    StickyNote noteXMLData = new StickyNote();
                    noteXMLData.SaveNoteXMLData(strbNoteXML.ToString());
                }
                else
                {
                    foreach (StickyNote note in notes)
                    {
                        note.isInternallyClosed = true;
                        note.Close();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StickyNote note = new StickyNote
            {
                ShowInTaskbar = false,
                TopLevel = false,
                Top = this.Top + 50,
                Left = this.Left + 50,
                StartPosition = FormStartPosition.Manual
            };

            if (containerControl != null)
            {
                containerControl.Add(note);
            }
            notes.Add(note);

            note.BringToFront();
            note.Show();
            this.txtMsg.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the note?", "Alert!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.isInternallyClosed = true;
                this.Close();
                notes.Remove(this);
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (this.btnHide.Text == "▼") //Hidden
            {
                //Show
                this.btnHide.Text = "▲";
                this.Height = this.shownHeight;
                this.lblTitle.Text = "";
            }
            else
            {
                //Hide
                this.btnHide.Text = "▼";
                this.shownHeight = this.Height;
                this.Height = this.pnlTitleBar.Height;
                this.lblTitle.Text 
                    = this.txtMsg.Text.Length > 10 ?
                        this.txtMsg.Text.Substring(0, 10) + "..."
                        : this.txtMsg.Text.Substring(0, this.txtMsg.Text.Length);

            }
        }

        private void HideSticky()
        {
            this.btnHide.Text = "▼";
            this.shownHeight = this.Height;
            this.Height = this.pnlTitleBar.Height;
            this.lblTitle.Text
                = this.txtMsg.Text.Length > 10 ?
                    this.txtMsg.Text.Substring(0, 10) + "..."
                    : this.txtMsg.Text.Substring(0, this.txtMsg.Text.Length);
        }

        public static void LoadStickyFromFileSystem(Form mdiParent)
        {
            String DirectoryName = "Sticky";
            String FileName = "sticky.xml";
            String stickyPath = Application.StartupPath + "\\" + DirectoryName;
            String stickyFileName = stickyPath + "\\" + FileName;

            if (System.IO.File.Exists(stickyFileName))
            {
                XmlTextReader reader = new XmlTextReader(stickyFileName);
                while (reader.Read())
                {
                    if (reader.Name == "notecontent")
                    {
                        StickyNote note = new StickyNote
                        {
                            ShowInTaskbar = false,
                            MdiParent = mdiParent,
                            Top = reader.GetAttribute("NoteTop") == null ? 50 : Convert.ToInt32(reader.GetAttribute("NoteTop")),
                            Left = reader.GetAttribute("NoteLeft") == null ? 50 : Convert.ToInt32(reader.GetAttribute("NoteLeft")),
                            StartPosition = FormStartPosition.Manual,
                        };
                        note.txtMsg.Text = reader.GetAttribute("NoteText") == null ? String.Empty : reader.GetAttribute("NoteText");

                        if (reader.GetAttribute("NoteHide") == "Y")
                            note.HideSticky();

                        notes.Add(note);
                        note.Show();
                    }
                }
                reader.Close();
                System.IO.File.Delete(stickyFileName);
            }
        }

        private String GetNoteXMLData(StickyNote note)
        {
            String Hide = note.btnHide.Text == "▼" ? "Y" : "N";
            return "<notecontent text='" + note.txtMsg.Text + "' Top='" + note.Top + "' Left='" + note.Left + "' Hide='" + Hide + "' />";
        }

        private void SaveNoteXMLData(String NoteXMLData)
        {
            //String path = Application.ExecutablePath;
            String DirectoryName = "Sticky";
            String FileName = "sticky.xml";
            String stickyPath = Application.StartupPath + "\\" + DirectoryName;
            String stickyFileName = stickyPath + "\\" + FileName;

            //create directory if does not exists
            if (!System.IO.Directory.Exists(stickyPath))
                System.IO.Directory.CreateDirectory(stickyPath);

            //Hide the sticky folder
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(stickyPath);
            di.Attributes = System.IO.FileAttributes.Hidden;

            //delete the xml file if exists
            if (System.IO.File.Exists(stickyFileName))
                System.IO.File.Delete(stickyFileName);

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Sticky");
            xmlDoc.AppendChild(rootNode);

            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(NoteXMLData));
            while (reader.Read())
            {
                if (reader.Name == "notecontent")
                {
                    XmlNode userNode = xmlDoc.CreateElement("notecontent");

                    XmlAttribute attribute = xmlDoc.CreateAttribute("NoteText");
                    attribute.Value = reader.GetAttribute("text");
                    userNode.Attributes.Append(attribute);

                    attribute = xmlDoc.CreateAttribute("NoteTop");
                    attribute.Value = reader.GetAttribute("Top");
                    userNode.Attributes.Append(attribute);

                    attribute = xmlDoc.CreateAttribute("NoteLeft");
                    attribute.Value = reader.GetAttribute("Left");
                    userNode.Attributes.Append(attribute);

                    attribute = xmlDoc.CreateAttribute("NoteHide");
                    attribute.Value = reader.GetAttribute("Hide");
                    userNode.Attributes.Append(attribute);

                    rootNode.AppendChild(userNode);
                }
            }

            reader.Close();
            xmlDoc.Save(stickyFileName);
            //hide the sticky xml file
            System.IO.File.SetAttributes(stickyFileName, System.IO.File.GetAttributes(stickyFileName) | System.IO.FileAttributes.Hidden);


            //using (XmlWriter writer = XmlWriter.Create(stickyFileName))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("Sticky");

            //    XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(NoteXMLData));
            //    while (reader.Read())
            //    {
            //        if (reader.Name == "notecontent")
            //        {
            //            writer.WriteStartElement("notecontent");
            //            writer.WriteElementString("NoteText", reader.GetAttribute("text"));
            //            writer.WriteElementString("NoteTop", reader.GetAttribute("Top"));
            //            writer.WriteElementString("NoteLeft", reader.GetAttribute("Left"));
            //            writer.WriteElementString("NoteHide", reader.GetAttribute("Hide"));
            //            writer.WriteEndElement();
            //        }
            //    }

            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}

        }

    }

}
