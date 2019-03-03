using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    public int health = 100;
    private PlayerMove playerMove;

    // Use this for initialization
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        playerMove.Die();
    }

}
