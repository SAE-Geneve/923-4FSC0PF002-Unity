using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectManager : MonoBehaviour
{

    public int CollectedCount = 0;
    
    // private List<Collectable> _collected;
    private List<Collectable> _collectables;
    
    // Start is called before the first frame update
    void Start()
    {
        _collectables = GetComponentsInChildren<Collectable>().ToList();
        foreach (var collectable in _collectables)
        {
            collectable.IsCollected += Collect;
            collectable.gameObject.SetActive(true);
        }
        CollectedCount = 0;
    }

    private void Collect(Collectable obj)
    {
        if (_collectables.Contains(obj))
        {
            CollectedCount++;
            
            obj.IsCollected -= Collect;
            _collectables.Remove(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
