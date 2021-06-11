using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polyMorphisamStateAndExpressionTree.Repository;
using System.Net.Http;

namespace polyMorphisamStateAndExpressionTree.Controller
{
    public class ProductController : BaseController
    {
       public ProductController(ProductRepository productRepository)
        {
            Console.WriteLine("Product controller is created");
            ProductRepository = productRepository;
        }

        public IRepository ProductRepository { get; }

        public override Task<HttpResponseMessage> ExecuteAsyn()
        {
            Console.WriteLine("processing Employee Controller Asynchronously by the Employee Controller for the current request...");
            return Task.FromResult(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK });
        }
    }
}
