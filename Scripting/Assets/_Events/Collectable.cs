using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public Action<Collectable> IsCollected;

    private void OnMouseDown()
    {
        IsCollected(this);
        gameObject.SetActive(false);
    }

}
