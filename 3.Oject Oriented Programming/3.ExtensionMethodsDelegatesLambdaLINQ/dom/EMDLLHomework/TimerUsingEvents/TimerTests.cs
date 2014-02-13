using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerUsingEvents
{
    class TimerTests
    {
        public static void PrintTime(object sender, EventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            var timer = sender as Timer ?? new Timer(1);
            Console.WriteLine("The methods are called every {0} seconds", timer.T);
            Console.WriteLine(DateTime.Now);
        }

        public static void Statistics(object sender, EventArgs e)
        {
            var timer = sender as Timer ?? new Timer(1);
            Console.WriteLine("Calls since start:");
            Console.WriteLine(timer.Calls);
        }

        public static void Additional(object sender, EventArgs e)
        {
            var timer = sender as Timer ?? new Timer(1);
            if(timer.Calls%2==0)
            Console.WriteLine("I show every even call of the method group");
        }
        static void Main(string[] args)
        {
            Timer timer=new Timer(1);
            var actions=new Timer.TimerEvent(PrintTime);
            actions += Statistics;
            actions += Additional;
            timer.onTimeElapsed += actions;
            Thread timerThread=new Thread(timer.Run);
            timerThread.Start();
        }
    }
}
