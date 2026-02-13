using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DepInjWithAbstStrategyPattern
{
    //HospitalApp (Business Logic)
    public class HospitalApp
    {
        private readonly MedicalRecordSystem _recordSystem;

        public HospitalApp(MedicalRecordSystem recordSystem)
        {
            _recordSystem = recordSystem;
        }

        public void RunHospitalApp()
        {
            _recordSystem.StoreRecord("P002", "Heart Rate: 72");
        }
    }

    //HospitalApp represents the hospital’s main application logic.
    //It doesn’t care how records are stored — it only knows it has a MedicalRecordSystem.
    //The dependency (MedicalRecordSystem) is injected via the constructor → Constructor Injection.
}
