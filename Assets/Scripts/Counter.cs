using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    
    private int _count;
    private Coroutine _coroutine;
    
    public event Action<int> CountChanged;

    private void OnEnable()
    {
        StartCount();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_coroutine != null)
                StopCount();
            else
                StartCount();
        }
    }

    private IEnumerator CountCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        
        while (true)
        {
            yield return wait;

            IncreaseCount();
            CountChanged?.Invoke(_count);
        }
    }

    private void StartCount()
    {
        _coroutine = StartCoroutine(CountCoroutine());
    }

    private void StopCount()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }
    
    private void IncreaseCount()
    {
        _count++;
    }
}
