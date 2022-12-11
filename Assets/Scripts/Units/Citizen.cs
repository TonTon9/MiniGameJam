using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(HealthUnit))]
public class Citizen : MonoBehaviour {
    [SerializeField]
    private Transform[] _movePoint;
    
    [SerializeField]
    private Animator _citizenAnimator;

    [SerializeField]
    private UnitStat _stat;

    private HealthUnit _healthUnit;

    private NavMeshAgent _agent;
    private CitizenAnimation _citizenAnimation;
    private IMove _movement;

    private void Awake() {
        _stat.Init();
        _healthUnit = GetComponent<HealthUnit>();
        _agent = GetComponent<NavMeshAgent>();
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
        _citizenAnimation = new CitizenAnimation(_citizenAnimator);
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health));
        _healthUnit.OnDie += Die;
    }

    private void Update() {
        _movement.Move();
    }

    private void Die(DamageType damageType) {
        if (damageType == DamageType.Crit) {
            _citizenAnimation.PlayCoolDeadAnimation(); 
        } else {
            _citizenAnimation.PlayDeadAnimation();    
        }
        _movement.Stop();
        Destroy(gameObject, 5f);
    }
}
