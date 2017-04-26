using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour {

    public Collider finishLine;
    public Transform canvas;
    public Transform canvas2;
    public Transform canvas3;
    
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider end)
    {
        if(end.gameObject.name == "Player1")
        {
            Debug.Log("Player 1 has won the race");
            DisplayFinishScreen();
            Time.timeScale = 0;
          
        }
        else if(end.gameObject.name == "Player2")
        {
            Debug.Log("Player2 has won the race");
            DisplayFinishScreen2();
            Time.timeScale = 0;
        }
        else if (end.gameObject.name == "Player3")
        {
            Debug.Log("The Bot Has won you noobs");
            DisplayFinishScreen3();
            Time.timeScale = 0;
        }
       
    }

    private void DisplayFinishScreen()
    {
        canvas.gameObject.SetActive(true);
    }


    private void DisplayFinishScreen2()
    {
        canvas2.gameObject.SetActive(true);
    }

    private void DisplayFinishScreen3()
    {
        canvas3.gameObject.SetActive(true);
    }

}
