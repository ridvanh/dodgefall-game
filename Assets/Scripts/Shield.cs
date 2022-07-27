using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);
        }
    }
}
