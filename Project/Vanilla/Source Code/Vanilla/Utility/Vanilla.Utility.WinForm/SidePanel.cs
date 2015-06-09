using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class SidePanel : UserControl
    {

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

        public BindingList<Option> options;
        [Description("Options to display"), Category("Configuration")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BindingList<Option> Options
        {
            get
            {
                return this.options;
            }
            set
            {
                if (this.options == null || this.options.Count == 0) return;
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

                //this.pnlOptions.ColumnStyles.Clear();
                //Int32 count = this.options.Count;
                //Int32 i = 0;
                //foreach (Option option in this.options)
                //{
                //    option.NameChanged += delegate(String oldName, String newName)
                //    {
                //        foreach (Label item in this.pnlOptions.Controls)
                //        {
                //            if (String.Compare(item.Text, oldName) == 0) item.Text = newName;
                //        }
                //    };
                //    Label label = new Label
                //    {
                //        Text = option.Name,
                //        AutoSize = true,
                //        Padding = new Padding(0, 0, 0, 0),
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
                //}
            }
        }

        public SidePanel()
        {
            this.options = new BindingList<Option>();
            this.options.ListChanged += delegate(object sender, ListChangedEventArgs e)
            {
                this.Options = this.options;
            };
            this.buttons = new BindingList<Button>();
            this.buttons.ListChanged += delegate(object sender, ListChangedEventArgs e)
            {
                this.ControlButtons = this.buttons;
            };
            InitializeComponent();
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

        public void ShowOption(Option option)
        {
            if (option.Content != null)
            {
                this.SetColorToLabel(option.Name);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            //Need to show icons in left side
            this.Hide();
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

            public delegate void OnNameChanged(String oldName, String newName);
            public event OnNameChanged NameChanged;

        }

    }

}