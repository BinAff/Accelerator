using System;
using System.Threading;

namespace BinAff.Tool.SecurityHandler
{

    public class DateTimeHandler
    {

        public delegate void Changed();
        public event Changed SystemDateChanged;

        public void Start()
        {
            new Thread(() => Check()).Start();
        }

        private void Check()
        {
            DateTime last;
            DateTime now;
            while (true)
            {
                last = DateTime.Now;
                Thread.Sleep(5000);
                now = DateTime.Now;
                if (Math.Abs(now.Subtract(last).TotalSeconds) > 20)
                {
                    this.SystemDateChanged();
                    break;
                }
            }
        }

    }

}