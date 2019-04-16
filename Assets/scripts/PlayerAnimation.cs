using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    // Use this for initialization
    private Animator ac;
	void Start () {
        ac = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setAnim(bool FaceRight, Vector2 dir, bool standing)
    {
        //0:horizontal; 1: upper; 2: lower; 3:lookup;
        /*ac.SetBool("FaceRight", mirror);
        ac.SetBool("Standing", standing);
        if (dir.y==0)
        {
            ac.SetInteger("Direction", 0);
        }
        else
        {
            if (dir.y>0)
            {
                if (dir.x==0)
                {
                    ac.SetInteger("Direction", 3);
                }
                else
                {
                    ac.SetInteger("Direction", 1);
                }
                
            }
            else
            {
                ac.SetInteger("Direction", 2);
            }
        }*/
        if (FaceRight)
        {
            if (dir == Vector2.up) ac.Play("PlayerLookUp");
            else
            {
                if (standing) ac.Play("PlayerStanding");
                else
                {
                    if (dir.y == 0) ac.Play("PlayerWalkRight");
                    else if (dir.y > 0) ac.Play("PlayerShootingUpperRight");
                    else ac.Play("PlayerShootingLowerRight");
                }
            }
        }
        else
        {
            if (dir == Vector2.up) ac.Play("PlayerLookupLeft");
            else
            {
                if (standing) ac.Play("PlayerStandingLeft");
                else
                {
                    if (dir.y == 0) ac.Play("PlayerWalkLeft");
                    else if (dir.y > 0) ac.Play("PlayerShootingUpperLeft");
                    else ac.Play("PlayerShootingLowerLeft");
                }
            }
        }
    }
}
