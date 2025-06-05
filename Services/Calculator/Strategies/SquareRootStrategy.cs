using Services.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Strategies
{
    public class SquareRootStrategy : IOperationStrategy
    {
        public decimal Execute(decimal a, decimal b = 0)
        {
            if (a < 0) throw new ArgumentException("Cannot calculate square root of a negative number.");
            return (decimal)Math.Sqrt((double)a);
        }
    }
}
