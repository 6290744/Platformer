using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;

    private Vector2 _destinationPoint;
    private bool _isMoving;
    private int _currentDestinationPointIndex;
    private Direction _currentDirection;

    private float _minimalDistanceToChangeWaypoint = 0.01f;

    public Direction CurrentDirection => _currentDirection;
    public bool IsMoving => _isMoving;

    private void OnEnable()
    {
        _isMoving = true;

        SetStartPoint();
    }

    private void Update()
    {
        if (_isMoving)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destinationPoint, _speed * Time.deltaTime);

        if (IsDestinationPointReached())
        {
            SetNextDestinationPoint();
        }
    }

    private void SetDestinationPoint(int index)
    {
        _currentDestinationPointIndex = index;

        _destinationPoint = _waypoints[index].transform.position;
        
        SetCurrentDirectionTo(_destinationPoint);
    }

    private void SetNextDestinationPoint()
    {
        SetDestinationPoint((_currentDestinationPointIndex + 1) % _waypoints.Length);
    }

    private void SetStartPoint()
    {
        SetDestinationPoint(Random.Range(0, _waypoints.Length));
    }

    private bool IsDestinationPointReached()
    {
        Vector2 offset = (Vector2)transform.position - _destinationPoint;

        return offset.sqrMagnitude <= _minimalDistanceToChangeWaypoint * _minimalDistanceToChangeWaypoint;
    }

    private void SetCurrentDirectionTo(Vector2 direction)
    {
        if (transform.position.x < direction.x)
        {
            _currentDirection = Direction.Right;
        }
        else if (transform.position.x > direction.x)
        {
            _currentDirection = Direction.Left;
        }
        else
        {
            _currentDirection = Direction.None;
        }
    }
}