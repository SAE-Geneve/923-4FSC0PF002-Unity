using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    
    private Rigidbody2D _rb;
    private GroundedDetector _groundedDetector;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundedDetector = GetComponentInChildren<GroundedDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left Right Movement
        _rb.velocityX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        // Jump
        if (Input.GetAxis("Jump") >= Mathf.Epsilon && _groundedDetector._isGrounded == true)
        {
            _rb.velocityY = Input.GetAxis("Jump") * _jumpForce * Time.deltaTime;
        }   
        
    }
}
