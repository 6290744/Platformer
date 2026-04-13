using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _landCheck;
    [SerializeField] private Transform _leftWallCheck;
    [SerializeField] private Transform _rightWallCheck;
    [SerializeField] private float _jumpStrength = 7f;
    [SerializeField] private float _speed = 200f;

    private Rigidbody2D _rigidbody;
    private float _overlapGroundCheckRadius = 0.1f;
    private Direction _currentDirection;

    private bool _isLanded;

    public event Action Running;
    public event Action Stopped;
    public event Action Jumped;
    public event Action Landed;

    public Direction CurrentDirection => _currentDirection;
    public bool IsLanded => _isLanded;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isLanded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isLanded)
        {
            Jump();

            Jumped?.Invoke();
        }

        if (Input.GetKey(KeyCode.D) && IsTouchedPlatformBy(_rightWallCheck) == false)
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.A) && IsTouchedPlatformBy(_leftWallCheck) == false)
        {
            Move(Direction.Left);
        }
        else
        {
            Move(Direction.None);
        }
    }

    private void FixedUpdate()
    {
        _isLanded = IsTouchedPlatformBy(_landCheck);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);

        StartCoroutine(WaitForLanding());
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
        }
    }

    private bool IsTouchedPlatformBy(Transform checker)
    {
        Collider2D collider = Physics2D.OverlapCircle(checker.position, _overlapGroundCheckRadius);

        if (collider && collider.gameObject.TryGetComponent(out Platform _))
        {
            return true;
        }

        return false;
    }
    
    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => _isLanded == false);
        yield return new WaitUntil(() => _isLanded == true);
        
        Debug.Log("IsLanded: " + _isLanded);
    
        Landed?.Invoke();
    }
}