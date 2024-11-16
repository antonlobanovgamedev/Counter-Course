using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeBetween;

    private int _counter;
    private Coroutine _coroutine;
    private bool _isCounterRunning;

    private void Start()
    {
        StartCounter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_isCounterRunning)
                StopCounter();
            else
                StartCounter();
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (_isCounterRunning)
        {
            yield return new WaitForSeconds(_timeBetween);

            IncreaseCounter();
            PrintCounter();
        }
    }

    private void StartCounter()
    {
        _isCounterRunning = true;
        _coroutine = StartCoroutine(CounterCoroutine());
    }

    private void StopCounter()
    {
        _isCounterRunning = false;
        StopCoroutine(_coroutine);
    }
    
    private void IncreaseCounter()
    {
        _counter++;
    }
    
    private void PrintCounter()
    {
        _text.text = _counter.ToString();
    }
}
