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
                MockAccountRecord.GenerateRandomAccountRecords(20), 
                new DateTime(2020, 01, 01), 
                new DateTime(2022, 11, 11)
                );



     

             foreach ( var kvp in processor.GetFilteredAccountRecords())
                {
                Console.WriteLine("Concept: " + kvp.GetConceptType().ToString() + " --- Amount: " + kvp.GetAmount());
                  
                }

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total Actives amount: " + processor.GetBalanceSheet().GetTotalActivesAmount());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total Passives amount: " + processor.GetBalanceSheet().GetTotalPassivesAmount());
        }
    }
}