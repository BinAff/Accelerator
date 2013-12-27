using System;
using System.Windows.Forms;
using System.Configuration;

using BinAff.Tool.SecurityHandler;

namespace AutoTourism
{

    static class Program
    {

        static Form currentForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.ApplicationExit += Application_ApplicationExit;

                DateTimeHandler dateTimeManipulationHandler = new DateTimeHandler();
                dateTimeManipulationHandler.SystemDateChanged += handler_SystemDateChanged;
                dateTimeManipulationHandler.Start();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Type type = Type.GetType(
                    ConfigurationManager.AppSettings["StartUpAssembly"] + "." +
                    ConfigurationManager.AppSettings["StartUpClass"] + ", " +
                    ConfigurationManager.AppSettings["StartUpAssembly"], true);
                currentForm = (Form)Activator.CreateInstance(type);
                Application.Run(currentForm);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        static void handler_SystemDateChanged()
        {
            FormCollection formCollection = Application.OpenForms;
            foreach (Form frm in formCollection)
            {
                frm.BeginInvoke(new Action(() => { frm.Enabled = false; }));
            }
            new BinAff.Presentation.Library.MessageBox()
            { 
                DialogueType = BinAff.Presentation.Library.MessageBox.Type.Error,
                Heading = "Splash :: Fatal Error!!!",
            }.Show("System date changed or trying to change.");
            Application.Exit();
        }

    }

}
