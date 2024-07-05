using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _value;

    public event Action<float, float> ValueChanged;
    public event Action Died;

    public float Value
    {
        get
        {
            return _value;
        }
        private set
        {
            _value = Mathf.Clamp(value, 0, _maxValue);
        }
    }

    private void Start()
    {
        _value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage can't be negative");
        }

        Value -= damage;
        ValueChanged?.Invoke(Value, _maxValue);

        if (Value == 0)
        {
            Died?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Healing amount can't be negative");
        }

        Value += amount;
        ValueChanged?.Invoke(Value, _maxValue);
    }
}
