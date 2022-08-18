
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Player
{
    
    public SpriteRenderer sprtRenderer;
    public Health player;
    public Sprite[] sprites;
    
    void Update()
    {
        HandleHpBar();
    }

    void HandleHpBar()
    {
        switch (player.Health)
        {
            case 5:
                sprtRenderer.sprite = sprites[0];
                break;
            case 4:
                sprtRenderer.sprite = sprites[1];
                break;
            case 3:
                sprtRenderer.sprite = sprites[2];
                break;
            case 2:
                sprtRenderer.sprite = sprites[3];
                break;
            case 1:
                sprtRenderer.sprite = sprites[4];
                break;
            case 0:
                sprtRenderer.sprite = sprites[5];
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
