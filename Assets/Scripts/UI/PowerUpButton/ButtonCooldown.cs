using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the visual representation of a cooldown in the UI.
/// Displays a radial fill image and a countdown timer as text.
/// 
/// The cooldown is started via <see cref="PutOnCooldown(float)"/> and runs for a specified number of seconds.
/// During the cooldown, the fill image shrinks proportionally, and the timer shows the remaining time as whole seconds (no decimal places).
/// </summary>
public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _timerDisplay;

    private float _cooldownTime;
    private float _timeLeft;
    private bool _onCooldown;

    private void Awake()
    {
        SetDefaultState();
    }

    private void Update()
    {
        if (!_onCooldown)
        {
            return;
        }

        if (_timeLeft <= 0)
        {
            SetDefaultState();

            _onCooldown = false;
            return;
        }

        _fillImage.fillAmount = _timeLeft / _cooldownTime;
        _timerDisplay.text = _timeLeft.ToString("F0");
        _timeLeft -= Time.deltaTime;
    }

    /// <summary>
    /// Starts the cooldown timer and enables the visual UI elements.
    /// </summary>
    /// <param name="time">Cooldown duration in seconds. The timer display will round this to whole seconds.</param>
    public void PutOnCooldown(float time)
    {
        _cooldownTime = _timeLeft = time;

        _timerDisplay.text = time.ToString();
        _timerDisplay.enabled = true;
        _fillImage.enabled = true;
        _onCooldown = true;
    }

    private void SetDefaultState()
    {
        _fillImage.fillAmount = 1f;
        _fillImage.enabled = false;
        _timerDisplay.enabled = false;
    }

}
