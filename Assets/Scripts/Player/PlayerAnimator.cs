using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void PlayRunningAnimation()
    {
        SetupRunningAnimation(true);
    }

    public void StopRunningAnimation()
    {
        SetupRunningAnimation(false);
    }
    
    public void PlayJumpAnimation()
    {
        SetupJumpAnimation(true);
    }

    public void StopJumpAnimation()
    {
        SetupJumpAnimation(false);
        
        PlayRunningAnimation();
    }
    
    private void SetupRunningAnimation(bool isRunning)
    {
        _animator.SetBool(PlayerAnimatorData.Params.Run, isRunning);
    }

    private void SetupJumpAnimation(bool isJumped)
    {
        _animator.SetBool(PlayerAnimatorData.Params.Jump, isJumped);
    }
}