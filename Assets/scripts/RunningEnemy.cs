using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : Enemy
{

    public float speed;
    public Vector2 direction = Vector2.left;
    private SpriteRenderer srender;
    private Animator ac;
    private CameraControl cc;

    // Use this for initialization
    void Start()
    {
        cc = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        srender = gameObject.GetComponent<SpriteRenderer>();
        ac = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed);
        //如果在摄像机画面左侧 -> 消失
        if (cc.LeftOutOfRange(gameObject.transform.position.x))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (direction == Vector2.left &&
                collision.gameObject.transform.position.x <
                gameObject.transform.position.x)
            {
                direction = Vector2.right;
                //srender.flipX = !srender.flipX;
                //ac.SetBool("FaceRight", true);
                ac.Play("RightRun");
            }
            else if (direction == Vector2.right &&
                collision.gameObject.transform.position.x >
                gameObject.transform.position.x)
            {
                direction = Vector2.left;
                //srender.flipX = !srender.flipX;
                //ac.SetBool("FaceRight", false);
                ac.Play("LeftRun");
            }
        }

    }
}
