using UnityEngine;
using System;
using System.Collections;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private PlatformChecker _platformChecker;
    [SerializeField] private Transform _landCheck;
    [SerializeField] private float _jumpStrength = 2f;

    private Rigidbody2D _rigidbody;
    private bool _isLanded;

    public event Action Jumped;
    public event Action Landed;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isLanded = true;
    }

    private void FixedUpdate()
    {
        _isLanded = _platformChecker.IsTouchedPlatformBy(_landCheck);
    }

    public void Jump()
    {
        if (_isLanded)
        {
            _isLanded = false;
            
            _rigidbody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);

            StartCoroutine(WaitForLanding());
            
            Jumped?.Invoke();
        }
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => _isLanded == false);
        yield return new WaitUntil(() => _isLanded == true);
        
        Landed?.Invoke();
    }
}