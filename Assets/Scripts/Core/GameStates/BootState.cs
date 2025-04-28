using Core.DataController;
using Core.GameComponentsProvider;
using Core.GameFlowMachine;

namespace Core.GameStates
{
    /// <summary>
    /// Initial game state during bootstrapping.
    /// </summary>
    public class BootState : IState
    {
        private readonly IContext _context;
        private readonly ComponentsProvider _componentsProvider;

        public BootState(IContext context, ComponentsProvider componentsProvider)
        {
            _context = context;
            _componentsProvider = componentsProvider;
        }
        
        public void Enter()
        {
            var dataProvider = new DataProvider();
            _componentsProvider.RegisterComponent(dataProvider);
            TransitToNextState();
        }

        public void Exit()
        {
            
        }

        private void TransitToNextState()
        {
            _context.ChangeState(_context.StateFactory.GetMenuState());            
        }
    }
}