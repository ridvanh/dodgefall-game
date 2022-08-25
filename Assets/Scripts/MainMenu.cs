using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }

    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
