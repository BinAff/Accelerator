using System;
using System.Diagnostics;
using System.Windows.Forms;
using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Report.WinForm
{
    
    static class Program
    {

        static Vanilla.Report.WinForm.Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (GetRunningInstance() == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length == 2)
                {
                    VanAcc.Dto account;
                    account = new VanAcc.Dto
                    {
                        LoginId = args[0],
                        Password = args[1],
                    };
                    container = Container.CreateInstance(account);
                }
                else
                {
                    container = Container.CreateInstance();
                }
                Application.Run(container);
            }
            else
            {

            }
        }

        public static Process GetRunningInstance()
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }

        public static void Open(string[] args)
        {
            //Document document = args[0] as Document;
            MessageBox.Show("Called");
        }

    }

}
