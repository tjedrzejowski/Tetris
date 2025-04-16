namespace Core.GameFlowMachine
{
    /// <summary>
    /// Represents a single state in the game state machine.
    /// Defines lifecycle methods for entering and exiting the state.
    /// </summary>
    public interface IState
    {
        void Enter();
        void Exit();
    }
}