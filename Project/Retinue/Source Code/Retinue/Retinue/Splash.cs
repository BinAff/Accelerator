﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace Retinue
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
            //new Thread(new ThreadStart(
            //    delegate()
            //    {
            //        Type type = Type.GetType(
            //            ConfigurationManager.AppSettings["StartUpAssembly"] + "." +
            //            ConfigurationManager.AppSettings["StartUpClass"] + ", " +
            //            ConfigurationManager.AppSettings["StartUpAssembly"], true);
            //        Application.Run((Form)Activator.CreateInstance(type));
            //    })
            //).Start();
            //this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.CreateFoldersAndFiles();

            //new Vanilla.Navigator.Facade.Splash.Server(null).LoadForm();
            new Retinue.Utility.Facade.Cache.Server().Cache();
            Thread t = new Thread(delegate()
            {
                Application.Run(Vanilla.Navigator.WinForm.Container.CreateInstance());
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            this.Close();
        }

        private void CreateFoldersAndFiles()
        {
            if (!Directory.Exists(Application.StartupPath + @"\Files"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Files");                
            }
            if (!File.Exists(Application.StartupPath + @"\Files\Recent.xml"))
            {
                //File.Create(Application.StartupPath + @"\Files\Recent.xml");
                File.WriteAllLines(Application.StartupPath + @"\Files\Recent.xml", new List<String>
                    {
                        "<Recent>",
                        "   <Report>",
                        "   </Report>",
                        "   <Form>",
                        "   </Form>",
                        "</Recent>",
                    });
            }
            if (!Directory.Exists(Application.StartupPath + @"\Sticky"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Sticky");
            }
            if (!Directory.Exists(Application.StartupPath + @"\Report"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Report");
            }
        }

        private void LoadAutoCache()
        {
            new Retinue.Utility.Facade.Cache.Server().Cache();
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.binaryaffairs.com");
        }

    }

}
