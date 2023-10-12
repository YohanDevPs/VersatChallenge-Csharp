using EstudioCsharp.enums;
using EstudioCsharp.src.Domain.entities;
using EstudioCsharp.src.Domain.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.processing.analysis
{
    internal class BalanceSheet
    {
        private Dictionary<string, HashSet<AccountRecord>> RecordDictionary;

        public BalanceSheet(Dictionary<string, HashSet<AccountRecord>> recordDictionary)
        {
            this.RecordDictionary = recordDictionary;
        }

        private decimal GetTotalActivesAmount()
        {
            return FinancialDataProcessor.GetTotalActivesAmount(RecordDictionary);
        }

        private decimal GetTotalPassivesAmount() 
        {
            return FinancialDataProcessor.GetTotalPassivesAmount(RecordDictionary);
        }

        private decimal GetAmountByAsset(string asset)
        {
            return RecordDictionary[asset].Sum(c => c.GetAmount());
        }

        private decimal GetAmountByConceptType(ConceptType type)
        {
            return RecordDictionary[FinancialDataProcessor.GetClassificacionAsset(type)]
                .Where(c => c.GetConceptType().Equals(type))
                .Sum(c => c.GetAmount());
        }

        public void printBalanceSheet()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("---- BALANCE GENERAL ---- \n\n");
            appendCategoryDetails(stringBuilder, "Activos Currientes");
            appendCategoryDetails(stringBuilder, "Activos fijos");
            stringBuilder.Append($"TOTAL ACTIVOS: $ {GetTotalActivesAmount()}\n\n");
            appendCategoryDetails(stringBuilder, "Passivos currientes");
            appendCategoryDetails(stringBuilder, "Passivos a largo plazo");
            stringBuilder.Append($"TOTAL PASSIVO: $ {GetTotalPassivesAmount()}\n");

            Console.WriteLine(stringBuilder);
        }

        private void appendCategoryDetails(StringBuilder stringBuilder, string assetType)
        {
            stringBuilder.Append($"{assetType}{Environment.NewLine}");
            HashSet<ConceptType> processedConceptTypes = new HashSet<ConceptType>();

            foreach (AccountRecord record in RecordDictionary[assetType])
            {
                ConceptType conceptType = record.GetConceptType();
                if (processedConceptTypes.Add(conceptType))
                {
                    stringBuilder.Append(EnumUtils.GetDescription(conceptType))
                            .Append(": $ ")
                            .Append(GetAmountByConceptType(conceptType)+ "\n");
                }
            }
            stringBuilder.Append($"Total {assetType}: $ {GetAmountByAsset(assetType)}{Environment.NewLine}{Environment.NewLine}");
            processedConceptTypes.Clear();
        }
    }
}
