using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyMorphisamStateAndExpressionTree.Repository
{
    public class EmployeeRepository : IRepository
    {
        private readonly DatabaseContext context;

        public EmployeeRepository(DatabaseContext context)
        {
            Console.WriteLine("employee Repository is created");

            this.context = context;
        }
    }
}
