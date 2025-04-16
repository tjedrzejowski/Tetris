using Core.GameFlowMachine;

namespace Core.GameStates
{
    /// <summary>
    /// Represents the core gameplay state in the Tetris game.
    /// Handles game logic, user input, and game progression.
    /// </summary>
    public class GameplayState : IState
    {
        public IContext Context { get; private set; }

        public GameplayState(IContext context)
        {
            Context = context;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
        }
    }
}