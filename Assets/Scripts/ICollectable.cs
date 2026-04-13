using System;

public interface ICollectable
{
    public event Action<ICollectable> Collected;
    
    public void Collect();
}
