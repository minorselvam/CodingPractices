namespace ScopedDIExm.ScopedTracker
{
    // Define a scoped service:
    public class ScopedRequestTracker : IScopedRequestTracker
    {
        private Guid _instanceID = Guid.NewGuid();
        public Guid GetInstanceId()
        {
            return _instanceID;
        }     
    }
}
