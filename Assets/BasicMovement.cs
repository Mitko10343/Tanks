using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public int maxSpeed;
    public float currentSpeed;

    public float thrust = 0;
    public Rigidbody rb;

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
        if (Input.GetKey(KeyCode.W) && thrust <= 150)
        {
            thrust += 0.1f;
            rb.AddForce(0, 0, -thrust, ForceMode.Acceleration);

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

        if(Input.GetKey(KeyCode.S) && thrust <= 70)
        {
            thrust += 0.1f;
            rb.AddForce(0, 0, thrust, ForceMode.Acceleration);

        }
    }


    public void Steer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (currentSpeed < 100)
            {
                MaxturnAngle = 35;
                if (turnAngle < MaxturnAngle)
                {
                    turnAngle++;
                }
                transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
            }
            else
            {
                turnAngle = turnAngle - 10;
                MaxturnAngle = 30;
                if (turnAngle < MaxturnAngle)
                {
                    turnAngle++;
                }
                transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
            }
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

