namespace CallQueue.AppLocal
{
    public interface ISupportTransitions
    {
        void StartTransition(bool forward, object waitParameters);
        void EndTransition();
    }
}
