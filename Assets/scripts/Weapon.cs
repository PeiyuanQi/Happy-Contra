using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet_S;
    public GameObject bullet_S_Up;
    public GameObject bullet_S_Down;
    private PlayerMove PM;
    public float shootRate = 5;  //表示每秒发射子弹的个数 俗称子弹的发射速率

    private float shootTimer = 0;  //表示子弹的生成时间间隔 用来控制子弹的发射间隔

    private float shootTimerInterval = 0;  //表示子弹的间隔这个是一个固定的时间

    protected ShootBtn shootBtn;


    private void Start()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerMove>();
        shootTimerInterval = 1 / shootRate;
        shootBtn = FindObjectOfType<ShootBtn>(); // joystick shoot btn
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1") || shootBtn.pressed)
        {
            shootTimer += Time.deltaTime;  //让子弹的时间控制器不断加等时间间隔

            if (shootTimer > shootTimerInterval)
            {  //如果子弹发射的时间间隔超过时间控制器　　那么我们就发射子弹

                shootTimer -= shootTimerInterval;  //让子弹的时间间隔回复到初始的情况下
                Shoot();
            }
            else if (shootTimer - Time.deltaTime < 0.01f) //第一次短按也能发射子弹
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == bullet_S)
        {
            firePoint = PM.GetFirePoint();
            Instantiate(bullet_S_Up, firePoint.position, firePoint.rotation);
            Instantiate(bullet_S, firePoint.position, firePoint.rotation);
            Instantiate(bullet_S_Down, firePoint.position, firePoint.rotation);
        }
        else
        {
            firePoint = PM.GetFirePoint();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
