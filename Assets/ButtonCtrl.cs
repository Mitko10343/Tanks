using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour {
    
    public void NewGameBtn(string newGameLevel)
    {
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
        SceneManager.LoadScene(GameMode);
    }

    public void BackBtn(string PrevGameLevel)
    {
        SceneManager.LoadScene(PrevGameLevel);
    }
}
