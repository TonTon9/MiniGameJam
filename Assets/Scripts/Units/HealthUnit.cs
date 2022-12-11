using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HealthUnit : MonoBehaviour
{
    public event Action<DamageType> OnDie;
    public event Action<float, float> OnHealthChange;

    [SerializeField]
    private GameObject _bloodVfx;

    [SerializeField]
    private HealthDisplay _healthDisplay;

    [SerializeField]
    public Transform _bodyPoint;

    private Stat _health;

    private GameObject _bloodGameObject;
    private float healPercent = 0.2f;


    public void Init(Stat health) {
        _health = health;
        _health.OnChangeValue += ChangeHealth;
        _healthDisplay.Init(this, _health.currentValue, _health.maxValue);
    }
    
    public void TakeDamage(float damage, DamageType damageType) {
        if(_health.currentValue<= 0) return;
        _health.SetValue(_health.currentValue - damage);
        if (_health.currentValue <= 0) {
            _health.SetValue(0);
            OnDie?.Invoke(damageType);
        }
        _bloodGameObject = Instantiate(_bloodVfx, _bodyPoint.position, _bodyPoint.rotation);
        Destroy(_bloodGameObject, 1f);
        
    }

    private void ChangeHealth(float health) {
        OnHealthChange?.Invoke(_health.currentValue, _health.maxValue);
    } 

    public void HealByAttack(float damage) {
        float healValue = damage * healPercent;
        _health.SetValue(_health.currentValue + healValue);
    }
}