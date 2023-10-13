using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.processing.analysis
{
    internal class LiquidAsset
    {
        private decimal CurrentAsset {  get;  set; }
        private decimal CurrentLiabilities { get;  set; }

        public LiquidAsset(decimal currentAsset, decimal currentLiabilities)
        {
            CurrentAsset = currentAsset;
            CurrentLiabilities = currentLiabilities;
        }

        public void PrintLiquidAssets()
        {
            decimal currentRatio = GetCurrentRatio(CurrentAsset, CurrentLiabilities);

            Console.WriteLine($"\n---- ANÁLISE DE LIQUIDEZ ----\n" +
                              $"Liquidez Corrente: {currentRatio:F2} o {Convert.ToInt32(currentRatio * 100)}%");
        }


        public decimal GetCurrentRatio(decimal currentAsset, decimal currentLiabilities)
        {
            return currentLiabilities.CompareTo(0) == 0 ? 0 : currentAsset / currentLiabilities;
        }
    }
}
