using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject _flame;
    [SerializeField] private GameObject _spot;
    [SerializeField] private float _shotDelay = 0.1f;
    private Coroutine _shootingCoroutine;

    private void Start()
    {
        _flame.SetActive(false);
    }

    public void StartShooting()
    {
        _flame.SetActive(true);
        if(_shootingCoroutine != null)
            StopCoroutine(_shootingCoroutine);
        
        _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        
    }

    public void StopShooting()
    {
        _flame.SetActive(false);
        if (_shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }
    
    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shotDelay);

            Ray ray = new Ray(_flame.transform.position, _flame.transform.forward);
            //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {
                Debug.Log("Hit : " + hitInfo.collider.name);
                if (hitInfo.collider.TryGetComponent(out Target target))
                {
                    // Damages the target
                    target.Damage();
                }
                if (hitInfo.collider.gameObject != _spot)
                {
                    _spot.transform.position = hitInfo.point;
                    _spot.SetActive(true);
                }
                
            }
            else
            {
                _spot.SetActive(false);
                Debug.Log("No hit");
            }
                
            Debug.Log("Shooting");
        }
    }
}
