using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polyMorphisamStateAndExpressionTree.Repository
{
    public class ProductRepository : IRepository
    {
        public ProductRepository(DatabaseContext context)
        {
            Console.WriteLine("product Repository is created");
            Context = context;
        }

        private DatabaseContext Context { get; }
    }
}
