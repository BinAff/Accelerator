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

        DateTime savedStamp;

        public void Start()
        {
            new Thread(() => Change()).Start();
        }

        void Change()
        {
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