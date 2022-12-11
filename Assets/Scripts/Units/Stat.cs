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
    public float maxValue { get; private set; }
    
    [field: SerializeField]
    public float currentValue { get; private set; }

    public void SetValue(float value) {
        currentValue = value;
        if (currentValue > maxValue) {
            currentValue = maxValue;
        }
        OnChangeValue?.Invoke(currentValue);
    }

    public void SetCurrentAndMaxValue(float value) {
        maxValue = value;
        SetValue(value);
    }

    public Stat InitStat() {
        currentValue = startValue;
        maxValue = startValue;
        return this;
    }
}