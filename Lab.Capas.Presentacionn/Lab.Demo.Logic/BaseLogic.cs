using Lab.Demo.ResourceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            this.context = new NorthwindContext();
        }
    }
}
