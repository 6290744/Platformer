using UnityEngine;
using System;

public class CoinsCounter : MonoBehaviour, ICounter
{
    private int _count;

    public event Action<int> ValueChanged;
    
    public int Value => _count;
    
    public void Add(ICollectable _)
    {
        _count++;
        
        ValueChanged?.Invoke(_count);
    }
}
