using System;

public class SimpleCitizen : Citizen {

    public static event Action OnDie;
    
    public override void InitBehaviours() {
        SimpleCitizen.OnDie += Trigger;
        Policeman.OnDie += Trigger;
        _healthUnit.OnHealthChange += Trigger;
        _citizenAnimation.SetIsMovingBool(true);
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
    }
    
    public override void OnDieAction() {
        OnDie?.Invoke();
    }
    
    private void Trigger(float arg1, float arg2) {
        Trigger();
    }
    
    private void Trigger() {
        SimpleCitizen.OnDie -= Trigger;
        _healthUnit.OnHealthChange -= Trigger;
        Policeman.OnDie -= Trigger;
        _citizenAnimation.SetIsTriggeringBool(true);
        _stat.IncreaseStatByType(StatsType.MoveSpeed, _stat.GetStatByType(StatsType.MoveSpeed).currentValue * 2);
    }
    
    private void OnDestroy() {
        SimpleCitizen.OnDie -= Trigger;
        _healthUnit.OnHealthChange -= Trigger;
        Policeman.OnDie -= Trigger;
    }
    
}