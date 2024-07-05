using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothedBarHealthDisplay : BarHealthDisplay
{
    [SerializeField] private float _step; 
    [SerializeField] private float _delay; 

    private Coroutine _coroutine;

    protected override void SetValue(float value, float maxValue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothenValue(value / maxValue));
    }

    private IEnumerator SmoothenValue(float value)
    {
        var wait = new WaitForSeconds(_delay);

        while (Slider.value != value)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, value, _step);
            yield return wait;
        }

        _coroutine = null;
    }
}
