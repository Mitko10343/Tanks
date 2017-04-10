using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float currentSpeed;
    public float maxSpeed;

    public float downForce;
    public float thrust = 0;
    public Rigidbody rb;

    public float torque;
    float turn;


    public float turnAngle;
    public float MaxturnAngle;
    public float brakeForce;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        Acc();
        Steer();
    }

    public void Acc()
    {
        //rb.AddForce(0, -downForce, 0, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.W) && thrust <= 15000)
        {
            thrust += 13f;
            rb.AddForce(0, 0, -thrust, ForceMode.Force);
        }
        else if (!Input.GetKey(KeyCode.W) && thrust != 0)
        {
            thrust -= 0.2f;
        }

        /*else if (!Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > 10)
            {
                currentSpeed = currentSpeed - brakeForce;
                transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
            }
            else
            {
                currentSpeed = 0;
                transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
            }
        }*/

        if(Input.GetKey(KeyCode.S) && thrust <= 7000)
        {
            thrust += 13f;
            rb.AddForce(0, 0, thrust, ForceMode.Force);

        }
    }


    public void Steer()
    {
        if (Input.GetKey(KeyCode.A) && torque <= 150)
        {
            torque += 0.4f;
            turn = Input.GetAxis("Horizontal");
            rb.AddTorque(transform.up * torque * turn);
        }
        

        if(Input.GetKey(KeyCode.D))
        {
            if (currentSpeed < 100)
            {
                MaxturnAngle = 25;

                if (turnAngle < MaxturnAngle)
                {
                    turnAngle++;
                }
                transform.Rotate(0, turnAngle * Time.deltaTime, 0);
            }
            else
            {
                turnAngle = turnAngle-10;
                MaxturnAngle = 20;
                if (turnAngle < MaxturnAngle)
                {
                    turnAngle++;
                }
                transform.Rotate(0, turnAngle * Time.deltaTime, 0);
            }
        }
        
    }
}

