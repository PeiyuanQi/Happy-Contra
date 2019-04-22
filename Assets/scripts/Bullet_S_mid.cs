using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_S_mid: MonoBehaviour
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
        GameObject sound = GameObject.Find("Sound");
        PlaySound play = sound.GetComponent<PlaySound>();
        if (enemy != null)
        {
            play.PlayHitEnemy();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        PowerUpBlimp blimp = hitInfo.GetComponent<PowerUpBlimp>();
        if (blimp != null)
        {
            play.PlayHitBox();
            blimp.TakeDamage(damage);
            Destroy(gameObject);
        }
        Box box = hitInfo.GetComponent<Box>();
        if (box != null)
        {
            play.PlayHitBox();
            box.TakeDamage(damage);
            Destroy(gameObject);
        }
        MonsterBlock mBlock = hitInfo.GetComponent<MonsterBlock>();
        if (mBlock != null)
        {
            play.PlayHitBox();
            mBlock.TakeDamage(damage);
            Destroy(gameObject);
        }

        Monster monster = hitInfo.GetComponent<Monster>();
        if (monster != null)
        {
            play.PlayHitEnemy();
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }

        Turret turret = hitInfo.GetComponent<Turret>();
        if (turret != null)
        {
            play.PlayHitEnemy();
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
