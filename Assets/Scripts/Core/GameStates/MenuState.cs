using Core.GameFlowMachine;

namespace Core.GameStates
{
    /// <summary>
    /// Game state representing the main menu screen.
    /// </summary>
    public class MenuState : IState
    {
        public IContext Context { get; private set; }
        
        public MenuState(IContext context)
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