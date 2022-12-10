using UnityEngine;
using UnityEngine.AI;

public class MoveFromPointToPoint : IMove {
    private Transform[] _pointsToMove;
    private NavMeshAgent _navMeshAgent;
    private Transform _currentPointToMove;

    public MoveFromPointToPoint(NavMeshAgent navMeshAgent, Transform[] pointsToMove, Stat speed) {
        _navMeshAgent = navMeshAgent;
        _pointsToMove = pointsToMove;
        _navMeshAgent.speed = speed.currentValue;
        ChooseNewMovePoint();
    }

    public void Move() {
        if(IsReachTarget()) {
            ChooseNewMovePoint();
        }
        _navMeshAgent.SetDestination(_currentPointToMove.position);
    }

    private void ChooseNewMovePoint() {
        _currentPointToMove = _pointsToMove[Random.Range(0, _pointsToMove.Length)];
    }

    private bool IsReachTarget() {
        if ((_currentPointToMove.position - _navMeshAgent.transform.position).sqrMagnitude <= 1) {
            return true;
        }
        return false;
    }
    
    public float GetSpeed() {
        throw new System.NotImplementedException();
    }
}