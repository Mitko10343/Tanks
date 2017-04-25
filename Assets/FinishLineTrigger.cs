using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour {

    public GameObject player1, player2;
    public Transform canvas;
    
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider end)
    {
        if(player1 == end.gameObject)
        {
            Debug.Log("Player 1 has won the race");
            DisplayFinishScreen();
            Time.timeScale = 0;
          
        }
        else if(player2 == end.gameObject)
        {
            Debug.Log("Player2 has won the race");
            DisplayFinishScreen();
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("The Bot Has won you noobs");
            DisplayFinishScreen();
            Time.timeScale = 0;
        }
       
    }

    private void DisplayFinishScreen()
    {
        canvas.gameObject.SetActive(true);
    }

}
