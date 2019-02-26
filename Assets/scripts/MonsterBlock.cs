using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBlock : MonoBehaviour {

    public int mBlockHealth = 50;
    public GameObject monsterPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerExit2D(Collider2D other)
    {

    }

    public void TakeDamage(int damage)
    {
        mBlockHealth -= damage;
        if (mBlockHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
        Instantiate(monsterPrefab,transform.position,transform.rotation);
    }

}
