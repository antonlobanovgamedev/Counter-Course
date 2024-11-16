using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CountChanged += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayCount;
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }
}
