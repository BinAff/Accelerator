using System;
using System.Windows.Forms;
using System.Configuration;

using BinAff.Tool.SecurityHandler;
using Logger = BinAff.Utility.Log;

namespace Retinue
{

    static class Program
    {

        static Form currentForm;
        private static readonly Boolean IsTraceOn = ConfigurationManager.AppSettings["TraceOn"] == "Y";
        private static readonly String tracePath = Environment.CurrentDirectory + ConfigurationManager.AppSettings["Tracepath"];
        private static readonly String exceptionPath = Environment.CurrentDirectory + ConfigurationManager.AppSettings["ExceptionPath"];
        private static Logger.Server traceWritter;
        private static Logger.Server exceptionWritter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                exceptionWritter = new Logger.Server(exceptionPath, Logger.Server.Type.Daily);
                
                //Application.ApplicationExit += Application_ApplicationExit;

                //DateTimeHandler dateTimeManipulationHandler = new DateTimeHandler();
                //dateTimeManipulationHandler.SystemDateChanged += handler_SystemDateChanged;
                //if (!dateTimeManipulationHandler.Start("Navigator"))
                //{
                //    Quit("System date got changed after application is shutdown last time. Restore the date to continue.");
                //    return;
                //}

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Type type = Type.GetType(
                //    ConfigurationManager.AppSettings["StartUpAssembly"] + "." +
                //    ConfigurationManager.AppSettings["StartUpClass"] + ", " +
                //    ConfigurationManager.AppSettings["StartUpAssembly"], true);
                //currentForm = (Form)Activator.CreateInstance(type);
                //currentForm = Vanilla.Navigator.WinForm.Container.CreateInstance();
                currentForm = new Retinue.Splash();
                Application.Run(currentForm);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                exceptionWritter.Write(ex, "SQL Exception");
                throw;
            }
            catch (Exception ex)
            {
                exceptionWritter.Write(ex, "General Exception");
                throw;
            }
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            ProductDatabaseHandler.Write("Retinue", DateTime.Now);
            Application.ExitThread();
        }

        static void handler_SystemDateChanged()
        {
            Quit("System date changed or trying to change.");
        }

        private static void Quit(String message)
        {
            FormCollection formCollection = Application.OpenForms;
            foreach (System.Windows.Forms.Form frm in formCollection)
            {
                frm.BeginInvoke(new Action(() => { frm.Enabled = false; }));
            }
            new BinAff.Presentation.Library.MessageBox()
            {
                DialogueType = BinAff.Presentation.Library.MessageBox.Type.Error,
                Heading = "Retinue :: Fatal Error!!!",
            }.Show(message);
            Application.Exit();
        }

    }

}