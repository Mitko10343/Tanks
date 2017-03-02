using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public int maxSpeed;
    public float currentSpeed;

    public float turnAngle;
    public float MaxturnAngle;
    public float brakeForce;


    void Update()
    {
        Acc();
        Steer();
    }

    public void Acc()
    {

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += 0.5f;
            if (currentSpeed < maxSpeed)
            {
                transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
            }
            else
            {
                currentSpeed--;
            }
        }
        else if (!Input.GetKey(KeyCode.S))
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
        }

        if(Input.GetKey(KeyCode.S))
        {
            currentSpeed = currentSpeed -0.5f;

            if (currentSpeed > -75)
            {
                transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(0, 0, -75 * Time.deltaTime);
            }
  
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

