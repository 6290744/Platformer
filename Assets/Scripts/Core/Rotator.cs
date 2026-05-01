using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void Rotate()
    {
        transform.Rotate(Vector3.up, 180f, Space.World);
    }
}
