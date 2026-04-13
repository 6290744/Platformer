using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectable
{
    public event Action<ICollectable> Collected;


    public void Collect()
    {
        Collected?.Invoke(this);
    }
}

