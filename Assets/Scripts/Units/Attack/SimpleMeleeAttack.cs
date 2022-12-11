using UnityEngine;

public class SimpleMeleeAttack : MonoBehaviour {

    private Collider[] _results = new Collider[10];
    
    [SerializeField]
    private Transform _attackPoint;

    [SerializeField]
    private LayerMask _targetLayer;

    [SerializeField]
    private FloatingText _floatingTextPrefab;

    private Stat _damage;

    public void SetDamageStat(Stat damageStat) {
        _damage = damageStat;
    }

    protected virtual void DoAttackAction(float damage, DamageType damageType) {
        int numFound = Physics.OverlapSphereNonAlloc(_attackPoint.position, 1f, _results, _targetLayer);
        for (int i = 0; i < numFound; i++) {
            if (_results[i].TryGetComponent(out HealthUnit healthUnit)) {
                if (damageType == DamageType.Crit) {
                    Instantiate(_floatingTextPrefab, healthUnit._bodyPoint.position, healthUnit.transform.rotation);
                }
                healthUnit.TakeDamage(damage, damageType);
            }
        }
    }

    public void StrongAttack() {
        DoAttackAction(_damage.currentValue * 3f, DamageType.Crit);
    }
    
    public void SimpleAttack() {
        DoAttackAction(_damage.currentValue, DamageType.Normal);
    }
}