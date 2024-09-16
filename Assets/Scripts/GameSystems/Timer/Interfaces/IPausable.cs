namespace TimeManagement
{
    public interface IPausable
    {
        event System.Action OnPaused;
        event System.Action OnResumed;

        bool IsPaused();

        bool Pause();
        bool Resume();
    }
}