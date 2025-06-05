using Services.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Strategies
{
    public class DivisionStrategy : IOperationStrategy
    {
        public decimal Execute(decimal a, decimal b = 0)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
