using Core.GameComponentsProvider;
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
        private readonly ComponentsProvider _componentsProvider;
        private readonly IContext _context;

        // temp
        private GameController _gameController;
        private UIController _uiController;

        public GameplayState(IContext context, ComponentsProvider componentsProvider)
        {
            _context = context;
            _componentsProvider = componentsProvider;
        }

        public void Enter()
        {
            Debug.Log("GameplayState: Enter");
            _gameController = _componentsProvider.GetComponent<GameController>();

            _gameController.StartGameplay();
            _uiController = _componentsProvider.GetComponent<UIController>();

            _uiController.Init(_componentsProvider);
            _uiController.OnRestartClick += OnRestartClick;
        }

        public void Exit()
        {
            Debug.Log("GameplayState: Exit");
            _uiController.OnRestartClick -= OnRestartClick;
        }

        private void OnRestartClick()
        {
            _gameController.RestartGameplay();
            _context.ChangeState(_context.StateFactory.GetMenuState());
        }
    }
}