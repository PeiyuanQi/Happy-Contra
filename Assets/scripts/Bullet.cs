using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20;
    public int damage = 40;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}

    private void Update()
    {
        if (!Camera.Instance.InRange(gameObject.transform.position.x))
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
        }
        Destroy(gameObject);
        PowerUpBlimp Blimp = hitInfo.GetComponent<PowerUpBlimp>();
        if (Blimp != null)
        {
            Blimp.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
