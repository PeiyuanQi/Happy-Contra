using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//向右移动的敌人
public class MovingEnemy : Enemy {

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
        transform.Translate(Vector2.right * speed);
        //如果在摄像机画面右侧 -> 消失
        if (Camera.Instance.RightOutOfRange(gameObject.transform.position.x))
        {
            Destroy(gameObject);
        }
    }

}
