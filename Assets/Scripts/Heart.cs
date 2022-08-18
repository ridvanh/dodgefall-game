using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float fallingSpeed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, 7.5f);
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(0, -fallingSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Fall Detector")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Platform")
        {
            fallingSpeed = 0;
        }
    }
}
