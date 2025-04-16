using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameLoopManager gameLoopManager;
    [SerializeField] private UIController uIController;
    [SerializeField] private Timer timerPrefab;
    [SerializeField] private int lineThreshold;
    
    //TODO: gameplay elements - move to gameplay state
    private Timer _fallTimer;
    private int _gameLevel = 0;
    private float _fallTime = 1f;
    private int _lineCompleted = 0;

    private void Awake()
    {
        //TODO: gameplay elements:
        SetFallTimer();
        //uIController.OnRestartClick += OnRestratClick;
        gameLoopManager.onLineCompleted += OnLineCompleated;
        gameLoopManager.onLastRowReached += OnLastRowReached;
        uIController.SetGameloopActiveFlag(false); 
        
        // uIController.onStartClick += OnStartClick;
    }

    private void OnDisable()
    {
        // uIController.onStartClick -= OnStartClick;
        //uIController.OnRestartClick -= OnRestratClick;
        gameLoopManager.onLineCompleted -= OnLineCompleated;
        gameLoopManager.onLastRowReached -= OnLastRowReached;
        _fallTimer.onTimeOut -= gameLoopManager.TetraminoFall;
    }
    private void SetFallTimer()
    {
        _fallTimer = Instantiate(timerPrefab, this.transform);
        _fallTimer.CountDownTime = _fallTime;
        _fallTimer.IsContinuous = true;
        _fallTimer.onTimeOut += gameLoopManager.TetraminoFall;
    }

    public void StartGameplay()
    {
        gameLoopManager.StartGame();
        uIController.SetGameloopActiveFlag(true);
        _fallTimer.SetActive(true);
    }

    public void RestartGameplay()
    {
        _fallTimer.SetActive(false);
        gameLoopManager.RestartGame();
        uIController.SetGameloopActiveFlag(false);
        
        // Clear player Points;
        _lineCompleted = 0;
        _gameLevel = 0;
        uIController.HandleGameReset();
        
    }

    private void OnLastRowReached()
    {
        GameOver();
    }

    private void GameOver()
    {
        _fallTimer.SetActive(false);
        uIController.HandleGameOver();
    }

    private void OnLineCompleated()
    {
        _lineCompleted++;
        if(_lineCompleted % lineThreshold == 0)
        {
            RiseGameLevel();
        }
        uIController.HandleLineCompleted(_lineCompleted);
    }

    private void RiseGameLevel()
    {
        _gameLevel++;
        _fallTime -= 0.15f;
        _fallTimer.CountDownTime = _fallTime;
        uIController.HandleLevelChange(_gameLevel);
    }
}