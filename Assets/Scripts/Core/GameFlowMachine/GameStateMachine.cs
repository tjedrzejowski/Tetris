using Bootstrap;

namespace Core.GameFlowMachine
{
    /// <summary>
    /// Manages transitions between different game states.
    /// Maintains the current state and handles state lifecycle (Enter/Exit).
    /// </summary>
    public class GameStateMachine : IContext
    {
        public IState CurrentState { get; private set; }
        private IStateFactory _gameStateFactory;

        public GameStateMachine(GameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }
        
        public void Init()
        {
            _gameStateFactory.Initialize(this);
            CurrentState = _gameStateFactory.GetBootState();
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