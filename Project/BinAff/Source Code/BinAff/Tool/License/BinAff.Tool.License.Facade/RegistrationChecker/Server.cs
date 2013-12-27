using BinAff.SqlServerUtil;
using BinAff.Tool.SecurityHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace BinAff.Tool.License.Facade.RegistrationChecker
{

    public class Server
    {

        /// <summary>
        /// Installation folder of the application
        /// </summary>
        public String Folder { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public String ProductName { get; set; }

        /// <summary>
        /// SQL server instance name
        /// </summary>
        public String InstanceName { get; set; }

        /// <summary>
        /// Database name where application is installed
        /// </summary>
        public String DatabaseName { get; set; }

        public Int16 Authenticate()
        {
            return FingurePrintHandler.Authenticate(this.ProductName, this.Folder, this.InstanceName, this.DatabaseName);
        }
        
    }

}
