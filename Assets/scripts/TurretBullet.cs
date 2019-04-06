using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour {

    public float speed = 10;
    public int damage = 40;
    public Rigidbody2D rb;
    public Turret turr;
    public double distanceThreshold = 50;
    private double distance;
    private CameraControl cc;

    // Use this for initialization
    void Start()
    {
        cc = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }

    private void Update()
    {
        if (!cc.InRange(gameObject.transform.position.x, gameObject.transform.position.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag == "Player")
        {
            PlayerLife playerLife = hitInfo.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    public void setDir(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }
}
