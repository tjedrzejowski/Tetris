using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private TetraminoController tetraminoController;
    [SerializeField] private TetraminoSpawner spawner;
    private List<PowerUpButton> _powerUpsButtons = new();

    private void Start()
    {
        playerInput.onMoveRightInput += HandleMoveRightInput;
        playerInput.onMoveLeftInput += HandleMoveLeftInput;
        playerInput.onMoveDownInput += HandleMoveDownInput;
        playerInput.onRotateInput += HandleRotateInput;
        playerInput.onPowerUpInput += HandlePowerUpInput;
    }

    private void OnDisable()
    {
        playerInput.onMoveRightInput -= HandleMoveRightInput;
        playerInput.onMoveLeftInput -= HandleMoveLeftInput;
        playerInput.onMoveDownInput -= HandleMoveDownInput;
        playerInput.onRotateInput -= HandleRotateInput;
        playerInput.onPowerUpInput -= HandlePowerUpInput;
        foreach (var button in _powerUpsButtons)
        {
            button.onActivePowerUp -= HandlePowerUpActivation;
        }
    }

    public void RegisterPowerUpButton(PowerUpButton button)
    {
        _powerUpsButtons.Add(button);
        button.onActivePowerUp += HandlePowerUpActivation;
    }

    private void HandlePowerUpInput(int buttonIndex)
    {
        _powerUpsButtons[buttonIndex].ActivatePowerUp();
    }

    private void HandlePowerUpActivation(int powerUpIndex)
    {
        spawner.AddPowerUpToPool(powerUpIndex);
    }

    private void HandleRotateInput()
    {
        tetraminoController.TryRotate();
    }

    private void HandleMoveDownInput()
    {
        tetraminoController.TryMove(Vector3.down);
    }

    private void HandleMoveLeftInput()
    {
        tetraminoController.TryMove(Vector3.left);
    }

    private void HandleMoveRightInput()
    {
        tetraminoController.TryMove(Vector3.right);
    }
}
