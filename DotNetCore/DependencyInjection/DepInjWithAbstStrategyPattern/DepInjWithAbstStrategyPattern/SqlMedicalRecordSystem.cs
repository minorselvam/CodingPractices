using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInjWithAbstStrategyPattern
{
    public class SqlMedicalRecordSystem : MedicalRecordSystem
    {
        public override void StoreRecord(string patientId, string recordData)
        {
            Console.WriteLine($"[SQL] Stored record for {patientId}: {recordData}");
        }

            //Concrete implementation of the abstract class.

            //Provides its own logic for storing records:

            //SQL → stores in a database.
    }
}
