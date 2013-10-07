using System;
using System.Windows.Forms;
using System.Configuration;

namespace AutoTourism
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Type type = Type.GetType(
                ConfigurationManager.AppSettings["StartUpAssembly"] + "." + 
                ConfigurationManager.AppSettings["StartUpClass"] + ", " +
                ConfigurationManager.AppSettings["StartUpAssembly"], true);
            Application.Run((Form)Activator.CreateInstance(type));
        }
    }
}
