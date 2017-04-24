using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAi : MonoBehaviour {

    //An array of waypoints for the Ai to follow
    public GameObject[] waypoints;
    public float minDistance = 1f;

    public float Acceleration = 0.2f;
    public float maxSpeed=25;
    public float BreakForce = 0.4f;

    //public float MaxTurnAngle = 76f;
    public float TurnSpeed = 65;

    //currentWaypoint
    private float currentAngleAI;
    private float AngleToTurn;
    public int current=0;
    private bool go = true; //boolean variable to check if the Ai should be moving
    private float Speed = 0;
    private float currentTurnAngle = 0;


	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[current].transform.position); //distance between waypoint and player
 
        if(go)
        {
            if(dist > minDistance)
            {
                Move();
                
            }
            else
            {
                if (current + 1 != waypoints.Length)
                {
                    current++;
                }
                else
                {
                    Debug.Log("Ai has reached the finish line");
                    go = false;
                }
            }
           
        }
	}

    public void Move()
    {



        if (Speed < maxSpeed)
        {
            Speed += Acceleration;
            gameObject.transform.LookAt(waypoints[current].transform.position);
            gameObject.transform.position += gameObject.transform.forward * Speed * Time.deltaTime;
        }
        if (Speed >= maxSpeed)
        {
            gameObject.transform.LookAt(waypoints[current].transform.position);
            gameObject.transform.position += gameObject.transform.forward * Speed * Time.deltaTime;
        }
        
    }
}
