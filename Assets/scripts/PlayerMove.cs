using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
    private float speed = 10f;
    private float jumpHeight = 1500f;
    private float moveX;
    private bool isGround = false;
    private bool faceRight = true;

    private bool hasDied = false;

    // Use this for initialization
    void Start () {
        hasDied = false;
    }
	
	// Update is called once per frame
	void Update () {
        Moving();
        JumpCheck();
        if (transform.position.y < -5)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("ToStart");
        }
    }
    void Moving()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (Input.GetKey(KeyCode.S))
            {
                DownJump();
            }
            else Jump();
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }*/
        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0f && faceRight==true)
        {
            FlipPlayer();
        }
        if (moveX > 0f && faceRight == false)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void FlipPlayer()
    {
        transform.Rotate(0f, 180f, 0f);
        faceRight = !faceRight;
    }
    void Jump()
    {
        if (isGround)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            isGround = false;
        }
    }
    void DownJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("floor"));
        if (hit)
        {
            hit.collider.isTrigger = true;
        }
        isGround = false;
    }
    void JumpCheck()
    {
        if (!isGround && gameObject.GetComponent<Rigidbody2D>().velocity.y>0)
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
                isGround = true;
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
        //collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        /*if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }*/
            
    }
    public void Die()
    {
        hasDied = true;
    }
    public IEnumerator ToStart()
    {
        SceneManager.LoadScene("SampleScene");
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(2);
        hasDied = false;
    }
}
