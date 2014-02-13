using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerUsingEvents
{
    public class Timer
    {
        private int calls;
        private int t;
        public delegate void TimerEvent(object sender, EventArgs e);
        public event TimerEvent onTimeElapsed;

        public Timer(int t)
        {
            this.T = t;
            this.calls = 0;

        }

        public int T
        {
            get { return t; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("t must be bigger than 0");
                }
                t = value;
            }
        }

        public int Calls
        {
            get { return calls; }
            private set { this.calls = value; }
        }

        private void Invoke(EventArgs e)
        {
            if(onTimeElapsed!=null)
            onTimeElapsed(this,e);
        }

        public void Run()
        {

            while (true)
            {
                Console.Clear();
                Invoke(EventArgs.Empty);
                this.Calls++;
                Thread.Sleep(this.T * 1000);
            }
        }
    }
}