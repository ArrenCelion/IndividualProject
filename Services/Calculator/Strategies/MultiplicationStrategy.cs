﻿using Services.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Calculator.Strategies
{
    public class MultiplicationStrategy : IOperationStrategy
    {
        public decimal Execute(decimal a, decimal? b)
        {
            return a * (decimal)b;
        }
    }
}
