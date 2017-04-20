using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour {

	
    void OnTriggerEnter(Collider end)
    {
        SceneManager.LoadScene("Menu");
    }

}
