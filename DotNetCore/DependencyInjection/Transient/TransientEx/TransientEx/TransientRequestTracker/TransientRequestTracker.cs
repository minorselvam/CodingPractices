
namespace TransientEx.TransientRequestTracker
{
    public class TransientRequestTracker : ITransientRequestTracker
    {
        public Guid GetInstanceID()
        {
            return Guid.NewGuid();
        }
    }
}
