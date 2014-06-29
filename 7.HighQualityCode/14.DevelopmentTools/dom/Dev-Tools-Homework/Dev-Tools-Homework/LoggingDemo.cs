using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;


namespace Dev_Tools_Homework
{
    public class LoggingDemo
    {
        private static readonly ILog log = LogManager.GetLogger("Global Message Logger");

        /// <summary>
        /// Just a sample program to show the usage of various code analisys tools, documentation tools, and code quality tools.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
      
            var layout = new SimpleLayout();
            var appender = new FileAppender();

            appender.Layout = layout;
            appender.File = "log.txt";
            appender.AppendToFile = true;
            appender.ActivateOptions();

            BasicConfigurator.Configure(appender);
            log.Debug("Debug msg");
            log.Error("Error msg");
            

        }
    }
}
