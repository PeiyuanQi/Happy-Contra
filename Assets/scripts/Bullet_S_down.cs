using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_S_down: MonoBehaviour
{

    public float speed = 30;
    public int damage = 100;
    public Rigidbody2D rb;
    public PlayerMove PM;
    private CameraControl cc;

    // Use this for initialization
    void Start()
    {
        //rb.velocity = transform.right * speed;
        PM = GameObject.Find("Player").GetComponent<PlayerMove>();
        Vector2 dir = PM.GetShootDirection();
        dir = new Vector2(1,-1);
        rb.velocity = dir * speed;
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
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        PowerUpBlimp Blimp = hitInfo.GetComponent<PowerUpBlimp>();
        if (Blimp != null)
        {
            Blimp.TakeDamage(damage);
            Destroy(gameObject);
        }

    }

}
