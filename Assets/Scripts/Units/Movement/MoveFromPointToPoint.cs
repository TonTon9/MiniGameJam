using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveFromPointToPoint : IMove {
    private List<Transform> _pointsToMove;
    private NavMeshAgent _navMeshAgent;
    private Transform _currentPointToMove;
    private Stat _speed;
    private bool _isStopped = false;

    public MoveFromPointToPoint(NavMeshAgent navMeshAgent, List<Transform> pointsToMove, Stat speed) {
        _navMeshAgent = navMeshAgent;
        _pointsToMove = pointsToMove;
        _speed = speed;
        _navMeshAgent.speed = _speed.currentValue;
        _speed.OnChangeValue += UpdateSpeed;
        ChooseNewMovePoint();
    }

    private void UpdateSpeed(float currentSpeed) {
        _navMeshAgent.speed = _speed.currentValue;
    }

    public void Move() {
        if(_isStopped) return;
        if(IsReachTarget()) {
            ChooseNewMovePoint();
        }
        _navMeshAgent.SetDestination(_currentPointToMove.position);
    }

    private void ChooseNewMovePoint() {
        _currentPointToMove = _pointsToMove[Random.Range(0, _pointsToMove.Count)];
    }

    private bool IsReachTarget() {
        
        if (_currentPointToMove == null)
        {
            return false;
        }
        if ((_currentPointToMove.position - _navMeshAgent.transform.position).sqrMagnitude <= 4) {
            
            return true;
        }
        return false;
    }

    public void Stop() {
        _isStopped = true;
        _navMeshAgent.ResetPath();
    }
    
    public float GetSpeed() {
        throw new System.NotImplementedException();
    }
}