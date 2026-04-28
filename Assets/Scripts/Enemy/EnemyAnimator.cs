using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Patroller _patroller;

    private Direction _direction;
    
    private void Update()
    {
        if (_patroller.IsMoving)
        {
            switch (_patroller.CurrentDirection)
            {
                case Direction.Right:
                    _spriteRenderer.flipX = true;
                    break;
                case Direction.Left:
                    _spriteRenderer.flipX = false;
                    break;
            }
        }
    }
}
