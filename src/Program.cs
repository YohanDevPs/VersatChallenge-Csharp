using EstudioCsharp.src.Domain.entities;
using EstudioCsharp.src.Domain.mocks;
using EstudioCsharp.src.Domain.processing;
using System;
using System.Drawing;
using System.Net.Mime;
using System.Reflection;

namespace EstudioCsharp.enums
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FinancialDataProcessor processor = new FinancialDataProcessor(
                MockAccountRecord.GenerateRandomAccountRecords(100), 
                new DateTime(2020, 01, 01), 
                new DateTime(2022, 11, 11));


            foreach (var record in processor.GetFilteredAccountRecords())
            {
              Console.WriteLine("Concept: " + record.GetConceptType().ToString()+ "   Amount: " + record.GetAmount());
            }

            processor.GetLiquidAsset().PrintLiquidAssets();
        }
    }
}