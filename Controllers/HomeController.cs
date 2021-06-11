using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace polyMorphisamStateAndExpressionTree.Controller
{
   public class HomeController : BaseController
    {
        public HomeController() {
            Console.WriteLine("homecontroller is created");
        }
        public override Task<HttpResponseMessage> ExecuteAsyn()
        {
            Console.WriteLine("processing Employee Controller Asynchronously by the Employee Controller for the current request...");
            return Task.FromResult(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK });
        }
    
    }
}
