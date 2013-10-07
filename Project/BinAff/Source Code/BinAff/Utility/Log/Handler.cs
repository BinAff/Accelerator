using System;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace BinAff.Utility.Log
{
    public class Handler
    {
        private const string METHOD = "Method: ";
        private const string LINE = "Line: ";
        private const string MESSAGE_TYPE = "MessageType: ";
        private const string SPACE = " ";
        private const string SPLASH_ERROR = "SplashError";

        private LogWriter messageWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

        public void WriteError(string message, MessageType messageType, Type type)
        {
            CallingMethod method = new CallingMethod(type);
            string location = System.Environment.NewLine + METHOD + method.MethodNameFull +
                              System.Environment.NewLine + LINE + method.LineNumber +
                              System.Environment.NewLine + MESSAGE_TYPE + messageType;
            messageWriter.Write(message + SPACE + location, SPLASH_ERROR);
        }
    }
}
