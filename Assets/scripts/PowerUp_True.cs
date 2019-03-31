using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_True : MonoBehaviour
{
    // Use this for initialization
    public GameObject bullet_S;
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
            Weapon wp = col.gameObject.GetComponent(typeof(Weapon))as Weapon;
            if (wp != null) {
                wp.bulletPrefab = bullet_S;

            }
        }
    }
}
