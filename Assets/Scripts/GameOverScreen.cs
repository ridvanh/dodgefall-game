using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public bool isRestarted = false;
    public Score scoreText;
    public Text points;
    public void Setup()
    {
        gameObject.SetActive(true);
        points.text = "Score: " + scoreText.score.text;
        int playerScore = int.Parse(scoreText.score.text);
        if (playerScore < scoreText.Highscore)
        {
            GameObject.Find("newHighscoreText").SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", playerScore);
        }
    }
    
    public void Restart()
    {
        isRestarted = true;
        SceneManager.LoadScene("Play");
        isRestarted = false;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
