using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealthBar;
    [SerializeField] private float _currentHealth;
    private ShipHealth ShipHealth;

    private void Awake()
    {
        ShipHealth = GetComponent<ShipHealth>();
    }
    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        _currentHealth = ShipHealth._health;
        _sliderHealthBar.value = ShipHealth._health;
    }
}
