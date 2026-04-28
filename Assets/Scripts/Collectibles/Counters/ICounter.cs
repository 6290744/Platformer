using System;

public interface ICounter
{
    public event Action<int> ValueChanged;
    
    public int Value { get; }
    
    public void Add(ICollectable item);
}
