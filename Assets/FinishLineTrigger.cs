using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour {

    public GameObject player1, player2;
    
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider end)
    {
        if(player1)
        {
            Debug.Log("Player 1 has won the race");
        }
        else
        {
            Debug.Log("Player2 has won the race");
        }
       
    }

}
