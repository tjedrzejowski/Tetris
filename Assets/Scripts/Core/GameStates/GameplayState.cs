using Core.GameComponentProvider;
using Core.GameFlowMachine;
using UnityEngine;

namespace Core.GameStates
{
    /// <summary>
    /// Represents the core gameplay state in the Tetris game.
    /// Handles game logic, user input, and game progression.
    /// </summary>
    public class GameplayState : IState
    {
        private readonly ComponentProvider _componentProvider;
        private readonly IContext _context;
        
        // temp
        private GameController _gameController;
        private UIController _uiController;

        public GameplayState(IContext context, ComponentProvider componentProvider)
        {
            _context = context;
            _componentProvider = componentProvider;
        }
        
        public void Enter()
        {
            Debug.Log("GameplayState: Enter");
            _gameController = _componentProvider.GetComponent<GameController>();
            
            _gameController.StartGameplay();
            _uiController = _componentProvider.GetComponent<UIController>();

            _uiController.OnRestartClick += OnRestartClick;
        }

        public void Exit()
        {
            Debug.Log("GameplayState: Exit");
            _uiController.OnRestartClick -= OnRestartClick;
        }

        private void OnRestartClick()
        {
            _context.ChangeState(_context.StateFactory.GetMenuState());
        }
    }
}