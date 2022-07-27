using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{
    
    public Image cooldownImage;
    public float cooldown = 3;
    private bool isOnCooldown;
    void Update()
    {
        HandleShieldSkill();
    }

    void HandleShieldSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOnCooldown = true;
        }

        if (isOnCooldown)
        {
            cooldownImage.fillAmount += 1 / cooldown * Time.deltaTime;

            if (cooldownImage.fillAmount >= 1)
            {
                cooldownImage.fillAmount = 0;
                isOnCooldown = false;
            }
        }
    }
}
