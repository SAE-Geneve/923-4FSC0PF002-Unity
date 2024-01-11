using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _jumpForce = 25f;

    private CharacterController _controller;
    private ShootingSystem _shootingSystem;
    
    private Vector2 moveInputValue;
    private float jumpVelocity;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _shootingSystem = GetComponent<ShootingSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        float gravityForce = 9.87f;

        // Horizontal movement
        Vector3 velocity = _controller.velocity;
        velocity = transform.forward * (moveInputValue.y * _speed);

        // Jump
        Debug.Log("Is grounded  ? : " + _controller.isGrounded);
        velocity.y += jumpVelocity;
        velocity.y -= gravityForce;

        _controller.Move(velocity * Time.deltaTime);

        transform.Rotate(Vector3.up * (moveInputValue.x * _rotateSpeed * Time.deltaTime));

    }

    // Called from InputSystem:SendMessages
    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log("OnMove message : " + moveInputValue.ToString());
    }

    void OnJump(InputValue value)
    {
        Debug.Log("OnJump message : " + value.ToString());

        if (value.isPressed && _controller.isGrounded)
        {
            Debug.Log("Jump on (pressed)");
            jumpVelocity = _jumpForce;
        }
        if (!value.isPressed)
        {
            Debug.Log("Jump off (released)");
            jumpVelocity = 0;
        }

    }

    void OnShoot(InputValue value)
    {
        if (value.isPressed)
            _shootingSystem.StartShooting();
        
        if(!value.isPressed)
            _shootingSystem.StopShooting();
    }
}
