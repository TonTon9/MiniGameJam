using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(HealthUnit))]
public abstract class Citizen : MonoBehaviour{
    [SerializeField]
    protected Transform[] _movePoint;
    
    [SerializeField]
    protected Animator _citizenAnimator;

    [SerializeField]
    protected UnitStat _stat;

    protected HealthUnit _healthUnit;

    protected NavMeshAgent _agent;
    protected CitizenAnimation _citizenAnimation;
    protected IMove _movement;

    protected virtual void Awake() {
        _stat.Init();
        _healthUnit = GetComponent<HealthUnit>();
        _agent = GetComponent<NavMeshAgent>();
        _citizenAnimation = new CitizenAnimation(_citizenAnimator);
        InitBehaviours();
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health));
        _healthUnit.OnDie += Die;
    }

    public abstract void InitBehaviours();

    protected virtual void Update() {
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