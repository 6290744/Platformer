using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Move()
    {
        SetupMoving(true);
    }

    public void Stop()
    {
        SetupMoving(false);
    }

    private void SetupMoving(bool isMoving)
    {
        _animator.SetBool(EnemyAnimatorData.Params.Go, isMoving);
    }
}
