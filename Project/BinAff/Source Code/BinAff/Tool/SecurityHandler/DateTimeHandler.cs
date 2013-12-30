using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BinAff.Tool.SecurityHandler
{

    public class DateTimeHandler
    {

        public delegate void Changed();
        public event Changed SystemDateChanged;
        
        public Boolean Start(String productName)
        {
            if (!this.CheckCurrentDateisLaterOrNot(productName)) return false;

            new Thread(() => this.PushDateTimeStamp(productName))
            {
                IsBackground = true,
            }.Start();
            new Thread(() => this.CheckDateTimeIntigrity())
            {
                IsBackground = true,
            }.Start();
            return true;
        }

        private Boolean CheckCurrentDateisLaterOrNot(String productName)
        {
            return DateTime.Now.CompareTo(ProductDatabaseHandler.Read(productName)) >= 0;
        }

        private void PushDateTimeStamp(String productName)
        {
            while (true)
            {
                ProductDatabaseHandler.Write(productName, DateTime.Now);
                Thread.Sleep(30000);
            }
        }

        private void CheckDateTimeIntigrity()
        {
            DateTime savedStamp;
            while (true)
            {
                savedStamp = DateTime.Now;
                Thread.Sleep(5000);
                if (Math.Abs(DateTime.Now.Subtract(savedStamp).TotalSeconds) > 20)
                {
                    this.SystemDateChanged();
                    break;
                }
            }
        }

    }

}