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
        if (_citizenAnimation.GetAttackBool()) {
            Stop();
            _navMeshAgent.transform.LookAt(new Vector3(_playerTransform.position.x, _navMeshAgent.transform.position.y, _playerTransform.position.z));
        } else {
            _navMeshAgent.isStopped = false;
            if ((_playerTransform.position - _navMeshAgent.transform.position).sqrMagnitude > _attackRange.currentValue) {
                _navMeshAgent.SetDestination(_playerTransform.transform.position);
                _citizenAnimation.SetIsMovingBool(true);
            } else {
                _citizenAnimation.SetIsMovingBool(false);
            }
        }
    }
    
    public void Stop() {
        _navMeshAgent.ResetPath();
        _navMeshAgent.isStopped = true;
    }

    public float GetSpeed() {
        return 0;
    }
}