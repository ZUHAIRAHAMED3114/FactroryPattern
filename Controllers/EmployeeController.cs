using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using polyMorphisamStateAndExpressionTree.Repository;

namespace polyMorphisamStateAndExpressionTree.Controller
{
    public class EmployeeController:BaseController
    {
        private readonly IRepository employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            Console.WriteLine("employee Controller is created");
            this.employeeRepository = employeeRepository;
        }

        public override Task<HttpResponseMessage> ExecuteAsyn()
        {
            Console.WriteLine("processing Employee Controller Asynchronously by the Employee Controller for the current request...");
                return Task.FromResult(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK });
        }
    }
}
