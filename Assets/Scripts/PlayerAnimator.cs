using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _playerMover.Running += OnPlayerRunning;
        _playerMover.Jumped += OnPlayerJumped;
        _playerMover.Stopped += OnPlayerStopped;
        _playerMover.Landed += OnPlayerLanded;
    }

    private void OnDisable()
    {
        _playerMover.Running -= OnPlayerRunning;
        _playerMover.Jumped -= OnPlayerJumped;
        _playerMover.Stopped -= OnPlayerStopped;
        _playerMover.Landed -= OnPlayerLanded;
    }

    private void OnPlayerJumped()
    {
        _animator.SetBool("Jump", true);
    }

    private void OnPlayerRunning()
    {
        switch (_playerMover.CurrentDirection)
        {
            case Direction.Left:
                _spriteRenderer.flipX = true;
                break;
            case Direction.Right:
                _spriteRenderer.flipX = false;
                break;
        }

        if (_playerMover.IsLanded)
        {
            _animator.SetBool("Run", true);
        }
    }

    private void OnPlayerStopped()
    {
        _animator.SetBool("Run", false);
    }

    private void OnPlayerLanded()
    {
        _animator.SetBool("Jump", false);

        if (_playerMover.CurrentDirection != Direction.None)
        {
            OnPlayerRunning();
        }
    }
}