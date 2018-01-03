using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace auto_anzeige
{
    class Gauge_Handler
    {
        DispatcherTimer clock;
        public event EventHandler<CustomEventArgs> RaiseTimeEvent;
        public Gauge_Handler()
        {
            clock = new System.Windows.Threading.DispatcherTimer();
            clock.Tick += new EventHandler(clock_Tick);
            clock.Interval = new TimeSpan(1);
            clock.Start();
            OnRaiseCustomEvent(new CustomEventArgs(getTime()));

        }


        private string getTime()
        {
            DateTime dt = DateTime.Now;
            String time = dt.Hour.ToString() + ":" + dt.Minute.ToString();
            return time;
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            OnRaiseCustomEvent(new CustomEventArgs(getTime()));
            clock.Interval = new TimeSpan(0, 1, 0);
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            RaiseTimeEvent?.Invoke(this, e);

        }

    }
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        private string msg;
        public string Message
        {
            get { return msg; }
        }
    }
}
