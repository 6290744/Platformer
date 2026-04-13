using TMPro;
using UnityEngine;

public class ValueViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    
    private ICounter _counter;

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.ValueChanged += OnValueChanged;
            OnValueChanged(_counter.Value);
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.ValueChanged -= OnValueChanged;
        }
    }

    public void Initialize(ICounter counter)
    {
        if (_counter != null)
        {
            _counter.ValueChanged -= OnValueChanged;
        }
        
        _counter = counter;

        if (isActiveAndEnabled)
        {
            _counter.ValueChanged += OnValueChanged;
            OnValueChanged(_counter.Value);
        }
    }
    
    private void OnValueChanged(int value)
    {
        _counterText.text = value.ToString();
    }
}
