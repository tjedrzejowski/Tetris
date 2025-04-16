namespace Core.GameFlowMachine
{
    public interface IContext
    {
        IState CurrentState { get; }
        IStateFactory StateFactory { get; }
        void ChangeState(IState newState);
    }
}