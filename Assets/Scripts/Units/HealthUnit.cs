using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HealthUnit : MonoBehaviour
{
    public event Action OnDie;
    public event Action<float, float> OnHealthChange;

    [SerializeField]
    private HealthDisplay _healthDisplay;

    public void Init(float currentValue, float startValue) {
        _healthDisplay.Init(this, currentValue, startValue);
    }
    
    public void TakeDamage(float damage) {
        OnHealthChange?.Invoke(50, 100);
    }

    private void Die() {
        
    }
}