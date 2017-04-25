using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public Transform canvas;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }


    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadLevel(string Level)
    {
        Application.LoadLevel(Level);
    }

    public void Unpause()
    {
        if(Time.timeScale == 0)
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if(Time.timeScale == 1)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
