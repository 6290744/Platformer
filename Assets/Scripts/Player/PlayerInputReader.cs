using UnityEngine;
using System;

public class PlayerInputReader : MonoBehaviour
{
    private KeyCode _right = KeyCode.D;
    private KeyCode _left =  KeyCode.A;
    private KeyCode _jump = KeyCode.Space;
    
    public event Action<Direction> MoveInput;
    public event Action JumpInput;
    
    private void Update()
    {
        if (Input.GetKey(_right))
        {
            MoveInput?.Invoke(Direction.Right);
        }
        else if (Input.GetKey(_left))
        {
            MoveInput?.Invoke(Direction.Left);
        }
        
        if (Input.GetKey(_jump))
        {
            JumpInput?.Invoke();
        }
    }
}
