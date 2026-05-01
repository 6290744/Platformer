using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _runId;
    private int _jumpId;

    private void Start()
    {
       _runId = Animator.StringToHash("Run");
       _jumpId = Animator.StringToHash("Jump");
    }
    
    public void PlayRunningAnimation()
    {
        _animator.SetBool(_runId, true);
    }

    public void StopRunningAnimation()
    {
        _animator.SetBool(_runId, false);
    }
    
    public void PlayJumpAnimation()
    {
        _animator.SetBool(_jumpId, true);
    }

    public void StopJumpAnimation()
    {
        _animator.SetBool(_jumpId, false);
        
        PlayRunningAnimation();
    }
}