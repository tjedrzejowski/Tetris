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
        private readonly GameSessionData _sessionData;
        
        private UIController _uiController;
        private GameLoopManager _gameLoopManager;
        private Timer _fallTimer;
        
        //TODO: config proxy
        private float _fallTime = 1f;
        private int _lineThreshold = 5;
        
        public GameplayState(IContext context, ComponentsProvider componentsProvider)
        {
            _context = context;
            _componentsProvider = componentsProvider;
            _sessionData = new GameSessionData();
        }
        
        public void Enter()
        {
            Debug.Log("GameplayState: Enter");
            
            _uiController = _componentsProvider.GetComponent<UIController>();
            _gameLoopManager = _componentsProvider.GetComponent<GameLoopManager>();
            _fallTimer = _componentsProvider.GetComponent<Timer>();
            
            _uiController.OnRestartClick += OnRestartClick;
            _gameLoopManager.onLineCompleted += OnLineCompleted;
            _gameLoopManager.onLastRowReached += OnLastRowReached;
            
            SetFallTimer();
            StartGameplay();
        }

        public void Exit()
        {
            Debug.Log("GameplayState: Exit");
            _uiController.OnRestartClick -= OnRestartClick;
            _gameLoopManager.onLineCompleted -= OnLineCompleted;
            _gameLoopManager.onLastRowReached -= OnLastRowReached;
            _fallTimer.onTimeOut -= _gameLoopManager.TetraminoFall;
        }

        private void OnRestartClick()
        {
            RestartGameplay();
            _sessionData.ResetValues();
            _context.ChangeState(_context.StateFactory.GetMenuState());
        }

        private void StartGameplay()
        {
            _gameLoopManager.StartGame();
            _uiController.SetGameloopActiveFlag(true, _sessionData);
            _fallTimer.SetActive(true);
        }

        private void RestartGameplay()
        {
            _fallTimer.SetActive(false);
            _gameLoopManager.RestartGame();
            _uiController.SetGameloopActiveFlag(false, _sessionData);
            _uiController.HandleGameReset();
        }
        
        private void SetFallTimer()
        {
            _fallTimer.CountDownTime = _fallTime;
            _fallTimer.IsContinuous = true;
            _fallTimer.onTimeOut += _gameLoopManager.TetraminoFall;
        }
        
        private void OnLastRowReached()
        {
            GameOver();
        }

        private void GameOver()
        {
            _fallTimer.SetActive(false);
            _uiController.HandleGameOver();
        }
        
        private void OnLineCompleted()
        {
            _sessionData.LinesCompleted++;
            if(_sessionData.LinesCompleted % _lineThreshold == 0)
            {
                RiseGameLevel();
            }
        }
        
        private void RiseGameLevel()
        {
            _sessionData.GameLevel++;
            _fallTime -= 0.15f;
            _fallTimer.CountDownTime = _fallTime;
        }
    }
}