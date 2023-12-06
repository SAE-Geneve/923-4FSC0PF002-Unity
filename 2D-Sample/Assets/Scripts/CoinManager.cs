using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int NbCoinsCollected => _coinsCollected.Count;
    public int NbCoinsRemaining => _coins.Count;
    
    private List<Coin> _coins;
    private List<Coin> _coinsCollected;
    
    // Start is called before the first frame update
    void Start()
    {
        _coins = GetComponentsInChildren<Coin>(true).ToList();
        _coinsCollected = new List<Coin>();
        
        ActivateCoins();
        
    }

    private void ActivateCoins()
    {
        foreach (Coin c in _coins)
        {
            c.gameObject.SetActive(true);
            c._coinManager = this;
        }
    }

    public void Collect(Coin c)
    {
        _coins.Remove(c);
        c.gameObject.SetActive(false);
        _coinsCollected.Add(c);
    }
}
