using EstudioCsharp.enums;
using EstudioCsharp.src.Domain.entities;
using EstudioCsharp.src.Domain.processing.analysis;
using EstudioCsharp.src.Domain.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.processing
{
    internal class FinancialDataProcessor
    {
        private HashSet<AccountRecord> AccountRecords { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }

        public FinancialDataProcessor(HashSet<AccountRecord> accountRecords, DateTime startDate, DateTime endDate)
        {
            AccountRecords = accountRecords;
            StartDate = startDate;
            EndDate = endDate;
        }

        public StatementIncome GetStatementIncome()
        {
            var mapRecords = GetConvertedMapAccountRecords();

            return new StatementIncome(
                GetTotalActivesAmount(mapRecords), 
                GetTotalPassivesAmount(mapRecords)
                );
        }

        public Profitability GetProfitability()
        {
            var mapRecords = GetConvertedMapAccountRecords();

            decimal totalIncome = GetTotalActivesAmount(mapRecords);
            decimal netIncome = Decimal.Subtract(totalIncome, GetTotalPassivesAmount(mapRecords));

            return new Profitability(totalIncome, netIncome);
        }

        public LiquidAsset GetLiquidAsset()
        {
            var mapRecords = GetConvertedMapAccountRecords();

            return new LiquidAsset(
                mapRecords["Activos Currientes"].Sum(c => c.GetAmount()), 
                mapRecords["Passivos currientes"].Sum(c => c.GetAmount())
                );
        }


        public BalanceSheet GetBalanceSheet()
        {
            return new BalanceSheet(GetConvertedMapAccountRecords());
        }

        public HashSet<AccountRecord> GetFilteredAccountRecords()
        {
            return AccountRecords
                .Where(record =>
                    record.GetDate() >= StartDate
                    && record.GetDate() <= EndDate)
                .ToHashSet();
        }

        public Dictionary<string, HashSet<AccountRecord>> GetConvertedMapAccountRecords()
        {
            return GetFilteredAccountRecords()
                .GroupBy(record => EnumUtils.GetClassificacionAsset(record.GetConceptType()))
                .ToDictionary(g => g.Key, g => g.ToHashSet());
        }

        public static decimal GetTotalActivesAmount(Dictionary<string, HashSet<AccountRecord>> recordDictionary)
        {

            if (recordDictionary.ContainsKey("Activos Currientes") || recordDictionary.ContainsKey("Activos fijos"))
            {
                var activoRecords = recordDictionary
                    .Where(kv => kv.Key.Equals("Activos Currientes") || kv.Key.Equals("Activos fijos"))
                    .SelectMany(kv => kv.Value);

                var ttt = activoRecords;

                decimal totalAmount = activoRecords.Sum(record => record.GetAmount());

                return totalAmount;
            }
            else
            {
                return 0;
            }
        }

        public static decimal GetTotalPassivesAmount(Dictionary<string, HashSet<AccountRecord>> recordDictionary)
        {

            if (recordDictionary.ContainsKey("Passivos currientes") || recordDictionary.ContainsKey("Passivos a largo plazo"))
            {
              
                var activoRecords = recordDictionary
                    .Where(kv => kv.Key.Equals("Passivos currientes") || kv.Key.Equals("Passivos a largo plazo"))
                    .SelectMany(kv => kv.Value);

                decimal totalAmount = activoRecords.Sum(record => record.GetAmount());

                return totalAmount;
            }
            else
            {
                return 0;
            }
        }
    }    
}