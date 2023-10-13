using EstudioCsharp.src.Domain.entities;
using EstudioCsharp.src.Domain.mocks;
using EstudioCsharp.src.Domain.processing;
using EstudioCsharp.src.Domain.utils;
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
              Console.WriteLine("Concept: " + record.GetConceptType().GetDescription()+ "   Amount: " + record.GetAmount());
            }

            processor.GetBalanceSheet().PrintBalanceSheet();
            processor.GetLiquidAsset().PrintLiquidAssets();
            processor.GetProfitability().PrintProfitability();
            processor.GetStatementIncome().PrintStatementIncome();
        }
    }
}