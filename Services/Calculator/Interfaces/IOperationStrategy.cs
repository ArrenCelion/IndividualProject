using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Interfaces
{
    public interface IOperationStrategy
    {
        decimal Execute(decimal a, decimal? b);
    }
}
