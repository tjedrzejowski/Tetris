using Core.GameFlowMachine;

namespace Core.GameStates
{
    /// <summary>
    /// Initial game state during bootstrapping.
    /// </summary>
    public class BootState : IState
    {
        public IContext Context { get; private set; }

        public BootState(IContext context)
        {
            Context = context;
        }
        
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}