using System.IO;

namespace BinAff.Utility
{

    public static class Logger
    {

        public static void Log(string msg, string stkTrace, string title)
        { 
            string DirectoryPath = @"C:\MyDir";

            string StackTrace = string.Empty;
            string[] lines = stkTrace.Split('\n');
            StackTrace = lines[lines.Length - 1];
            

            if(!(Directory.Exists(DirectoryPath + "\\Errors\\")))
            {
                Directory.CreateDirectory(DirectoryPath + "\\Errors\\");
            }

            FileStream fs = new FileStream(DirectoryPath + "\\Errors\\errorlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter s = new StreamWriter(fs);
            s.Close();
            fs.Close();

            FileStream fs1 = new FileStream(DirectoryPath + "\\Errors\\errorlog.txt",FileMode.Append,FileAccess.Write);
            StreamWriter s1 = new StreamWriter(fs1);
            s1.Write("\r\n");
            s1.Write("Title: " + title + "\r\n");
            s1.Write("Message: " + msg + "\r\n");
            s1.Write("StackTrace: " + StackTrace + "\r\n");
            s1.Write("Date/Time: " + System.DateTime.Now.ToString() + "\r\n");
            s1.Write("===========================================================================================" + "\r\n");

            s1.Close();
            fs1.Close();

        }

    }

}
