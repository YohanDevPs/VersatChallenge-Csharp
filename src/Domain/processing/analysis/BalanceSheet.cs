using EstudioCsharp.src.Domain.entities;
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

        public decimal GetTotalActivesAmount()
        {
            return FinancialDataProcessor.GetTotalActivesAmount(RecordDictionary);
        }

        public decimal GetTotalPassivesAmount()
        {
            return FinancialDataProcessor.GetTotalPassivesAmount(RecordDictionary);
        }
    }
}
