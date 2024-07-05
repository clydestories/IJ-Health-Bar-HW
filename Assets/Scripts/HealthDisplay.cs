using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= SetValue;
    }

    protected abstract void SetValue(float value);
}
