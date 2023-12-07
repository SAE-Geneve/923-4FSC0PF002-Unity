using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private bool _groundedCheck = false;

    private Rigidbody2D _rb;
    private GroundedDetector _groundedDetector;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundedDetector = GetComponentInChildren<GroundedDetector>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Jump
        Debug.Log("Jump Input : " + Input.GetAxis("Jump") + " : " + Time.deltaTime);
        if (_groundedCheck == false || (_groundedCheck == true && _groundedDetector.IsGrounded))
        {
            if (Input.GetAxis("Jump") >= Mathf.Epsilon)
            {
                _rb.velocityY = _jumpForce * Time.deltaTime;
            }
            else
            {
                // Left Right Movement
                _rb.velocityX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;

                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                {
                    _animator.SetBool("IsWalking", true);
                }
                else
                {
                    _animator.SetBool("IsWalking", false);
                }
            }
        }
        
        if (_rb.velocityX > Mathf.Epsilon)
            _spriteRenderer.flipX = false;
        else if (_rb.velocityX < -1 * Mathf.Epsilon)
            _spriteRenderer.flipX = true;

    }
}
