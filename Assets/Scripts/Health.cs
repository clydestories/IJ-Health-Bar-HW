using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _value;

    [SerializeField] private float _maxValue;

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

    public float MaxValue => _maxValue;

    public event Action<float> ValueChanged;

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
        ValueChanged?.Invoke(Value);

        if (Value == 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Healing amount can't be negative");
        }

        Value += amount;
        ValueChanged?.Invoke(Value);
    }

    private void Die()
    {

    }
}
