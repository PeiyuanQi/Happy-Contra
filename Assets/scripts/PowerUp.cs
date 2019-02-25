using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Use this for initialization
    public GameObject bullet_B;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);

            // original power up
            //Weapon wp = col.gameObject.GetComponent(typeof(Weapon))as Weapon;
            //if (wp != null) {

            //    wp.bulletPrefab = bullet_B;

            //}

            // or a trap
            int damage = 120;
            PlayerLife playerLife = col.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }

        }
    }
}
