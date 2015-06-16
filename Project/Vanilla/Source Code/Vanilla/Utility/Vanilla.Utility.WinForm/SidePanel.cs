using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PresLib = BinAff.Presentation.Library;

namespace Vanilla.Utility.WinForm
{

    public partial class SidePanel : UserControl
    {

        private Int32 width;

        [Description("Title bar of side panel"), Category("Configuration")]
        public String TitleBar
        {
            get
            {
                return this.lblTitleBar.Text;
            }
            set
            {
                this.lblTitleBar.Text = value;
            }
        }

        private List<Option> options;
        //[Description("Options to display"), Category("Configuration")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Option> Options
        {
            get
            {
                return this.options;
            }
            set
            {
                if (value == null || value.Count == 0) return;
                this.options = value;

                this.pnlOptions.Controls.Clear();
                this.pnlOptions.ColumnStyles.Clear();
                Int32 count = this.options.Count;
                Int32 i = 0;
                foreach (Option option in this.options)
                {
                    option.NameChanged += delegate(String oldName, String newName)
                    {
                        foreach (Label item in this.pnlOptions.Controls)
                        {
                            if (String.Compare(item.Text, oldName) == 0) item.Text = newName;
                        }
                    };

                    Label label = new Label
                    {                        
                        Text = option.Name,
                        AutoSize = true,
                        Padding = new Padding(0, 0, 0, 0),
                    };
                    label.MouseEnter += delegate(object sender, EventArgs e)
                    {
                        (sender as Label).BackColor = SystemColors.ControlDark;
                    };
                    label.MouseLeave += delegate(object sender, EventArgs e)
                    {
                        (sender as Label).BackColor = SystemColors.Control;
                    };

                    label.Click += label_Click;

                    option.VerticalHeading = new PresLib.VerticalLabel
                    {
                        Text = option.Name,
                        BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                        Dock = DockStyle.Top,
                        IsFlipped = option.IsFlipped,
                        Height = 100,
                    };
                    this.pnlOptions.Controls.Add(label, i++, 0);
                }
            }
        }

        [Description("Control bar will be shown at top"), Category("Configuration")]
        public Boolean IsControlBarVisible
        {
            get
            {
                return this.pnlControlBar.Visible;
            }
            set
            {
                this.pnlControlBar.Visible = value;
            }
        }

        [Description("Dock Position of control bar"), Category("Configuration")]
        public DockStyle ControlBarPosition
        {
            get
            {
                return this.pnlControlBar.Dock;
            }
            set
            {
                if (value == DockStyle.Fill || value == DockStyle.None) return;
                this.pnlControlBar.Dock = value;
            }
        }

