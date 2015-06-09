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
        
        [Description("Control panel will be shown at top"), Category("Configuration")]
        public Boolean IsControlPanelOnTop { get; set; }

        void label_Click(object sender, EventArgs e)
        {
            foreach (Label label in this.pnlOptions.Controls)
            {
                label.ForeColor = String.Compare(label.Text, (sender as Label).Text) == 0 ? SystemColors.MenuHighlight : SystemColors.ControlText;
            }
            foreach(Option option in this.options)
            {
                if (String.Compare(option.Name, (sender as Label).Text) == 0)
                {
                    if (option.Content == null)
                    {
                        this.pnlContainer.Controls.Clear();
                    }
                    else
                    {
                        this.pnlContainer.Controls.Add(option.Content);
                        option.Content.Dock = DockStyle.Fill;
                        option.Content.BringToFront();
                        option.Content.Show();
                    }
                    break;
                }
            }
        }

        public SidePanel()
        {
            this.options = new BindingList<Option>();
            this.options.ListChanged += delegate(object sender, ListChangedEventArgs e)
            {
                this.Options = this.options;
            };
            InitializeComponent();
            this.pnlContainer.Dock = DockStyle.Fill;
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