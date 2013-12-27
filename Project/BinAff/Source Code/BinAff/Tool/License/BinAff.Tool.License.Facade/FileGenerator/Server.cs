using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Tool.SecurityHandler;
 

namespace BinAff.Tool.License.Facade.FileGenerator
{

    public class Server
    {

        public List<SecurityHandler.Product.Data> Load()
        {
            ICrud server = new SecurityHandler.Product.Server(null);
            ReturnObject<List<BinAff.Core.Data>> cur = server.ReadAll();
            List<SecurityHandler.Product.Data> ret = new List<SecurityHandler.Product.Data>();
            foreach (SecurityHandler.Product.Data d in cur.Value)
            {
                ret.Add(d);
            }
            return ret;
        }

        public void Generate(SecurityHandler.Product.Data product, List<SecurityHandler.Module.Data> moduleList, String targetPath)
        {
            LicenseFileHandler.Write(product, moduleList, targetPath);
        }
        
    }

}
