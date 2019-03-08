using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20;
    public int damage = 40;
    public Rigidbody2D rb;
    public PlayerMove PM;

	// Use this for initialization
	void Start () {
        //rb.velocity = transform.right * speed;
        PM= GameObject.Find("Player").GetComponent<PlayerMove>();
        Vector2 dir = PM.GetShootDirection();
        rb.velocity = dir*speed;
    }

    private void Update()
    {
        if (!Camera.Instance.InRange(gameObject.transform.position.x, gameObject.transform.position.y))
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
        
        PowerUpBlimp blimp = hitInfo.GetComponent<PowerUpBlimp>();
        if (blimp != null)
        {
            blimp.TakeDamage(damage);
            Destroy(gameObject);
        }
        Box box= hitInfo.GetComponent<Box>();
        if (box != null)
        {
            box.TakeDamage(damage);
            Destroy(gameObject);
        }
        MonsterBlock mBlock = hitInfo.GetComponent<MonsterBlock>();
        if (mBlock != null)
        {
            mBlock.TakeDamage(damage);
            Destroy(gameObject);
        }

        Monster monster = hitInfo.GetComponent<Monster>();
        if (monster != null)
        {
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }

        Turret turret = hitInfo.GetComponent<Turret>();
        if(turret != null)
        {
            turret.TakeDamage(damage);
            Destroy(gameObject);
        }


        if (hitInfo.gameObject.tag == "Destructable")
        {
            hitInfo.gameObject.GetComponent<DamageDestructable>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }

}
