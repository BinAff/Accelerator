using System;
using System.Net;

namespace BinAff.Utility
{

    public static class Connectivity
    {

        public static Boolean IsConnected()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.binaryaffairs.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static Boolean IsConnected(String url)
        {
            if (String.IsNullOrEmpty(url)) url = "http://www.binaryaffairs.com";
            WebRequest WebReq = WebRequest.Create(new System.Uri(url));
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
