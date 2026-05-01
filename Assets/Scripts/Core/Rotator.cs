using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void RotateTo(Direction direction)
    {
        if (direction == Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }
}
