using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Data;
using Core.GameComponentsProvider;

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

    // PowerUps Region:
    // TODO: Replace with data provider
    [SerializeField] private List<PowerUpData> powerUpDatas;
    [SerializeField] private PowerUpButton powerUpButtonPrefab;
    [SerializeField] private Transform _leftUiContainer;
    [SerializeField] private Transform _powerUpButtonsContainer;

    private readonly List<PowerUpButton> _powerUpButtons = new();
    // -------

    private Text _startButtonTextComponnent;
    private bool _isGameloopActive;

    private void Start()
    {
        spawner.onNextTetraminoSelect += HandleTetraminoListUpdate;
        _startButtonTextComponnent = startButton.GetComponentInChildren<Text>();
        SetPopUpActive(gameOverPopUp, false);

        _leftUiContainer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        spawner.onNextTetraminoSelect -= HandleTetraminoListUpdate;
    }

    public void Init(ComponentsProvider componentsProvider)
    {
        ClearPowerUpButtons(); // handle with this controller refactor
        SetPowerUpButtons();

        // register poerup button in input controller
        var inputController = componentsProvider.GetComponent<InputController>();
        foreach (var item in _powerUpButtons)
        {
            inputController.RegisterPowerUpButton(item);
        }


        // show left ui panel
        _leftUiContainer.gameObject.SetActive(true);
    }

    private void SetPowerUpButtons()
    {
        foreach (var item in powerUpDatas)
        {
            var newButton = Instantiate(powerUpButtonPrefab, _powerUpButtonsContainer);
            newButton.Init(item);
            _powerUpButtons.Add(newButton);
        }
    }

    private void ClearPowerUpButtons()
    {
        //TODO object pooling
        foreach (var item in _powerUpButtons)
        {
            Destroy(item.gameObject);
        }
        _powerUpButtons.Clear();
    }

    public void SetGameloopActiveFlag(bool isActive)
    {
        _isGameloopActive = isActive;
    }

    public void HandleGameOver()
    {
        SetPopUpActive(gameOverPopUp, true);
    }

    public void HandleGameReset()
    {
        SetPopUpActive(gameOverPopUp, false);
    }

    public void HandleLineCompleted(int value)
    {
        linesDisplay.UpdateDisplay(value);
    }

    public void HandleLevelChange(int value)
    {
        levelDisplay.UpdateDisplay(value);
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
            _startButtonTextComponnent.text = startButtonText;
            _leftUiContainer.gameObject.SetActive(false);
        }
    }

    private void SetPopUpActive(PopUp popUp, bool isActive)
    {
        popUp.gameObject.SetActive(isActive);
    }
}
