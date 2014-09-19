using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using _03.StringCheckerService;
namespace _03.StringChecker.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uri = new Uri("http://127.0.0.1:8888");
                ServiceHost host = new ServiceHost(typeof(StringCheckerSvc), uri);
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                host.AddServiceEndpoint(typeof(IStringCheckerSvc),
                    new WSHttpBinding(), "StringChecker");

                host.Open();
                Console.WriteLine("Service hosted on {0}", uri.AbsoluteUri);
                Console.ReadKey();
                host.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           
        }
    }
}
