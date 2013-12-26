using System;
using System.Timers;

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

    }

}