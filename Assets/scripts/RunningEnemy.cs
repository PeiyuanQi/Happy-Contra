using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : Enemy {

    public float speed;

    // Use this for initialization
    void Start () {
        speed = 0.04f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed);
        //如果在摄像机画面左侧 -> 消失
        if (Camera.Instance.LeftOutOfRange(gameObject.transform.position.x))
        {
            Destroy(gameObject);
        }
    }
}
