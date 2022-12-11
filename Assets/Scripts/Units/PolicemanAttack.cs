using UnityEngine;

public class PolicemanAttack : SimpleMeleeAttack {
    private Stat _damage;
    private Stat _attackSpeed;
    private Stat _attackRange;
    private float _timer;
    private bool _isReadyForAttack;
    private Transform _playerTransform;
    private CitizenAnimation _citizenAnimation;
    private bool _isTriggered;

    public void TriggerPoliceman() {
        _isTriggered = true;
    }

    public void Init(Stat damage, Stat attackSpeed, Stat attackRange, CitizenAnimation citizenAnimation) {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
        _citizenAnimation = citizenAnimation;
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    private void Update() {
        if(!_isTriggered) return;
        if (_timer <= 0) {
            _isReadyForAttack = true;
        } else {
            _timer -= Time.deltaTime;
        }

        if ((_playerTransform.transform.position - transform.position).sqrMagnitude <= _attackRange.currentValue) {
            StartAttack();
        }
    }

    private void StartAttack() {
        _citizenAnimation.SetIsAttackingBool(true);
    }

    private void AttackFromAnimation() {
        DoAttackAction(_damage.currentValue, DamageType.Normal);
    }

    protected override void DoAttackAction(float damage, DamageType damageType) {
        base.DoAttackAction(damage, damageType);
        _citizenAnimation.SetIsAttackingBool(false);
        _isReadyForAttack = true;
        _timer = _attackSpeed.currentValue;
        
    }
}