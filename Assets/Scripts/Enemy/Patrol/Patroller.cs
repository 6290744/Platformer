using UnityEngine;
using System;
using System.Collections;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;
    
    private Vector2 _destinationPoint;
    private WaitForSeconds _waitForSeconds;
    private int _secondsToWait = 2;
    private int _currentDestinationPointIndex;
    private float _minimalDistanceToChangeWaypoint = 0.01f;
    private bool _isPatrolling;

    public Action<Direction> Moving;
    public Action Stopped;
    
    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_secondsToWait);
        
        _isPatrolling = true;

        _destinationPoint = NextPoint();
    }

    private void FixedUpdate()
    {
        if (_isPatrolling)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destinationPoint, _speed * Time.deltaTime);
            
            if (IsReached(_destinationPoint))
            {
                StartCoroutine(SetNextPoint());
            }
        }
    }
    
    private Vector2 NextPoint()
    {
        _currentDestinationPointIndex = (_currentDestinationPointIndex + 1) % _waypoints.Length;
        
        Vector2 nextDestinationPoint = _waypoints[_currentDestinationPointIndex].transform.position;
        
        NotifyMovingTo(nextDestinationPoint);
            
        return nextDestinationPoint;
    }

    private IEnumerator SetNextPoint()
    {
        _isPatrolling = false;
        
        NotifyStopped();
        
        yield return _waitForSeconds;
        
        _destinationPoint = NextPoint();
        
        _isPatrolling = true;
    }

    private bool IsReached(Vector2 destinationPoint)
    {
        Vector2 offset = (Vector2)transform.position - destinationPoint;

        return offset.sqrMagnitude <= _minimalDistanceToChangeWaypoint * _minimalDistanceToChangeWaypoint;
    }

    private void NotifyMovingTo(Vector2 destinationPoint)
    {
        Moving?.Invoke(transform.position.x < destinationPoint.x ? Direction.Left : Direction.Right);
    }

    private void NotifyStopped()
    {
        Stopped?.Invoke();
    }
}