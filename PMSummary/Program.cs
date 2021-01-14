using System;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

using Newtonsoft.Json;

using PMSummary.Interfaces;

namespace PMSummary
{
    class Program
    {
        static void Main(string[] args)
        {

            WebServiceHost hostWeb = new WebServiceHost(typeof(MockAPISummarySvc));
            ServiceEndpoint ep = hostWeb.AddServiceEndpoint(typeof(IMockAPISummary), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = hostWeb.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            hostWeb.Open();

            Console.WriteLine("PrologMobile API Service started @ " + DateTime.Now.ToString());
            Console.WriteLine("URI: http://localhost.com:8080/summary");
            Console.Read();
        }
    }
}