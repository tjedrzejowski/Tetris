using System;
using Core;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Action OnStartClick;
    public Action OnRestartClick;

    [SerializeField] private TetraminoSpawner spawner;
    [SerializeField] private TextDisplay levelDisplay;
    [SerializeField] private TextDisplay linesDisplay;
    [SerializeField] private SpriteDisplay spriteDisplay;
    [SerializeField] private PopUp gameOverPopUp;
    [SerializeField] private Button startButton;
    [SerializeField] private string startButtonText = "Start";
    [SerializeField] private string restartButtonText = "Restart";

    private Text _startButtonTextComponnent;
    private GameSessionData _gameSessionData;
    private bool _isGameloopActive;

    private void Start()
    { 
        spawner.onNextTetraminoSelect += HandleTetraminoListUpdate;
        _startButtonTextComponnent = startButton.GetComponentInChildren<Text>();
        SetPopUpActive(gameOverPopUp, false);
    }

    private void OnDisable()
    {
        spawner.onNextTetraminoSelect -= HandleTetraminoListUpdate;
    }

    public void SetGameloopActiveFlag(bool isActive, GameSessionData gameSessionData)
    {
        _isGameloopActive = isActive;
        _gameSessionData = gameSessionData;
        _gameSessionData.OnDataChanged += OnSessionDataChanged;
    }
    
    public void HandleGameOver()
    {
        _gameSessionData.OnDataChanged -= OnSessionDataChanged;
        SetPopUpActive(gameOverPopUp, true);
    }

    public void HandleGameReset()
    {
        _gameSessionData.OnDataChanged -= OnSessionDataChanged;
        SetPopUpActive(gameOverPopUp, false);
    }

    private void OnSessionDataChanged()
    {
        linesDisplay.UpdateDisplay(_gameSessionData.LinesCompleted);
        levelDisplay.UpdateDisplay(_gameSessionData.GameLevel);
    }

    private void HandleTetraminoListUpdate(Tetramino tetramino)
    {
        Sprite sprite = tetramino.GetSprite();
        spriteDisplay.UpdateDisplay(sprite);
    }

    public void OnStartButtonClick()
    {
        if (_isGameloopActive == false)
        {
            OnStartClick?.Invoke();            
            _startButtonTextComponnent.text = restartButtonText;
        }
        else if (_isGameloopActive == true)
        {
            OnRestartClick?.Invoke();
            _startButtonTextComponnent.text  = startButtonText;        
        }
    }

    private void SetPopUpActive(PopUp popUp, bool isActive)
    {
        popUp.gameObject.SetActive(isActive);
    }
}
