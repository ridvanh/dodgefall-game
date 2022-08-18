using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public Platform startingPlatform;
    public int platformNumber;
    
    public GameObject spawnObject;
    public GameObject fallingObject;
    public GameObject fallingHeart;

    public Player player;
    
    public float delayTime;

    public Camera cam;
    
    void Start()
    {
        Debug.Log("Pixel width :" + cam.pixelWidth + " Pixel height : " + cam.pixelHeight);
        SpawnPlatforms();
        StartCoroutine("FireballRoutine", delayTime);
        StartCoroutine("HomingRoutine", 0.75f);
        StartCoroutine("HeartRoutine", 1f);
    }
    
    void SpawnPlatforms()
    {

        float xPosition = startingPlatform.rightEndPoint.position.x + 1.5f;
        
        for (int i = 0; i < platformNumber; i++)
        {
            float yPosition = Random.Range(-3f, 0f);
            
            GameObject a = Instantiate(spawnObject, new Vector3(xPosition , yPosition), Quaternion.identity);
            GameObject b = Instantiate(spawnObject, new Vector3(-xPosition , yPosition), Quaternion.identity);
            
            xPosition = a.GetComponent<Platform>().rightEndPoint.position.x + 1.5f;
        }
        
    }

    void SpawnFireballs()
    {
            float xPos = Random.Range(-13f, 13f);
            float yPos = 6.5f;

            GameObject fireball = Instantiate(fallingObject, new Vector3(xPos, yPos), Quaternion.identity);
    }

    IEnumerator FireballRoutine(float time)
    {
        while (player.GetComponent<MovementController>().Health > 0)
        {
            yield return new WaitForSeconds(time);
        
            SpawnFireballs();
        }
    }
    
    IEnumerator HomingRoutine(float time)
    {
        while (player.GetComponent<MovementController>().Health > 0)
        {
            yield return new WaitForSeconds(time);
            
            HomingFireballs();
        }
    }

    void HomingFireballs()
    {
        float xPos = player.transform.position.x;
        float yPos = 6.5f;
        
        GameObject fireball = Instantiate(fallingObject, new Vector3(xPos, yPos), Quaternion.identity);
    }

    IEnumerator HeartRoutine(float time)
    {
        while (player.GetComponent<MovementController>().Health > 0)
        {
            yield return new WaitForSeconds(time);

            var randomizer = Random.Range(1, 5);
            if (randomizer == 1)
            {
                SpawnHeart();
                yield return new WaitForSeconds(10);
            }
        }
    }

    void SpawnHeart()
    {
        float xPos = Random.Range(-13f, 13f);
        float yPos = 6.5f;
        
        GameObject heart = Instantiate(fallingHeart, new Vector3(xPos, yPos), Quaternion.identity);
    }

    
}
