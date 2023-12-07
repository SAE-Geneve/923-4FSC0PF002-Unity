using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;

        if (x > Mathf.Epsilon)
        {
            _spriteRenderer.flipX = false;
        }
        else if (x < -1 * Mathf.Epsilon)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            //Debug.Log("No move !");
        }
        
        transform.Translate(x, 0, 0);

    }
}
