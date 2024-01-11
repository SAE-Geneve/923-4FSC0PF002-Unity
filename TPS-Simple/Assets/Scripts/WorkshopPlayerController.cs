using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorkshopPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravityScale = 15f;
    [SerializeField] private float _jumpForce = 75f;
    
    private CharacterController _characterController;
    private Animator _animator;

    private Vector2 _inputMovement;
    private bool _inputJump;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 velocity = _inputMovement.x * _moveSpeed * transform.right + _inputMovement.y * _moveSpeed * transform.forward;
        
        velocity.y += (_inputJump && _characterController.isGrounded) ? _jumpForce : 0.0f;
        velocity.y -= _gravityScale; 

        _characterController.Move(velocity * Time.deltaTime);
        
        _animator.SetFloat("Speed", _inputMovement.magnitude * _moveSpeed);
        
    }

    void OnMove(InputValue value)
    {
        Debug.Log("OnMove called : " + value.Get<Vector2>());
        _inputMovement = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        
        //_inputJump = value.Get<float>() > Mathf.Epsilon ? true : false;
        
        if(value.isPressed)
        {
            Debug.Log("Jump pressed : " + _inputJump);
                _inputJump = true;
        }
        
        if(!value.isPressed)
        {
            Debug.Log("Jump released : " + _inputJump);
            _inputJump = false;
        }
        
    }
    
    // public void OnMoveEvent(InputAction.CallbackContext context)
    // {
    //     var value = context.ReadValue<Vector2>();
    //     Debug.Log("OnMove called : " + value);
    // }
    
}
