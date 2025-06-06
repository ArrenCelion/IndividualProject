using Services.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Strategies
{
    public class ModulusStrategy : IOperationStrategy
    {
        public decimal Execute(decimal a, decimal? b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot modulus by zero.");
            return a % (decimal)b;
        }
    }
}
