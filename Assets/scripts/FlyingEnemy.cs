using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//向左移动的敌人
public class FlyingEnemy : Enemy {

    public float speed;
    //private float currentposx;
    //private float currentposy;

    //public new int damage = 50;

    void Start()
    {
        //currentposx = gameObject.transform.position.x;
        speed = 0.04f;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed);
        //如果在摄像机画面左侧 -> 消失
        if (Camera.Instance.LeftOutOfRange(gameObject.transform.position.x))
        {
            Destroy(gameObject);
        }
    }

}
