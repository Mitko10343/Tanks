﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    //Drag in the bullet shooter
    public GameObject BulletShooter;

    //drag in the bullet prefab 
    public GameObject Bullet;

    //the force the bullet will fly with
    public float BulletForwardForce;

    public string ShootingKey;
    public int healthX;
    public int healthY;

    public AudioClip shoot;
    public float health;
    public Transform canvas;

	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(ShootingKey))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = shoot;
            audio.Play();
            //Create A bullet
            GameObject Temp_BulletShooter;
            Temp_BulletShooter = Instantiate(Bullet, BulletShooter.transform.position, BulletShooter.transform.rotation) as GameObject;

            //Retrieve the Rigidbody component from the instantiated bullet and control it
            Rigidbody temp_bullet;
            temp_bullet = Temp_BulletShooter.GetComponent<Rigidbody>();

            //ading force to the bullet
            temp_bullet.AddForce(transform.forward * -BulletForwardForce);

            //delete the bullet after a while
            Destroy(Temp_BulletShooter, 3.0f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Debug.Log("hit");
            health -= 10;
            if(health <=0)
            {
                Debug.Log("Player health critical");
                DisplayFinishScreen();
                Time.timeScale = 0;
            }
        }

    }

    private void DisplayFinishScreen()
    {
        canvas.gameObject.SetActive(true);

    }

    void OnGUI()
    {
        GUI.Label(new Rect(healthX, healthY, 100, 20), "HEALTH:"+health.ToString());
    }



}
