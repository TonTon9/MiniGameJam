using System;
using UnityEngine;

public class Policeman : Citizen {
    
    public static event Action OnDie;

    [SerializeField]
    private PolicemanAttack _policemanAttack;

    private bool _isTriggered;
    
    public override void InitBehaviours() {
        SimpleCitizen.OnDie += Trigger;
        Policeman.OnDie += Trigger;
        _healthUnit.OnHealthChange += Trigger;
        _citizenAnimation.SetIsMovingBool(true);
        _policemanAttack.Init(_stat.GetStatByType(StatsType.Damage), _stat.GetStatByType(StatsType.AttackSpeed), _stat.GetStatByType(StatsType.AttackRange),_citizenAnimation);
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
    }

    private void Trigger(float arg1, float arg2) {
        Trigger();
    }

    private void Trigger() {
        SimpleCitizen.OnDie -= Trigger;
        Policeman.OnDie -= Trigger;
        _healthUnit.OnHealthChange -= Trigger;
        
        _citizenAnimation.SetIsTriggeringBool(true);
        _stat.IncreaseStatByType(StatsType.MoveSpeed, _stat.GetStatByType(StatsType.MoveSpeed).currentValue * 1.5f);
        _movement = new PolicemanMove(_agent, _stat.GetStatByType(StatsType.AttackRange), _stat.GetStatByType(StatsType.MoveSpeed), _citizenAnimation);
        _policemanAttack.TriggerPoliceman();
    }

    private void OnDestroy() {
        SimpleCitizen.OnDie -= Trigger;
        Policeman.OnDie -= Trigger;
        _healthUnit.OnHealthChange -= Trigger;
    }
    
    public override void OnDieAction() {
        OnDie?.Invoke();
    }
}