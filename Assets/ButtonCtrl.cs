using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour {
    
    public void NewGameBtn(string newGameLevel)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void RaceMode(string GameMode)
    {
        SceneManager.LoadScene(GameMode);
    }

    public void PvPMode(string GameMode)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(GameMode);
    }

    public void BackBtn(string PrevGameLevel)
    {
        SceneManager.LoadScene(PrevGameLevel);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Exit(string level)
    {
        Application.LoadLevel(level);
    }
}
