namespace TimeManagement
{
    public interface IEndable
    {
        event System.Action OnEnded;
        bool IsEnded();
    }
}