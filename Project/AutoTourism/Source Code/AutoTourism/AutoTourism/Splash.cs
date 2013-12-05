using System;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

//using AutoTourism.Presentation.Cache;

namespace AutoTourism.Presentation.Guardian
{

    public partial class Splash : Form
    {

        private Int32 TimerCount = 0;

        public Splash()
        {
            InitializeComponent();
            this.timer.Start();
        }

        private void Splash_Click(object sender, EventArgs e)
        {
            this.Close();
            new Thread(new ThreadStart(
                delegate()
                {
                    Type type = Type.GetType(
                        ConfigurationManager.AppSettings["StartUpAssembly"] + "." +
                        ConfigurationManager.AppSettings["StartUpClass"] + ", " +
                        ConfigurationManager.AppSettings["StartUpAssembly"], true);
                    Application.Run((Form)Activator.CreateInstance(type));
                })
            ).Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Thread loadRule = new Thread(new ThreadStart(
            //    delegate()
            //    {
            //        //GlobalData.ReadVariables();
            //    })
            //);
            //loadRule.Start();

            //if (TimerCount++ == 10)
            //{
            //    while (loadRule.ThreadState == ThreadState.Stopped) 
            //        loadRule.Abort();
            //    this.Splash_Click(sender, e);
            //}

        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.binaryaffairs.com");
        }

    }

}
