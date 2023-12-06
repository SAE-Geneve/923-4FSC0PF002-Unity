using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public CoinManager _coinManager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy(gameObject);
            //gameObject.SetActive(false);
            _coinManager.Collect(this);
        }
    }

}
