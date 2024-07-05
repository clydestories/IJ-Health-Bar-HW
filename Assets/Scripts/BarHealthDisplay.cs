using UnityEngine;
using UnityEngine.UI;

public class BarHealthDisplay : HealthDisplay
{
    [SerializeField] private Slider _slider;

    protected override void SetValue(float value)
    {
        _slider.value = value / Health.MaxValue;
    }
}
