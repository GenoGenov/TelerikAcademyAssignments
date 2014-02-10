using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        private delegate void InvokerDelegate();

        private InvokerDelegate beginInvoke;

        private int t;

        private int calls;

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

        public Timer(int t)
        {
            this.T = t;
            this.calls = 0;
        }

        private void PrintTime()
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine("The methods are called every {0} seconds",this.T);
            Console.WriteLine(DateTime.Now);
        }

        private void Statistics()
        {
            Console.WriteLine("Calls since start:");
            Console.WriteLine(this.calls);
        }

        public void BeginInvoke()
        {
            this.beginInvoke = new InvokerDelegate(PrintTime);
            beginInvoke += Statistics;

            while (true)
            {
                beginInvoke();
                this.calls++;
                Thread.Sleep(this.T*1000);
            }
        }
    }
}