        public BindingList<Button> buttons;
        [Description("Controls in control bar"), Category("Configuration")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BindingList<Button> ControlButtons
        {
            get
            {
                return this.buttons;
            }
            set
            {
                if (this.buttons == null || this.buttons.Count == 0) return;
                this.buttons = value;

                this.pnlControlBar.Controls.Clear();

                Int32 count = this.options.Count;
                Int32 i = 0;
                foreach (Button controlButton in this.buttons)
                {
                    this.pnlControlBar.Controls.Add(controlButton);
                    controlButton.BringToFront();
                //    option.NameChanged += delegate(String oldName, String newName)
                //    {
                //        foreach (Label item in this.pnlOptions.Controls)
                //        {
                //            if (String.Compare(item.Text, oldName) == 0) item.Text = newName;
                //        }
                //    };
                //    label.MouseEnter += delegate(object sender, EventArgs e)
                //    {
                //        (sender as Label).BackColor = SystemColors.ControlDark;
                //    };
                //    label.MouseLeave += delegate(object sender, EventArgs e)
                //    {
                //        (sender as Label).BackColor = SystemColors.Control;
                //    };

                //    label.Click += label_Click;

                //    this.pnlOptions.Controls.Add(label, i++, 0);
                }
            }
        }

        public delegate void OnClose(EventArgs e);
        public event OnClose ClosePanel;

        public delegate void OnShow(EventArgs e);
        public event OnShow ShowPanel;

        public SidePanel()
        {
            InitializeComponent();
            this.options = new List<Option>();
            //this.options.ListChanged += delegate(object sender, ListChangedEventArgs e)
            //{
            //    this.Options = this.options;
            //};
            this.buttons = new BindingList<Button>();
            this.buttons.ListChanged += delegate(object sender, ListChangedEventArgs e)
            {
                this.ControlButtons = this.buttons;
            };
            this.pnlContainer.Dock = DockStyle.Fill;
        }

        private void SidePanel_Load(object sender, EventArgs e)
        {
            this.ShowOption(0); //Show first tab in side panel load
        }

        void label_Click(object sender, EventArgs e)
        {
            this.SetColorToLabel((sender as Label).Text);
            if (this.options != null)
            {
                foreach (Option option in this.options)
                {
                    if (String.Compare(option.Name, (sender as Label).Text) == 0)
                    {
                        if (option.Content == null)
                        {
                            this.pnlContainer.Controls.Clear();
                        }
                        else
                        {
                            this.AddContentToContainer(option);
                        }
                        break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.ClosePanel != null) this.ClosePanel(e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Show();
            this.pnlOptions.Show();
            this.pnlControlBar.Show();
            this.btnClose.Show();
            this.btnHide.Show();

            this.btnShow.Hide();
            foreach (Option option in this.Options)
            {
                this.Controls.Remove(option.VerticalHeading);
            }

            if (this.ShowPanel != null) this.ShowPanel(e);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            //Need to show icons in left side
            this.pnlContainer.Hide();
            this.pnlOptions.Hide();
            this.pnlControlBar.Hide();
            this.btnClose.Hide();
            this.btnHide.Hide();

            this.btnShow.Show();
            foreach (Option option in this.Options)
            {
                this.Controls.Add(option.VerticalHeading);
                option.VerticalHeading.Dock = DockStyle.Top;
            }

            if (this.ClosePanel != null) this.ClosePanel(e);
            this.pnlTitleBar.SendToBack();
        }

        private void SidePanel_Resize(object sender, EventArgs e)
        {
            if (this.Width > 22) this.width = this.Width;
        }

        public void ShowOption(Option option)
        {
            this.SetColorToLabel(option.Name);
            if (option.Content == null)
            {
                this.pnlContainer.Controls.Clear();
            }
            else
            {
                this.AddContentToContainer(option);
            }
        }

        public void ShowOption(Int32 index)
        {
            if (this.options != null && this.options.Count > 0 && index >= 0 && this.options.Count > index)
            {
                this.ShowOption(this.options[index]);
            }
        }

        private void AddContentToContainer(Option option)
        {
            this.pnlContainer.Controls.Add(option.Content);
            option.Content.Dock = DockStyle.Fill;
            option.Content.BringToFront();
            option.Content.Show();
        }

        private void SetColorToLabel(String name)
        {
            foreach (Label label in this.pnlOptions.Controls)
            {
                label.ForeColor = String.Compare(label.Text, name) == 0 ? SystemColors.MenuHighlight : SystemColors.ControlText;
            }
        }

        public class Option
        {

            private String name;
            public String Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    if (value == null) value = String.Empty;
                    if (this.NameChanged != null) this.NameChanged(this.name, value);
                    this.name = value;
                }
            }

            public Control Content { get; set; }

            public Form ViewForm { get; set; }

            internal Label VerticalHeading { get; set; }

            public Boolean IsFlipped { get; set; }

            public Facade.Document.Dto Dto { get; set; }

            public delegate void OnNameChanged(String oldName, String newName);
            public event OnNameChanged NameChanged;

        }

        public class ControlButton
        {

            public String Name { get; set; }
            public String Text { get; set; }
            public String ToolTipText { get; set; }
            public Font Font { get; set; }

        }

    }

}