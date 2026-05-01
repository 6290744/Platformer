using UnityEngine;

public class EnemyMovementMediator : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Rotator _rotator;

    public void OnEnable()
    {
        _patroller.Moving += OnMoving;
        _patroller.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _patroller.Moving -= OnMoving;
        _patroller.Stopped -= OnStopped;
    }
    
    private void OnMoving(Direction direction)
    {
        _rotator.RotateTo(direction);
        _animator.Move();
    }
    
    private void OnStopped()
    {
        _animator.Stop();
    }
}
