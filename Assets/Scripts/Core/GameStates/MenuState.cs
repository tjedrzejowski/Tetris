using Core.GameComponentProvider;
using Core.GameFlowMachine;
using UnityEngine;

namespace Core.GameStates
{
    /// <summary>
    /// Game state representing the main menu screen.
    /// </summary>
    public class MenuState : IState
    {
        private readonly ComponentProvider _componentProvider;
        private readonly IContext _context;
        private UIController _uiController;
        
        public MenuState(IContext context, ComponentProvider componentProvider)
        {
            _context = context;
            _componentProvider = componentProvider;
        }
        
        public void Enter()
        {
            Debug.Log("MenuState: Enter");
            _uiController = _componentProvider.GetComponent<UIController>();
            
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