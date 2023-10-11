using EstudioCsharp.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.entities
{
    internal class AccountRecord
    {
        private DateTime Date {  get; set; }    
        private decimal Amount { get; set; }
        private ConceptType ConceptType { get; set; }

        public AccountRecord(DateTime date, decimal amount, ConceptType conceptType)
        {
            Date = date;
            Amount = amount;
            ConceptType = conceptType;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public decimal GetAmount()
        {
            return Amount;
        }

        public ConceptType GetConceptType()
        {
            return ConceptType;
        }
    }
}
