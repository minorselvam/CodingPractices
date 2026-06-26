namespace DepInjWithAbstStrategyPattern
{
    // Abstract contract
    public abstract class MedicalRecordSystem
    {
        public abstract void StoreRecord(string patientId, string recordData);
    }

    //This is an abstract class.
    //It defines a contract: every medical record system must implement StoreRecord.
    //No implementation is provided here — subclasses must override it.
}
