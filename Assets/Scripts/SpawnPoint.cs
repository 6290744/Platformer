using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isOccupied;
    
    public bool IsOccupied => _isOccupied;
    public Vector3 Position => transform.position;
    
    public void Occupy(ICollectable item)
    {
        item.Collected += Unoccupy;
        
        _isOccupied = true;
    }

    private void Unoccupy(ICollectable item)
    {
        item.Collected -= Unoccupy;
        
        _isOccupied = false;
    }
}
