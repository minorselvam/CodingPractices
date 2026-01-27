namespace SingletonDIExm.SingletonTracker
{
    public class SingletonTracker: ISingletonTracker
    {
        private Guid _instanceID = new Guid();

        public Guid GetInstanceId()
        {
            return _instanceID;
        } 
    }
}
