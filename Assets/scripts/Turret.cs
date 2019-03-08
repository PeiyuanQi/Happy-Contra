using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    //change picture of turret and firepoint
    public Sprite Up,Left,Down,Right;
    public Sprite upRight1,upRight2,rightDown3,rightDown4,downLeft5,downLeft6,leftUp7,leftUp8;
    public Transform fp_up, fp_left, fp_down, fp_right, fp_ur1, fp_ur2, fp_rd3, fp_rd4, fp_dl5, fp_dl6, fp_lu7, fp_lu8;
    private Transform firepoint;
    private GameObject player;
    private SpriteRenderer spr;
    private double sinX, sinY, sinValue;

    //for bullet
    public GameObject turretBullet;
    public double shortInterval = 0.1;
    public double longInterval = 2;
    public int bulletNum = 3;
    private int bulletShot = 0;
    private double longTimer = 2;
    private double shortTimer = 0;
    private Vector2 direction;

    //for itself
    public int health = 100;



	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        spr = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        sinX = player.transform.position.x - transform.position.x;
        sinY = player.transform.position.y - transform.position.y;
        if (Math.Abs(sinX) < 50)
        {
            ChangePicFp();
            ShootAndWait();
        }
    }


    void ChangePicFp()
    {
        sinValue = sinY / Math.Sqrt(sinX * sinX + sinY * sinY);

        if (sinX > 0 && sinY > 0)
        {
            if (Math.Sin(0 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(15 * Math.PI / 180))
            {
                spr.sprite = Right;
                firepoint = fp_right;
                direction = Vector2.right;              
            }
            else if (Math.Sin(15 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(45 * Math.PI / 180))
            {
                spr.sprite = upRight2;
                firepoint = fp_ur2;
                direction = new Vector2((float)(Math.Sqrt(3))/2, 0.5f);
            }
            else if (Math.Sin(45 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(75 * Math.PI / 180))
            {
                spr.sprite = upRight1;
                firepoint = fp_ur1;
                direction = new Vector2(0.5f,(float)(Math.Sqrt(3))/2);
            }
            else if (Math.Sin(75 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(90 * Math.PI / 180))
            {
                spr.sprite = Up;
                firepoint = fp_up;
                direction = Vector2.up;
            }
        }
        else if (sinX < 0 && sinY > 0)
        {
            if (Math.Sin(90 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(105 * Math.PI / 180))
            {
                spr.sprite = Up;
                firepoint = fp_up;
                direction = Vector2.up;
            }
            else if (Math.Sin(105 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(135 * Math.PI / 180))
            {
                spr.sprite = leftUp8;
                firepoint = fp_lu8;
                direction = new Vector2(-0.5f, (float)(Math.Sqrt(3))/2);
            }
            else if (Math.Sin(135 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(165 * Math.PI / 180))
            {
                spr.sprite = leftUp7;
                firepoint = fp_lu7;
                direction = new Vector2(-(float)(Math.Sqrt(3))/2, 0.5f);
            }
            else if (Math.Sin(165 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(180 * Math.PI / 180))
            {
                spr.sprite = Left;
                firepoint = fp_left;
                direction = Vector2.left;
            }
        }
        else if (sinX < 0 && sinY < 0)
        {
            if (Math.Sin(180 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(195 * Math.PI / 180))
            {
                spr.sprite = Left;
                firepoint = fp_left;
                direction = Vector2.left;
            }
            else if (Math.Sin(195 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(225 * Math.PI / 180))
            {
                spr.sprite = downLeft6;
                firepoint = fp_dl6;
                direction = new Vector2(-(float)(Math.Sqrt(3))/2, -0.5f);
            }
            else if (Math.Sin(225 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(255 * Math.PI / 180))
            {
                spr.sprite = downLeft5;
                firepoint = fp_dl5;
                direction = new Vector2(-0.5f, -(float)(Math.Sqrt(3))/2);
            }
            else if (Math.Sin(255 * Math.PI / 180) > sinValue && sinValue >= Math.Sin(270 * Math.PI / 180))
            {
                spr.sprite = Down;
                firepoint = fp_down;
                direction = Vector2.down;
            }
        }
        else if (sinX > 0 && sinY < 0)
        {
            if (Math.Sin(270 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(285 * Math.PI / 180))
            {
                spr.sprite = Down;
                firepoint = fp_down;
                direction = Vector2.down;
            }
            else if (Math.Sin(285 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(315 * Math.PI / 180))
            {
                spr.sprite = rightDown4;
                firepoint = fp_rd4;
                direction = new Vector2(0.5f, -(float)(Math.Sqrt(3)))/2;
            }
            else if (Math.Sin(315 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(345 * Math.PI / 180))
            {
                spr.sprite = rightDown3;
                firepoint = fp_rd3;
                direction = new Vector2((float)(Math.Sqrt(3))/2, -0.5f);
            }
            else if (Math.Sin(345 * Math.PI / 180) < sinValue && sinValue <= Math.Sin(360 * Math.PI / 180))
            {
                spr.sprite = Right;
                firepoint = fp_right;
                direction = Vector2.right;
            }
        }
    }
    void ShootAndWait()
    {
        longTimer += Time.deltaTime;
        if(longTimer >= longInterval)
        {
            shortTimer += Time.deltaTime;
            if (shortTimer >= shortInterval)
            {
                Instantiate(turretBullet, firepoint.position, firepoint.rotation);
                shortTimer = 0;
                bulletShot += 1;
                if(bulletShot == bulletNum)
                {
                    bulletShot = 0;
                    longTimer = 0;
                }
            }
        }
    }
   
    public Vector2 GetShootDirection()
    {
        return direction;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
