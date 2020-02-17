﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
