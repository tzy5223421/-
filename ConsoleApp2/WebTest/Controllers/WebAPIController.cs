using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using WebTest.Models;

namespace WebTest.Controllers
{
    [RoutePrefix("api")]
    public class WebAPIController : ApiController
    {
        [HttpPost]
        [Route("test")]
        public async System.Threading.Tasks.Task<TestModel> Find()
        {
            // return test;
            string a = await Request.Content.ReadAsStringAsync();
            if (a == "我更改了数据!")
            {
                TestModel t = new TestModel();
                t.Id = 0;
                return t;
            }
            else
            {
                return null;
            }
            //  return await Request.Content.ReadAsStringAsync();
        }

    }
}
