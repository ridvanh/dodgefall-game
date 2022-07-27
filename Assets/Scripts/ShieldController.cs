using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ShieldController : MonoBehaviour
{
    public Animator animator;
    public GameObject shield;
    public float cooldownTime;
    private float nextUsingTime = 0;
    
    void Update()
    {
        HandleShield();
    }
    
    void HandleShield()
    {
        if (Time.time > nextUsingTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("isBlocking");
                GameObject shield2 = GameObject.Instantiate(shield,new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 0.70f), Quaternion.identity, GetComponent<Transform>());
                nextUsingTime = Time.time + cooldownTime;
                StartCoroutine("Duration", 2);
                
            }
        }
    }
    
    IEnumerator Duration(float time)
    {
        yield return new WaitForSeconds(time);
        
        GameObject.Destroy(GameObject.FindWithTag("Shield"));
    }
}
