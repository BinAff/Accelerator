using System;
using System.Net;

namespace BinAff.Utility
{

    public static class Connectivity
    {

        public static Boolean IsConnected()
        {
            WebRequest WebReq = WebRequest.Create(new System.Uri("http://www.binaryaffairs.com"));
            WebResponse Resp;
            try
            {
                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }
            catch
            {
                WebReq = null;
                return false;
            }
        }

    }

}
