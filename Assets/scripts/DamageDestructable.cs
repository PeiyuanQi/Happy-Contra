using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDestructable : MonoBehaviour {
    private int health;
	// Use this for initialization
	void Start () {
        health = 200;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
