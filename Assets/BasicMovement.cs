using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public int PlayerNum;
    public float initialSpeed;
    public float Speed;
    public float turnSpeed;
    public float maxSpeed;

    public AudioClip otherclip;

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
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();

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
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();
            Speed = initialSpeed -1;
            tank.drag = 0.5f;
        }


        if(MovementInputValue == 1)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();
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
}

