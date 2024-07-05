using UnityEngine;
using UnityEngine.UI;

public class BarHealthDisplay : HealthDisplay
{
    [SerializeField] protected Slider Slider;

    protected override void SetValue(float value, float maxValue)
    {
        Slider.value = value / maxValue;
    }
}
