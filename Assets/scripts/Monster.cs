using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public int health = 100;
    public int damage = 100;
    public int speed = 3;
    public GameObject player;
    public float playerX;
    public Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//找到tag为player的对象
        target = player.transform;
    }

    void Update()
    {
        playerX = player.transform.position.x;
    }
    void FixedUpdate()
    {
        if (playerX > transform.position.x)
        {
            rb.velocity = new Vector3(3,0,0);
        }
        else
        {
            rb.velocity = new Vector3(-3, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
