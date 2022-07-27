using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Animator animator;
    private Rigidbody2D rigidBody;
    
    public float fallingSpeed;
    
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(0, -fallingSpeed);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Platform" || other.gameObject.tag == "Fall Detector" || other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
    
}
