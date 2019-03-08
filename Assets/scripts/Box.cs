using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Box : MonoBehaviour
{

    public int health = 50;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
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
    void Die()
    {

        // 添加触发后的事件，奖励等
        Destroy(gameObject);
        // 创建GameObject对象
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
