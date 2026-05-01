using UnityEngine;
using System;
using System.Collections;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private PlatformChecker _platformChecker;
    [SerializeField] private Transform _landCheck;
    [SerializeField] private float _jumpStrength = 7f;

    private Rigidbody2D _rigidbody;
    private KeyCode _jump = KeyCode.Space;
    private bool _isLanded;

    public event Action Jumped;
    public event Action Landed;

    public bool IsLanded => _isLanded;

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
            Jumped?.Invoke();
            
            _rigidbody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);

            StartCoroutine(WaitForLanding());
        }
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => _isLanded == false);
        yield return new WaitUntil(() => _isLanded == true);

        Landed?.Invoke();
    }
}