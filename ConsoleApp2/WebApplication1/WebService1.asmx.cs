using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService, IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();

        [WebMethod]
        public void HelloWorld()
        {
            Context.Response.Write("HelloWorld!");
            Context.Response.End();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Sum(int param1, int param2)
        {
            int num1 = Convert.ToInt32(param1);
            int num2 = Convert.ToInt32(param2);

            int sum = num1 + num2;

            return sum.ToString();
        }

        [WebMethod]
        public string Project(string paramaters)
        {
            return paramaters;
        }

        [WebMethod]
        public void GetUser(int id)
        {
            User u = new User();
            u.name = "demo";
            u.username = "ddd";
            u.password = "333";
            u.money = 1.00;
            string json = JsonConvert.SerializeObject(u);
            Context.Response.Write(json);
            Context.Response.End();
        }
        [WebMethod(Description = "获取实体流")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void test()
        {

            //HttpRequest request = HttpContext.Current.Request;
            //// request.AcceptTypes = "application/json;charset=utf-8";
            //request.ContentType = "application/json;charset=utf-8";
            //Stream s = request.InputStream;//获得json 字符流，    
            //                               // string header = HttpContext.Current.Request.Headers["uid"];//获得header 下uid的值

            ////还原数据流
            //byte[] b = new byte[s.Length];
            //s.Read(b, 0, (int)s.Length);
            //string jsontext = Encoding.UTF8.GetString(b);
            //  request.r
            // return jsontext;
        }

        public void ProcessRequest(HttpContext context)
        {
            // throw new NotImplementedException();
        }
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public double money { get; set; }
    }
}
