using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField]
    private bool _upsideDown;
    public bool UpsideDown => _upsideDown;

    private Rigidbody2D _rb;
    private Vector2 _gravityBase;

    // Start is called before the first frame update
    void Start()
    {
        _gravityBase = Physics2D.gravity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.gravity = _gravityBase * (_upsideDown ? -1 : 1);
    }
}
