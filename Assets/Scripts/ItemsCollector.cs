using UnityEngine;
using System;

public class ItemsCollector : MonoBehaviour
{
    public event Action<ICollectable> Collected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollectable item))
        {
            Debug.Log("Собрал");
            
            item.Collect();
            
            Collected?.Invoke(item);
        }
    }
}
