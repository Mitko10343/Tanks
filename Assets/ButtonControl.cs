using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour {

   

    void Start()
    {
       
        
    }

	public void PlayBtn(int a)
    {
        Application.LoadLevel(a);
    }

    public void Settings(int a)
    {
        Application.LoadLevel(a);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void loadMenu(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void loadSettings(int a)
    {
        Application.LoadLevel(a);
    }
}
