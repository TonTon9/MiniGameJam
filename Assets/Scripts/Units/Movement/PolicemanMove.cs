using UnityEngine;
using UnityEngine.AI;

public class PolicemanMove : IMove {
    
    private Stat _attackRange;
    private Stat _speed;
    private Transform _playerTransform;
    private NavMeshAgent _navMeshAgent;
    private bool _isStopped;
    private CitizenAnimation _citizenAnimation;

    public PolicemanMove(NavMeshAgent navMeshAgent, Stat attackRange, Stat speed, CitizenAnimation citizenAnimation) {
        _navMeshAgent = navMeshAgent;
        _attackRange = attackRange;
        _speed = speed;
        _citizenAnimation = citizenAnimation;
        _playerTransform = GameObject.FindObjectOfType<Player>().transform;
        _navMeshAgent.speed = _speed.currentValue * 2f;
    }

    public void Move() {
        if(_citizenAnimation.GetAttackBool()) return;

        if ((_playerTransform.position - _navMeshAgent.transform.position).sqrMagnitude > _attackRange.currentValue) {
            _navMeshAgent.SetDestination(_playerTransform.transform.position);
            _citizenAnimation.SetIsMovingBool(true);
        } else {
            _citizenAnimation.SetIsMovingBool(false);
        }
        
    }
    
    public void Stop() {
        
    }

    public float GetSpeed() {
        return 0;
    }
}