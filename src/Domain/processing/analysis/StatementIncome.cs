using EstudioCsharp.src.Domain.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.processing.analysis
{
    internal class StatementIncome
    {
        private decimal TotalIncome;
        private decimal TotalExpenses;

        public StatementIncome(decimal totalIncome, decimal totalExpenses)
        {
            this.TotalIncome = totalIncome;
            this.TotalExpenses = totalExpenses;
        }

        public decimal GetNetProfit()
        {
            return Decimal.Subtract(TotalIncome, TotalExpenses);
        }

        public void PrintStatementIncome()
        {
            Console.WriteLine($"\n----- ESTADO DE RESULTADOS -----\n" +
                              $"Ingresos totales: $ {NumberUtils.FormatLatinAmericanNumber(TotalIncome)}\n" +
                              $"Gastos totales: $ {NumberUtils.FormatLatinAmericanNumber(TotalExpenses)}\n" +
                              $"Beneficio neto: $ {NumberUtils.FormatLatinAmericanNumber(GetNetProfit())}");
        }

    }
}
