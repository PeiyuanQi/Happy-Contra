using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private float speed = 10f;
    private float jumpheight = 1500f;
    private float moveX;
    private bool isground = false;
    private bool faceRight = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Playermove();
        jumpcheck();
	}
    void Playermove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (Input.GetKey(KeyCode.S))
            {
                downJump();
            }
            else jump();
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }*/
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0f && faceRight==true)
        {
            flipPlayer();
        }
        if (moveX > 0f && faceRight == false)
        {
            flipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void flipPlayer()
    {
        transform.Rotate(0f, 180f, 0f);
        faceRight = !faceRight;
    }
    void jump()
    {
        if (isground)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpheight);
            isground = false;
        }
    }
    void downJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("floor"));
        if (hit)
        {
            hit.collider.isTrigger = true;
        }
        isground = false;
    }
    void jumpcheck()
    {
        if (!isground && gameObject.GetComponent<Rigidbody2D>().velocity.y>0)
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.up, 1.0f, 1 << LayerMask.NameToLayer("floor"));
            if (hit)
            {
                hit.collider.isTrigger = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                isground = true;
                //collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                //collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                //Debug.Log("HIIIIIIIIIIIIIIT");
            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        /*if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }*/
            
    }
    
}
