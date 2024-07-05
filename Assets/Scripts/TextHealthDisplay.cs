using TMPro;
using UnityEngine;

public class TextHealthDisplay : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void SetValue(float value)
    {
        _text.text = value.ToString();
    }
}
