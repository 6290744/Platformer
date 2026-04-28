using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public void PlayRunningAnimation()
    {
        _animator.SetBool("Run", true);
    }

    public void StopRunningAnimation()
    {
        _animator.SetBool("Run", false);
    }
    
    public void PlayJumpAnimation()
    {
        _animator.SetBool("Jump", true);
    }

    public void StopJumpAnimation()
    {
        _animator.SetBool("Jump", false);
        
        //PlayRunningAnimation();
    }
}