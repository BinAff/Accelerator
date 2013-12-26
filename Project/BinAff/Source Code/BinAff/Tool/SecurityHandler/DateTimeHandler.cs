using System;
using System.Timers;
//using System.Threading;

namespace BinAff.Tool.SecurityHandler
{

    public class DateTimeHandler
    {

        public delegate void Changed();
        public event Changed SystemDateChanged;

        private Timer timer;
        DateTime savedStamp;

        public void Start()
        {
            this.timer = new Timer(5000);
            this.timer.Elapsed += timer_Elapsed;
            this.timer.Start();
            this.savedStamp = DateTime.Now;
            //new Thread(() => Check())
            //{
            //    IsBackground = true,
            //}.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(DateTime.Now.Subtract(savedStamp).TotalSeconds) > 20)
            {
                this.SystemDateChanged();
                this.timer.Stop();
            }
            savedStamp = DateTime.Now;
        }

        //private void Check()
        //{
        //    DateTime last;
        //    DateTime now;
        //    while (true)
        //    {
        //        last = DateTime.Now;
        //        System.Threading.Thread.Sleep(5000);
        //        now = DateTime.Now;
        //        if (Math.Abs(now.Subtract(last).TotalSeconds) > 20)
        //        {
        //            this.SystemDateChanged();
        //            break;
        //        }
        //    }
        //}

    }

}