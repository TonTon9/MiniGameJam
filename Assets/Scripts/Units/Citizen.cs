using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(HealthUnit))]
public abstract class Citizen : MonoBehaviour {

    [SerializeField]
    protected List<Transform> _movePoint;
    
    [SerializeField]
    protected Animator _citizenAnimator;

    [SerializeField]
    protected UnitStat _stat;

    protected HealthUnit _healthUnit;

    protected NavMeshAgent _agent;
    protected CitizenAnimation _citizenAnimation;
    private BoxCollider _collider;
    protected IMove _movement;

    public void Init(List<Transform> movePoints) {
        _movePoint = movePoints;
        _stat.Init();
        _healthUnit = GetComponent<HealthUnit>();
        _agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<BoxCollider>();
        _citizenAnimation = new CitizenAnimation(_citizenAnimator);
        InitBehaviours();
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health));
        _healthUnit.OnDie += Die;
    }

    public abstract void InitBehaviours();

    public abstract void OnDieAction();

    protected virtual void Update() {
        _movement.Move();
    }

    private void Die(DamageType damageType) {
        OnDieAction();
        _collider.enabled = false;
        if (damageType == DamageType.Crit) {
            _citizenAnimation.PlayCoolDeadAnimation(); 
        } else {
            _citizenAnimation.PlayDeadAnimation();    
        }
        _movement.Stop();
        Destroy(gameObject, 5f);
    }

}