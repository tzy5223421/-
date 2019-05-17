using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentScoreQueryService service = new StudentScoreQueryService();
            WebServiceHost _serviceHost = new WebServiceHost(service, new Uri("http://127.0.0.1:8899/Demo"));
            _serviceHost.Open();
            Console.WriteLine("输入任意键关闭程序！");
            Console.ReadKey();
            _serviceHost.Close();
        }
    }
}
