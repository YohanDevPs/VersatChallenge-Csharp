using EstudioCsharp.src.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public HashSet<AccountRecord> getFilteredAccountRecords()
        {
            return AccountRecords
                .Where(record => 
                    record.GetDate() >= StartDate 
                    && record.GetDate() <= EndDate)
                .ToHashSet();
        }
    }
}
