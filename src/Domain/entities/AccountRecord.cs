using EstudioCsharp.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public override string? ToString()
        {
            return $"Date: {Date}, Amount: {Amount}, ConceptType: {GetEnumDescription(ConceptType)}";
        }

        static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
