using EstudioCsharp.src.Domain.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.processing.analysis
{
    internal class Profitability
    {
        private decimal NetIncome;
        private decimal TotalIncome;

        public Profitability(decimal netIncome, decimal totalIncome)
        {
            this.NetIncome = netIncome;
            this.TotalIncome = totalIncome;
        }

        public decimal CalculateNetProfitMargin()
        {
            return TotalIncome.CompareTo(0) == 0 ? 0 : Math.Round((NetIncome / TotalIncome) * 100, 2);
        }

        public void PrintProfitability()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("\n\n---- ANÁLISE DE RENTABILIDADE ----");
            stringBuilder.Append($"Margem de benefício neto: {NumberUtils.FormatLatinAmericanNumber(CalculateNetProfitMargin())}%\n");

            Console.WriteLine(stringBuilder.ToString());
        }

    }
}
