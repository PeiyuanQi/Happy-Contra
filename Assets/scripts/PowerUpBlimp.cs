using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PowerUpBlimp : MonoBehaviour
{

    public int health = 50;
    public char gun;
    float t = 0;
    public float freq = 10;
    public float yi = 4;
    public float xSpeed = 2f;
    public GameObject Update_B;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        t += Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y = yi + Mathf.Sin(freq * t);
        pos.x += xSpeed * Time.deltaTime;
        transform.position = pos;
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
        Instantiate(Update_B, transform.position, Quaternion.identity);
    }
}
