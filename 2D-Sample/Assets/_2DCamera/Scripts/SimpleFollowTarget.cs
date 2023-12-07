using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowTarget : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);
    [SerializeField] private Vector3 _confineSize = new Vector3(1,1, -10);
    [SerializeField] private float _moveMargin = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 viewportPoint = Camera.main.WorldToViewportPoint(_target.position);
        // Debug.Log("Viewport coordinates : " + viewportPoint);
        //
        // Vector3 screenPoint = Camera.main.WorldToScreenPoint(_target.position);
        // Debug.Log("Screen coordinates : " + screenPoint);

        if (IsLevelConfined())
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, 0.1f);
        }
        
        // Smooth damp approach
        /*
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            _target.position + _offset,
            ref velocity,
            0.05f
        );
        */

    }

    private bool IsLevelConfined()
    {
        var colliders2DArray = Physics2D.OverlapBoxAll(transform.position, _confineSize, 0);

        foreach (var collider in colliders2DArray)
        {
            Debug.Log("collider ? " + collider);
            if (collider.CompareTag("Level"))
            {
                return true;
            }
        }
        
        return false;
    }
    
}
