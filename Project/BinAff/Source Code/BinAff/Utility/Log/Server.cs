using System;
using System.IO;

namespace BinAff.Utility.Log
{

    public class Server
    {

        static System.Threading.Semaphore locking = new System.Threading.Semaphore(1, 1);
        String filePath;
        Type type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">File path including file name and extension</param>
        public Server(String filePath, Type type)
        {
            this.filePath = filePath;
            this.type = type;
            //filePath = this.GetFilePath(filePath, this.GetSuffix(type));
            //if (!File.Exists(filePath))
            //{
            //    fileStream = File.CreateText(filePath);
            //}
            //else
            //{
            //    fileStream = File.AppendText(filePath);
            //}
        }

        public void Write(String message)
        {
            try
            {
                locking.WaitOne();
                StreamWriter fileStream = this.GetFileStream();
                fileStream.WriteLine(Environment.NewLine + String.Format("Date - {0}.{1}.{2}, Time - {3}:{4}:{5}:{6} :: {7}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, message));
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                locking.Release();
            }
        }

        public void Write(Exception exception)
        {
            StreamWriter fileStream = this.GetFileStream();
            this.WriteException(fileStream, exception);
            fileStream.WriteLine();
            fileStream.WriteLine();
            fileStream.Flush();
            fileStream.Close();
        }

        private void WriteException(StreamWriter fileStream, Exception exception)
        {
            fileStream.WriteLine(Environment.NewLine + String.Format("***********************Exception Occured***********************"));
            fileStream.WriteLine(Environment.NewLine + String.Format("Date - {0}.{1}.{2}, Time - {3}:{4}:{5}:{6} :: Exception - {7}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, exception.Message));
            fileStream.WriteLine(Environment.NewLine + "Stack Trace :: " + exception.StackTrace);
            if (exception.InnerException != null)
            {
                Exception p = exception;
                while (p.InnerException != null)
                {
                    p = p.InnerException;
                    fileStream.WriteLine(Environment.NewLine + "Inner Exception :: " + p.Message);
                    fileStream.WriteLine(Environment.NewLine + "Stack Trace :: " + p.StackTrace);
                }
            }
            fileStream.WriteLine(Environment.NewLine + "*************************************************************");
        }

        public void Write(Exception exception, String Heading)
        {
            StreamWriter fileStream = this.GetFileStream();
            fileStream.WriteLine(Environment.NewLine + "*************************************************************");
            fileStream.WriteLine(Heading);
            this.WriteException(fileStream, exception);
            fileStream.WriteLine();
            fileStream.WriteLine();
            fileStream.Flush();
            fileStream.Close();
        }

        public void Write(Exception exception, String Heading, String Data)
        {
            StreamWriter fileStream = this.GetFileStream();
            fileStream.WriteLine(Environment.NewLine + "*************************************************************");
            fileStream.WriteLine(Environment.NewLine + Heading);
            this.WriteException(fileStream, exception);
            fileStream.WriteLine(Environment.NewLine + "***************************Data******************************");
            fileStream.WriteLine(Environment.NewLine + Data);
            fileStream.WriteLine(Environment.NewLine + "*************************************************************");
            fileStream.WriteLine();
            fileStream.WriteLine();
            fileStream.Flush();
            fileStream.Close();
        }

        private String GetSuffix(Type type)
        {
            string suffix = String.Empty; ;
            switch (type)
            {
                case Type.Flat:
                    break;
                case Type.Hourly:
                    suffix = String.Format("-{0}{1}{2}-{3}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour);
                    break;
                case Type.Daily:
                    suffix = String.Format("-{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case Type.Monthly:
                    suffix = String.Format("-{0}{1}", DateTime.Now.Year, DateTime.Now.Month);
                    break;
                case Type.Yearly:
                    suffix = String.Format("-{0}", DateTime.Now.Year);
                    break;
            }
            return suffix;
        }

        private String GetFilePath(String filePath, String suffix)
        {
            String[] tokens = filePath.Split(new Char[] { '.' });
            tokens[tokens.Length - 2] += suffix;
            return String.Join(".", tokens);
        }

        private StreamWriter GetFileStream()
        {
            StreamWriter fileStream;
            String filePath = this.GetFilePath(this.filePath, this.GetSuffix(type));
            if (!File.Exists(filePath))
            {
                fileStream = File.CreateText(filePath);
            }
            else
            {
                fileStream = File.AppendText(filePath);
            }
            return fileStream;
        }

        public enum Type
        {
            Flat,
            Hourly,
            Daily,
            Monthly,
            Yearly,
        }

    }

}