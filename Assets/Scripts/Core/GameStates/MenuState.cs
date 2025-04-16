using Core.GameComponentsProvider;
using Core.GameFlowMachine;
using UnityEngine;

namespace Core.GameStates
{
    /// <summary>
    /// Game state representing the main menu screen.
    /// </summary>
    public class MenuState : IState
    {
        private readonly ComponentsProvider _componentsProvider;
        private readonly IContext _context;
        private UIController _uiController;
        
        public MenuState(IContext context, ComponentsProvider componentsProvider)
        {
            _context = context;
            _componentsProvider = componentsProvider;
        }
        
        public void Enter()
        {
            Debug.Log("MenuState: Enter");
            _uiController = _componentsProvider.GetComponent<UIController>();
            
            _uiController.OnStartClick += OnStartClick;
        }

        public void Exit()
        {
            Debug.Log("MenuState: Exit");
            _uiController.OnStartClick -= OnStartClick;
        }

        private void OnStartClick()
        {
            _context.ChangeState(_context.StateFactory.GetGameplayState());
        }
    }
}