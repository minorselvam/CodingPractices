using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DepInjWithAbstStrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Setup DI container
            var services = new ServiceCollection();

            // Register dependencies 
            // In production, you configure this based on hospital preference
            services.AddScoped<MedicalRecordSystem, CloudMedicalRecordSystem>();
            services.AddScoped<HospitalApp>();

            // Build provider
            var serviceProvider = services.BuildServiceProvider(); 
            
            // Resolve HospitalApp with dependencies injected automatically
            var app = serviceProvider.GetRequiredService<HospitalApp>();
            app.RunHospitalApp();
        }
    }    
}

//The DI container(ServiceCollection) manages dependencies.
//You configure which implementation to use (CloudMedicalRecordSystem).

//When HospitalApp is requested, the DI container automatically injects the correct dependency.

//If tomorrow you switch to SQL, you just change the DI configuration — no code changes in HospitalApp.

/*
🔍 What’s Happening Here
Abstraction(MedicalRecordSystem) → Defines the contract.

Concrete Implementations(SqlMedicalRecordSystem, CloudMedicalRecordSystem) → Provide actual storage logic.

HospitalApp → Business logic, depends only on abstraction.

DI Container → Decides which implementation to inject at runtime.

🏥 Real Use Case
Hospital A → Configures DI to use SQL backend.

Hospital B → Configures DI to use Cloud backend.

Both run the same HospitalApp.

Only configuration changes, not business logic → flexible, maintainable, production-ready.

🎯 Technical Name of This Approach
This design combines several OOP and design principles:

Abstraction (OOP Concept)

MedicalRecordSystem defines a contract.

Concrete classes implement it.

Dependency Injection (Design Pattern / Architecture)

HospitalApp receives its dependency via constructor injection.

DI container manages object creation and wiring.

Strategy Pattern (Design Pattern)

Different storage strategies (SQL, Cloud) can be swapped at runtime.

HospitalApp doesn’t change — only the injected strategy changes.

SOLID Principles

DIP (Dependency Inversion Principle) → HospitalApp depends on abstraction, not concrete classes.

OCP(Open/Closed Principle) → You can add new storage types(e.g., FileSystem) without modifying existing code.

SRP(Single Responsibility Principle) → Each class has one responsibility(app logic vs storage logic).

🏷️ Final Label
This approach can be technically named as:

“Strategy Pattern implemented via Dependency Injection, following the Dependency Inversion Principle of SOLID.”

*/