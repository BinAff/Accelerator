using System;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections;

namespace BinAff.Utility
{

    public class Converter
    {

        /// <summary>
        /// Converts given date to string with dd/MM/yyyy format
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>String</returns>
        public static String ToString(DateTime date)
        {
            return date == DateTime.MinValue ? String.Empty : date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Converts given date to string with only dd/MM/yyyy format
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>String</returns>
        public static String ToDateString(DateTime date)
        {
            return date == DateTime.MinValue ? String.Empty : date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Converts given dd/MM/yyyy date  into the default system supported format
        /// </summary>
        /// <param name="date">Date value</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDefaultDateTime(String date)
        {
            DateTime defaultDate;
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            DateTime.TryParse(date, ci, DateTimeStyles.NoCurrentDateDefault, out defaultDate);
            return defaultDate;
        }

        /// <summary>
        /// Converts given date MM/dd/yyyy into the default system supported format
        /// </summary>
        /// <param name="date">Date value</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDefaultSystemDateTime(String date)
        {
            DateTime defaultDate;
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            DateTime.TryParse(date, ci, DateTimeStyles.NoCurrentDateDefault, out defaultDate);
            return defaultDate;
        }

        /// <summary>
        /// Open file in to a filestream and read data in a byte array.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>Byte array</returns>
        public static Byte[] ReadFile(String path)
        {
            //Initialize byte array with a null value initially.
            Byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(path);
            Int64 numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        /// <summary>
        /// Put comma in Indian style
        /// </summary>
        /// <param name="value">Currency value</param>
        /// <returns></returns>
        public static String ConvertToIndianCurrency(Decimal value)
        {
            String retVal = String.Empty;
            Decimal amount = Math.Round(value, 2); 
            StringBuilder sb = new StringBuilder();
            String Value = amount.ToString().Split('.')[0];
            if (Value.Length > 3)
            {
                ArrayList list = new ArrayList();
                ArrayList newList = new ArrayList();
                for (int intCnt = 0; intCnt < Value.Length; intCnt++)
                    list.Add(Value.Substring(intCnt, 1));

                list.Reverse();
                list.Insert(3, ",");

                for (int intLst = 0; intLst < list.Count; intLst++)
                {
                    newList.Add(list[intLst]);

                    if ((intLst > 4) && ((intLst % 2) != 0))
                        newList.Add(",");
                }

                newList.Reverse();

                for (int intNLst = 0; intNLst < newList.Count; intNLst++)
                    sb.Append(newList[intNLst]);

                retVal = sb.ToString().Substring(0,1) == "," ? sb.ToString().Substring(1) : sb.ToString();
                
                if (amount.ToString().Split('.').Length > 1)
                    retVal = retVal + "." + amount.ToString().Split('.')[1];
            }
            else
                retVal =  amount.ToString();

            return retVal;
        }

        /// <summary>
        /// Put comma in Indian style
        /// </summary>
        /// <param name="value">Currency value</param>
        /// <returns></returns>
        public static String ConvertToIndianCurrency(Double value)
        {
            String retVal = String.Empty;
            Double amount = Math.Round(value, 2);
            StringBuilder sb = new StringBuilder();
            String Value = amount.ToString().Split('.')[0];
            if (Value.Length > 3)
            {
                ArrayList list = new ArrayList();
                ArrayList newList = new ArrayList();
                for (int intCnt = 0; intCnt < Value.Length; intCnt++)
                {
                    list.Add(Value.Substring(intCnt, 1));
                }
                list.Reverse();
                list.Insert(3, ",");

                for (int intLst = 0; intLst < list.Count; intLst++)
                {
                    newList.Add(list[intLst]);

                    if ((intLst > 4) && ((intLst % 2) != 0))
                    {
                        newList.Add(",");
                    }
                }

                newList.Reverse();

                for (int intNLst = 0; intNLst < newList.Count; intNLst++)
                {
                    sb.Append(newList[intNLst]);
                }

                retVal = sb.ToString().Substring(0, 1) == "," ? sb.ToString().Substring(1) : sb.ToString();

                if (amount.ToString().Split('.').Length > 1)
                {
                    retVal += "." + amount.ToString().Split('.')[1];
                }
            }
            else
            {
                retVal = amount.ToString();
            }

            return retVal;
        }

    }

}