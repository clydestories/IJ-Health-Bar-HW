using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothedBarHealthDisplay : HealthDisplay
{
    [SerializeField] private Slider _slider; 
    [SerializeField] private float _step; 
    [SerializeField] private float _delay; 

    private Coroutine _coroutine;

    private IEnumerator SmoothenValue(float value)
    {
        var wait = new WaitForSeconds(_delay);

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _step);
            yield return wait;
        }

        _coroutine = null;
    }

    protected override void SetValue(float value)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(SmoothenValue(value / Health.MaxValue));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(SmoothenValue(value / Health.MaxValue));
        }
    }
}
