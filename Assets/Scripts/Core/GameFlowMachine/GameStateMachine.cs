namespace Core.GameFlowMachine
{
    /// <summary>
    /// Manages transitions between different game states.
    /// Maintains the current state and handles state lifecycle (Enter/Exit).
    /// </summary>
    public class GameStateMachine : IContext
    {
        public IState CurrentState { get; private set; }
        public IStateFactory StateFactory { get; }

        public GameStateMachine(GameStateFactory gameStateFactory)
        {
            StateFactory = gameStateFactory;
        }
        
        public void Init()
        {
            StateFactory.Initialize(this);
            CurrentState = StateFactory.GetBootState();
            CurrentState.Enter();
        }

        public void ChangeState(IState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}