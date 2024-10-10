namespace TimeManagement
{
    public interface IDurationable
    {
        event System.Action<float> OnDurationChanged; 

        float GetDuration();
        void SetDuration(float newDuration);
    }
}