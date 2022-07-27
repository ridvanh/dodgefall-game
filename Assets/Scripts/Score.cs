using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public GameOverScreen goScreen;
    private void Start()
    {
        score.text = 0.ToString();
    }

    void Update()
    {
        score.text = Time.timeSinceLevelLoad.ToString("0");
    }
}