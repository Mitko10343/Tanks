using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {


    public float thrust = 0;
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
        */
    }
}

