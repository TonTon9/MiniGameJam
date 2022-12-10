using System;
using UnityEngine;

[Serializable]
public class Stat {
    public event Action<float> OnChangeValue;
    
    [field: SerializeField]
    public StatsType type { get; private set; }

    [field: SerializeField]
    public float startValue { get; private set; }
    
    [field: SerializeField]
    public float currentValue { get; private set; }

    public void SetValue(float value) {
        currentValue = value;
        OnChangeValue?.Invoke(currentValue);
    }

    public Stat InitStat() {
        currentValue = startValue;
        return this;
    }
}