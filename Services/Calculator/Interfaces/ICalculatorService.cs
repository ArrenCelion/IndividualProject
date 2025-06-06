using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Interfaces
{
    public interface ICalculatorService
    {
        void StartCalculation();
        void SaveCalculation(CalculatorModel calculatorModel, bool isUpdate);
        List<CalculatorModel> GetAllCalculations();
        void ReadAllCalculations();
        void UpdateCalculation();
        void DeleteCalculation();
        CalculatorModel SelectOneCalculation();
    }
}
