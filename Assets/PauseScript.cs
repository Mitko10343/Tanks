using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public GameObject[] guiObjects;

    public bool pause = false;

    public void Start()
    {
        Time.timeScale = 1;
        guiObjects = GameObject.FindGameObjectsWithTag("Paused");
    }
    public void update()
    {
        if (Input.GetKeyDown("p") && pause == false)
        {
            if (Time.timeScale == 0)
            {
                foreach(GameObject g in guiObjects)
                {
                    g.SetActive(true);
                }
            }
            else if(Time.timeScale == 1)
            {
                foreach (GameObject g in guiObjects)
                {
                    g.SetActive(false);
                }

            }
        }
    }
}
