using UnityEngine;

public class Policeman : Citizen {

    [SerializeField]
    private PolicemanAttack _policemanAttack;

    private bool _isTriggered;
    
    public override void InitBehaviours() {
        _citizenAnimation.SetIsMovingBool(true);
        _policemanAttack.Init(_stat.GetStatByType(StatsType.Damage), _stat.GetStatByType(StatsType.AttackSpeed), _stat.GetStatByType(StatsType.AttackRange),_citizenAnimation);
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
    }

    [ContextMenu("Trigger")]
    public void Trigger() {
        _citizenAnimation.SetIsTriggeringBool(true);
        _stat.IncreaseStatByType(StatsType.MoveSpeed, _stat.GetStatByType(StatsType.MoveSpeed).currentValue);
        _movement = new PolicemanMove(_agent, _stat.GetStatByType(StatsType.AttackRange), _stat.GetStatByType(StatsType.MoveSpeed), _citizenAnimation);
        _policemanAttack.TriggerPoliceman();
    }
}