using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonCooldown))]
public class PowerUpButton : MonoBehaviour
{
    public Action<int> onActivePowerUp;

    [SerializeField] private Image _iconImage;
    [SerializeField] private ButtonCooldown _cooldown;

    private PowerUpData _config;

    public void Init(PowerUpData config)
    {
        _config = config;
        _iconImage.sprite = _config.Icon;
    }

    public void ActivatePowerUp()
    {
        if (_cooldown.OnCooldown)
        {
            return;
        }

        onActivePowerUp?.Invoke(_config.Id);
        _cooldown.PutOnCooldown(_config.Cooldown);
    }
}
