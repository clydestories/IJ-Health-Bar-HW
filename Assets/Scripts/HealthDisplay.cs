using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= SetValue;
    }

    protected abstract void SetValue(float value, float maxValue);
}
