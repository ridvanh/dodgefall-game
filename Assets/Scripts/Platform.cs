using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    
    public Transform rightEndPoint;
    
    protected BoxCollider2D boxCollider;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    
}
