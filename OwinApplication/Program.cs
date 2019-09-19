using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinApplication
{
    class Program
    {
        private IDisposable _webApplication;

        static void Main(string[] args)
        {
            string baseAddress = string.Format("http://*:9999");
            WebApp.Start<Startup>(url: baseAddress);

            Console.ReadLine();

        }
    }
}
