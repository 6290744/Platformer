using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _goId;
    
    private void Start()
    {
        _goId = Animator.StringToHash("Go");

    }

    public void Move()
    {
        _animator.SetBool(_goId, true);
    }

    public void Stop()
    {
        _animator.SetBool(_goId, false);
    }
}
