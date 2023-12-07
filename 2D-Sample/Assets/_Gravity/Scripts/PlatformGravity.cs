using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGravity : MonoBehaviour
{
    [SerializeField]
    float _deltaFactor = 1f;
    
    private PlayerControllerGravity _player;
    private GravityManager _gravityManager;
    private BoxCollider2D _collider2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<PlayerControllerGravity>();
        _gravityManager = FindFirstObjectByType<GravityManager>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_player.transform.position.y - transform.position.y > _deltaFactor * (_gravityManager.UpsideDown ? -1 : 1))
        {
            _collider2D.enabled = true;
        }
        else
        {
            _collider2D.enabled = false;
        }
        
    }
}
