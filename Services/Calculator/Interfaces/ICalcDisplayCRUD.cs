using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Interfaces
{
    public interface ICalcDisplayCRUD
    {
        bool DisplayCalculationResult(string operation, decimal number1, decimal? number2, decimal result);
    }
}
