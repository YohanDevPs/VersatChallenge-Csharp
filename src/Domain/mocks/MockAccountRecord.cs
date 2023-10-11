using EstudioCsharp.enums;
using EstudioCsharp.src.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.mocks
{
    internal class MockAccountRecord
    {
       public static HashSet<AccountRecord> GenerateRandomAccountRecords(int size)
        {
            HashSet<AccountRecord> records = new HashSet<AccountRecord>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                records.Add(new AccountRecord(
                    new DateTime(
                        random.Next(2020, 2024),
                        random.Next(1, 12),
                        random.Next(1, 29)
                    ),
                    Convert.ToDecimal(random.Next(1000, 50000)),
                    GenerateRandomConceptType(random)
                ));
            }

            return records;
        }


        private static ConceptType GenerateRandomConceptType(Random random)
        {
            ConceptType[] values = (ConceptType[])Enum.GetValues(typeof(ConceptType));
            int randomIndex = random.Next(0, values.Length);
            return values[randomIndex];
        }
    }
}
