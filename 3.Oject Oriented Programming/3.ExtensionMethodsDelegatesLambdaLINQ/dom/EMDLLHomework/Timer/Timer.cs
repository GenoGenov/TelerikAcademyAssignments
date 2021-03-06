﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    internal delegate void InvokerDelegate();

    public class Timer
    {
        private int calls;
        private InvokerDelegate invoker;
        private int t;

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

        private void PrintTime()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("The methods are called every {0} seconds", this.T);
            Console.WriteLine(DateTime.Now);
        }

        private void Statistics()
        {
            Console.WriteLine("Calls since start:");
            Console.WriteLine(this.calls);
        }

        public void BeginInvoke()
        {
            this.invoker = PrintTime;
            invoker += Statistics;

            while (true)
            {
                invoker();
                this.calls++;
                Thread.Sleep(this.T*1000);
            }
        }
    }
}