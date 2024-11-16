using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeBetween;

    public event Action<int> CounterChanged;
    
    private int _counter;
    private Coroutine _coroutine;
    private bool _isCounterRunning;

    private void OnEnable()
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
            CounterChanged?.Invoke(_counter);
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
}
