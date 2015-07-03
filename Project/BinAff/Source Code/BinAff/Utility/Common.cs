using System;

namespace BinAff.Utility
{

    public static class Common
    {

        public static String GenerateCode(String prefix, Int64 serial, String delimiter, Int16 serialNumberMask)
        {
            return prefix + delimiter
                + DateTime.Today.Year + delimiter + DateTime.Today.Month.ToString("D2") + delimiter
                + (serial != 0 ? serial.ToString("D" + serialNumberMask.ToString()) :
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
        }

    }

}