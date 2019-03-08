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

    // Use this for initialization
    void Start()
    {
        //rb.velocity = transform.right * speed;
        turr = GameObject.Find("Turret").GetComponent<Turret>();
        Vector2 dir = turr.GetShootDirection();
        rb.velocity = dir * speed;
        print(dir);
    }

    private void Update()
    {
        distance = (turr.transform.position - transform.position).sqrMagnitude;
        if (distance > distanceThreshold)
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
}
