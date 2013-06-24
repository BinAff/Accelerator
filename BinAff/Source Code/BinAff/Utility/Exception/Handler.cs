using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BinAff.Utility.Log;

namespace BinAff.Utility.Exception
{
    public class Handler
    {
        public void HandleException(System.Exception ex, string policy)
        {
          
            // Resolve an Exception Manager instance 
            var exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            try
            {                
                Boolean rethrow = exManager.HandleException(ex, policy);
            }
            catch (System.Exception innerEx)
            {
                string errorMsg = "An unexpected exception occured while " + "calling HandleException with policy '" + policy + "'. ";
                errorMsg += Environment.NewLine + innerEx.ToString();
                (new BinAff.Utility.Log.Handler()).WriteError(errorMsg, MessageType.Error, this.GetType());
            }
        }

    }
}
