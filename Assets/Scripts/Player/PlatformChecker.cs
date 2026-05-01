using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private float _overlapGroundCheckRadius = 0.1f;
    
    public bool IsTouchedPlatformBy(Transform checker)
    {
        Collider2D collider = Physics2D.OverlapCircle(checker.position, _overlapGroundCheckRadius);
        
        return collider && collider.gameObject.TryGetComponent(out Platform _);
    }
}
