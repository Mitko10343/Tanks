﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public float m_DampTime = 0.2f;
    public float m_ScreenEdgeBuffer = 4f;
    public float m_MinSize = 6.5f;
    public Transform[] m_Targets;

    private Camera m_Camera;
    private float m_ZoomSpeed;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Fixedupdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    //Function to find the average position between the tanks so we know how far
    //the camera should expand or retract
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;//this variable will tell us how much tanks there are 

        //itterate through the array of the tanks and check how much tanks are actually active
        for(int i=0; i<m_Targets.Length; i++)
        {
            //If tank is not active then continue to the next itteration
            if (!m_Targets[i].gameObject.activeSelf)
            {
                continue;
            }

            //Add the position of each  active tank to average variabke
            averagePos += m_Targets[i].position;
            //increment the value of active tanks
            numTargets++;
        }
        //Then divide the value of average  by the number of targets to see 
        //the actual average position between the tanks
        if (numTargets > 0)
        {
            averagePos /= numTargets;
        }

        
        averagePos.y = transform.position.y;
        m_DesiredPosition = averagePos;
    }


}
