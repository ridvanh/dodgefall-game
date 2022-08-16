using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public GameOverScreen goScreen;
    public int Highscore;

    private void Awake()
    {
        Highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void Start()
    {
        score.text = 0.ToString();
    }

    void Update()
    {
        score.text = Time.timeSinceLevelLoad.ToString("0");
    }
}