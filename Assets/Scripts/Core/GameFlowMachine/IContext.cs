namespace Core.GameFlowMachine
{
    public interface IContext
    {
        IState CurrentState { get; }
    }
}