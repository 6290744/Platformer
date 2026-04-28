public class PlayerMediator
{
    private PlayerInputReader _inputReader;
    private PlayerMover _playerMover;
    private PlayerJumper _playerJumper;
    private PlayerAnimator _playerAnimator;

    public void Initialize(PlayerInputReader inputReader, PlayerAnimator playerAnimator, PlayerMover playerMover,
        PlayerJumper playerJumper)
    {
        _inputReader = inputReader;
        _playerMover = playerMover;
        _playerAnimator = playerAnimator;
        _playerJumper = playerJumper;

        _inputReader.MoveInput += OnMoveInput;
        _inputReader.JumpInput += OnJumpInput;
        _playerMover.Running += OnRunning;
        _playerMover.Stopped += OnStopped;
        _playerJumper.Jumped += OnJumped;
        _playerJumper.Landed += OnLanded;
    }

    private void OnMoveInput(Direction direction)
    {
        _playerMover.Move(direction);
    }

    private void OnJumpInput()
    {
        _playerJumper.Jump();
    }

    private void OnRunning()
    {
        _playerAnimator.PlayRunningAnimation();
    }

    private void OnStopped()
    {
        _playerAnimator.StopRunningAnimation();
    }

    private void OnJumped()
    {
        _playerAnimator.PlayJumpAnimation();
    }

    private void OnLanded()
    {
        _playerAnimator.StopJumpAnimation();
    }

    public void Dispose()
    {
        if (_inputReader != null)
        {
            _inputReader.MoveInput -= OnMoveInput;
            _inputReader.JumpInput -= OnJumpInput;
        }

        if (_playerMover != null)
        {
            _playerMover.Running -= OnRunning;
            _playerMover.Stopped += OnStopped;
        }

        if (_playerJumper != null)
        {
            _playerJumper.Jumped -= OnJumped;
            _playerJumper.Landed -= OnLanded;
        }
    }
}