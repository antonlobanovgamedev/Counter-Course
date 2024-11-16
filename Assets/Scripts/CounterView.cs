using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CounterChanged += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= DisplayCounter;
    }

    private void DisplayCounter(int counter)
    {
        _text.text = counter.ToString();
    }
}
