using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float damage = 1f)
    {
        _hp -= damage;
        if (_hp <= 0f)
            Destroy(gameObject);

    }
}
