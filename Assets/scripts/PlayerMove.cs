using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
    public Sprite right;
    public Sprite lookUp;
    public Sprite upperRight;
    public Sprite lowerRight;
    private float speed = 10f;
    private float jumpHeight = 1500f;
    private float moveX;
    private float moveY;
    private bool isGround = false;
    private bool faceRight = true;
    private bool onWaterCube = false;
    private Vector3 initPos;

    private bool hasDied = false;
    private SpriteRenderer spr;
    private Vector2 direction;
    public Transform firepoint_right;
    public Transform firepoint_left;
    public Transform firepoint_up;
    public Transform firepoint_upperright;
    public Transform firepoint_upperleft;
    public Transform firepoint_lowerright;
    public Transform firepoint_lowerleft;
    private Transform firePoint;
    private Direction dire;

    public int minYOfMap = -15;

    protected SingleJoystick singleJoyStick;
    protected JumpBtn jumpBtn;

    enum Direction
    {
        Right,
        Left,
        Up,
        Down,
        UpperRight,
        UpperLeft,
        LowerRight,
        LowerLeft,
    }
    // Use this for initialization
    void Start () {
        hasDied = false;
        spr = gameObject.GetComponent<SpriteRenderer>();
        initPos = gameObject.transform.position;
        singleJoyStick = FindObjectOfType<SingleJoystick>();
        jumpBtn = FindObjectOfType<JumpBtn>();
    }

    // Update is called once per frame
    void Update () {
        ToTransfer();
        Moving();
        JumpCheck();
        if (transform.position.y < minYOfMap)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine(ToStart());
        }
    }
    private void LateUpdate()
    {
        switch (dire)
        {
            case Direction.Right:
                spr.sprite = right;
                spr.flipX = false;
                faceRight = true;
                direction = Vector2.right;
                firePoint = firepoint_right;
                break;
            case Direction.Left:
                spr.sprite = right;
                spr.flipX = true;
                faceRight = false;
                direction = Vector2.left;
                firePoint = firepoint_left;
                break;
            case Direction.LowerLeft:
                spr.sprite = lowerRight;
                spr.flipX = true;
                faceRight = false;
                direction = new Vector2(-1, -1);
                direction.Normalize();
                firePoint = firepoint_lowerleft;
                break;
            case Direction.LowerRight:
                spr.sprite = lowerRight;
                spr.flipX = false;
                faceRight = true;
                direction = new Vector2(1, -1);
                direction.Normalize();
                firePoint = firepoint_lowerright;
                break;
            case Direction.Up:
                spr.sprite = lookUp;
                faceRight = true;
                direction = Vector2.up;
                firePoint = firepoint_up;
                break;
            case Direction.UpperRight:
                spr.sprite = upperRight;
                spr.flipX = false;
                faceRight = true;
                direction = new Vector2(1, 1);
                direction.Normalize();
                firePoint = firepoint_upperright;
                break;
            case Direction.UpperLeft:
                spr.sprite = upperRight;
                spr.flipX = true;
                faceRight = false;
                direction = new Vector2(-1, 1);
                direction.Normalize();
                firePoint = firepoint_upperleft;
                break;
        }
    }
    public Transform GetFirePoint()
    {
        return firePoint;
    }
    void ToTransfer()
    {
        if (onWaterCube)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                System.Threading.Thread.Sleep(1000);
                StartCoroutine(Transfer());
            }
        }
    }
    void Moving()
    {
        moveX = Input.GetAxis("Horizontal") + singleJoyStick.GetInputDirection().x;
        moveY = Input.GetAxis("Vertical") + singleJoyStick.GetInputDirection().y;
        if (Input.GetKeyDown(KeyCode.Space) || jumpBtn.pressed)
        { 
            if (Input.GetKey(KeyCode.S) || moveY < -0.3f)
            {
                DownJump();
            }
            else Jump();
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }*/
        if (Mathf.Abs(moveY)<0.3f && Mathf.Abs(moveX)<0.01f)
        {
            if (faceRight) dire=Direction.Right;
            else dire=Direction.Left;
        }
        else if (Mathf.Abs(moveY) < 0.3f)
        {
            if (moveX < 0f)
            {
                dire=Direction.Left;
            }
            if (moveX > 0f)
            {
                dire=Direction.Right;
            }
        }
        else if (moveY>0f)
        {
            if (Mathf.Abs(moveX) < 0.2f) dire=Direction.Up;
            else if (moveX > 0) dire=Direction.UpperRight;
            else dire=Direction.UpperLeft;
        }
        else
        {
            if(Mathf.Abs(moveX) < 0.01f) dire=Direction.Down;
            else if (moveX > 0) dire=Direction.LowerRight;
            else dire=Direction.LowerLeft;
        }
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        if (isGround)
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Trampoline"));
            if (hit) gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2 * jumpHeight);
            else gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            isGround = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = lookUp;
        }
    }
    void DownJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Floor"));
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
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.up, 1.0f, 1 << LayerMask.NameToLayer("Floor"));
            if (!hit) hit = Physics2D.Raycast(this.transform.position, Vector2.left, 1.0f, 1 << LayerMask.NameToLayer("Floor"));
            if (!hit) hit = Physics2D.Raycast(this.transform.position, Vector2.right, 1.0f, 1 << LayerMask.NameToLayer("Floor"));
            if (hit)
            {
                if (hit.collider.tag == "QuestionBlock")
                {
                    Debug.Log(hit.collider.GetComponent<TrapQuestionBlock>());

                    // Check if hit a question block
                    hit.collider.GetComponent<QuestionBlock>().QuestionBlockBounce();
                } else if (hit.collider.tag == "TrapQuestionBlock") {
                    Debug.Log(hit.collider.GetComponent<TrapQuestionBlock>());
                    hit.collider.GetComponent<TrapQuestionBlock>().QuestionBlockBounce();
                } else
                {
                    // Check if Player could go through block
                    hit.collider.isTrigger = true;
                }

            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ground" || collision.gameObject.tag == "QuestionBlock"
            || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "WaterCube" || collision.gameObject.tag == "Trampoline")
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                isGround = true;
            }
            if (collision.gameObject.tag == "WaterCube")
            {
                onWaterCube = true;
            }
        }
        else if (collision.gameObject.tag == "Trap")
        {
            //hasDied = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            hasDied = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WaterCube")
        {
            onWaterCube = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Trap")
        {
            hasDied = true;
        }
    }
    public void Die()
    {
        hasDied = true;
    }
    public Vector2 GetShootDirection()
    {
        return direction;
    }
    public IEnumerator Transfer()
    {
        SceneManager.LoadScene("WaterCubeTransferScene");
        yield return new WaitForSeconds(2);
    }
    public IEnumerator ToStart()
    {
        hasDied = false;
        gameObject.transform.position = initPos;
        SceneManager.LoadScene("DeathScene");
        yield return new WaitForSeconds(2);
        //SceneManager.LoadScene("SampleScene");
    }

}
