using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[Serializable]
public class UnitStat{
    [SerializeField]
    private Stat _health;
    
    [SerializeField]
    private Stat _damage;
    
    [SerializeField]
    private Stat _attackSpeed;

    [SerializeField]
    private Stat _attackRange;
    
    [SerializeField]
    private Stat _moveSpeed;

    private List<Stat> _stats = new();

    public void Init() {
        _stats.Add(_health.InitStat());
        _stats.Add(_damage.InitStat());
        _stats.Add(_attackSpeed.InitStat());
        _stats.Add(_attackRange.InitStat());
        _stats.Add(_moveSpeed.InitStat());
    }

    public void SetStatValueByType(StatsType type, float value) {
        var stat = GetStatByType(type);
        stat.SetValue(value);
    }
    
    public void IncreaseStatByType(StatsType type, float value) {
        var stat = GetStatByType(type);
        stat.SetValue(stat.currentValue + value);
    }

    public void DecreaseStatByType(StatsType type, float value) {
        var stat = GetStatByType(type);
        stat.SetValue(stat.currentValue - value);
    }

    public float GetStatStartValueByType(StatsType type) {
        return GetStatByType(type).startValue;
    }

    public Stat GetStatByType(StatsType type) {
        var stat = _stats.FirstOrDefault(s => s.type.Equals(type));
        if (stat == null) {
            throw new Exception($"Have no stat with type {type}");
        }
        return stat;
    }

}