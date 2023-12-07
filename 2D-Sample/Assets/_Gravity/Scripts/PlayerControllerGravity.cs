using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControllerGravity : MonoBehaviour
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
    void FixedUpdate()
    {
        // Left Right Movement
        _rb.velocityX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        
        // Jump
        Debug.Log("Jump Input : " + Input.GetAxis("Jump") + " : " + Time.deltaTime);
        if (Input.GetAxis("Jump") >= Mathf.Epsilon)
        {
            _rb.velocityY = _jumpForce * Time.deltaTime;
        }   
        
    }
}
