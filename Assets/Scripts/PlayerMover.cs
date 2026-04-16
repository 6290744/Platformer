using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlatformChecker _platformChecker;
    [SerializeField] private Transform _leftWallCheck;
    [SerializeField] private Transform _rightWallCheck;
    [SerializeField] private float _speed = 200f;

    private Rigidbody2D _rigidbody;
    private Direction _currentDirection;
    private KeyCode _right = KeyCode.D;
    private KeyCode _left =  KeyCode.A;
    
    public event Action Running;
    public event Action Stopped;
   

    public Direction CurrentDirection => _currentDirection;
    

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(_right) && _platformChecker.IsTouchedPlatformBy(_rightWallCheck) == false)
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(_left) && _platformChecker.IsTouchedPlatformBy(_leftWallCheck) == false)
        {
            Move(Direction.Left);
        }
        else
        {
            Move(Direction.None);
        }
    }
    
    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                _rigidbody.linearVelocityX = _speed;
                break;
            case Direction.Left:
                _rigidbody.linearVelocityX = _speed * -1; 
                break;
            case Direction.None:
                _rigidbody.linearVelocityX = 0;
                break;
        }

        SetCurrentDirection(direction);
    }
    
    private void SetCurrentDirection(Direction direction)
    {
        if (_currentDirection == direction)
            return;

        _currentDirection = direction;

        if (_currentDirection != Direction.None)
        {
            Running?.Invoke();
        }
        else
        { 
            Stopped?.Invoke();
        }
    }

    
}