using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_S_up : MonoBehaviour
{

    public float speed = 30;
    public int damage = 100;
    public Rigidbody2D rb;
    public PlayerMove PM;
    private CameraControl cc;
    private float radius = 1.5f;
    // Use this for initialization
    void Start()
    {
        //rb.velocity = transform.right * speed;
        PM = GameObject.Find("Player").GetComponent<PlayerMove>();
        Vector2 dir = PM.GetShootDirection();
        float dirX = ((dir.x / radius) * Mathf.Cos((30 * Mathf.PI) / 180) - (dir.y / radius) * Mathf.Sin((30 * Mathf.PI) / 180)) * 1.0f;
        float dirY = ((dir.y / radius) * Mathf.Cos((30 * Mathf.PI) / 180) + (dir.x / radius) * Mathf.Sin((30 * Mathf.PI) / 180)) * 1.0f;
        Vector2 dir_new = new Vector2(dirX, dirY);
        rb.velocity = dir_new * speed;
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
