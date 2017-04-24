﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public int PlayerNum;
    public float initialSpeed;
    public float Speed;
    public float turnSpeed;
    public float maxSpeed;

    private string MovementAxisName;
    private string TurnAxisName;
    private Rigidbody tank;
    private float MovementInputValue;
    private float TurnInputValue;

    public Vector3 CenterOfMass;
 
    private void Awake()
    {
        tank = GetComponent<Rigidbody>();
        tank.centerOfMass = CenterOfMass;
    }

    private void OnEnable()
    {
        tank.isKinematic = false;
        MovementInputValue = 0f;
        TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        tank.isKinematic = true;
    }

    private void Start()
    {
        MovementAxisName = "Vertical" + PlayerNum;
        TurnAxisName = "Horizontal" + PlayerNum;
    }

    private void Update()
    {
        //Store the player input
        MovementInputValue = Input.GetAxis(MovementAxisName);
        TurnInputValue = Input.GetAxis(TurnAxisName);
    }

    private void FixedUpdate()
    {
        //Move and turn the tank
        Move();
        Turn();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input
        if (Speed <= maxSpeed && MovementInputValue == -1)
        {
            
            if (Speed < (maxSpeed/3))
            {
                Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;
                tank.MovePosition(tank.position + movement);
                Speed += 0.1f;
                tank.drag = 3;
                turnSpeed = 80;
            }
            else if(Speed > (maxSpeed / 3) && Speed <(maxSpeed/1.5))
            {
                Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;
                tank.MovePosition(tank.position + movement);
                Speed += 0.05f;
                tank.drag = 3.5f;
                turnSpeed = 65;
            }
            else if(Speed > (maxSpeed/1.5) && Speed <maxSpeed)
            {
                Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;
                tank.MovePosition(tank.position + movement);
                Speed += 0.02f;
                tank.drag = 4;
                turnSpeed = 55;
            }
            
        }
        else if (Speed >= maxSpeed && MovementInputValue != 0)
        {
            tank.drag = 5;
            Vector3 movement = transform.forward * MovementInputValue * Speed * Time.deltaTime;
            tank.MovePosition(tank.position + movement);
            turnSpeed = 45;
        }


        
        if (MovementInputValue == 0 && Speed > initialSpeed)
        {
            tank.drag = 0.5f ;
            Vector3 movement = transform.forward * -1 * Speed * Time.deltaTime;
            tank.MovePosition(tank.position + movement);
            Speed -= 0.1f;
        }
        else if(MovementInputValue == 0  && Speed <= initialSpeed)
        {
            Speed = initialSpeed -1;
            tank.drag = 0.5f;
        }


        if(MovementInputValue == 1)
        {
            Vector3 movement = transform.forward * -MovementInputValue * Speed * Time.deltaTime;
            tank.MovePosition(tank.position + movement);
            Speed -= 0.05f;
        }

    }

    private void Turn()
    {
        //Adjust the rotation of the tank based on the player's inpout
        float turn = TurnInputValue * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        tank.MoveRotation(tank.rotation * turnRotation);
    }
    /*
     private void EngineAudio()
     {
        This function will be for adding sound to the tank

        if(Tank is moving)
        {
            play the sound for when tank is moving
        }
        else if( tank is idle )
        {
            Play sound for tank stationary
        }
     }
    */

    /*public float thrust = 0;
    public Rigidbody rb;

    public float torque;
    float turn;
    int gear = 0; // value for gear. If gear = 0 then the vehicle is on neutral, if gear =-1 the vehicle is reversing and if gear=1 the vehicle is moving forward
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void FixedUpdate()
    {
        Acc();
        Steer();
    }

    public void Acc()
    {
        if (Input.GetKey(KeyCode.W) && thrust <= 150)
        {
            if (thrust < 0)
            {
                thrust += 10f;
            }
            else
            {
                thrust += 0.3f;
                rb.AddRelativeForce(0, 0, -thrust, ForceMode.Force);
            }
        }
        else if ( (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))  && thrust > 0)
        {
           thrust -= 0.2f;
        }


        if(Input.GetKey(KeyCode.S) && thrust >= -70)
        {
            if (thrust > 0)
            {
                thrust -= 10f;
            }

            if (thrust < 0)
            {
                thrust -= 0.2f;
                rb.AddForce(0, 0, -thrust, ForceMode.Force);
            }

        }
    }


    public void Steer()
    {
        /*if (Input.GetKey(KeyCode.A) && torque >= -10)
        {
            torque -= 0.1f;
            rb.AddTorque(0, torque, 0);

        }
        

        if(Input.GetKey(KeyCode.D) && torque <=10)
        {
            torque += 0.1f;
            rb.transform.Rotate(0, torque, 0);
            //turn = Input.GetAxis("Horizontal");
            //rb.AddRelativeTorque(0, torque, 0);
        }
        
    }*/
}

