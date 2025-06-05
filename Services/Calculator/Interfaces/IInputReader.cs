using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Interfaces
{
    public interface IInputReader
    {
        (string Operator, decimal Number1, decimal? Number2) GetCalculationInput(IEnumerable<string> availableOperators);
    }
}
