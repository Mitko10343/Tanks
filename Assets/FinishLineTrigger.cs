using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour {

    public Collider finishLine;
    public Transform canvas;
    
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
            DisplayFinishScreen();
            Time.timeScale = 0;
        }
        /*else 
        {
            Debug.Log("The Bot Has won you noobs");
            DisplayFinishScreen();
            Time.timeScale = 0;
        }
       */
    }

    private void DisplayFinishScreen()
    {
        canvas.gameObject.SetActive(true);
    }

}
