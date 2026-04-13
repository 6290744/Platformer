using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private EnemyMover _mover;

    Direction _direction;
    
    private void Update()
    {
        if (_mover.IsMoving)
        {
            switch (_mover.CurrentDirection)
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
