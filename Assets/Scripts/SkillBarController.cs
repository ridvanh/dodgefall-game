using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{
    
    public Image cooldownImage;
    public float cooldown = 3;
    public Text readyText;
    private bool isOnCooldown;
    void Update()
    {
        HandleShieldSkill();
    }

    void HandleShieldSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            readyText.gameObject.SetActive(false);
            isOnCooldown = true;
        }

        if (isOnCooldown)
        {
            cooldownImage.fillAmount += 1 / cooldown * Time.deltaTime;

            if (cooldownImage.fillAmount >= 1)
            {
                readyText.gameObject.SetActive(true);
                cooldownImage.fillAmount = 0;
                isOnCooldown = false;
            }
        }
    }
}
