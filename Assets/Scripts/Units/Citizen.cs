using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Citizen : MonoBehaviour {
    [SerializeField]
    private Transform[] _movePoint;
    
    [SerializeField]
    private Animator _citizenAnimator;

    [SerializeField]
    private UnitStat _stat;

    private NavMeshAgent _agent;
    private CitizenAnimation _citizenAnimation;
    private IMove _movement;

    private void Awake() {
        _stat.Init();
        _agent = GetComponent<NavMeshAgent>();
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
        _citizenAnimation = new CitizenAnimation(_citizenAnimator);
    }

    private void Update() {
        _movement.Move();
    }
}
