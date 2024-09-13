namespace TimeManagement
{
    public interface IPlayable
    {
        event System.Action OnStarted;
        event System.Action OnStopped;

        bool IsPlaying();
        bool Start();
        bool Stop();
    }
}