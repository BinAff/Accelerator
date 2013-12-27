using System;
using System.Windows.Forms;

namespace BinAff.Tool.License
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
            //Application.Run(new Patient());
            Application.Run(new FileGenerator());
            Application.Run(new FingurePrintManager());
            Application.Run(new RegistrationChecker());
        }
    }
}
