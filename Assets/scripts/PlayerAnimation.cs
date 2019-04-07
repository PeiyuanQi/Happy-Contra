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
    public void setAnim(bool mirror, Vector2 dir, bool standing)
    {
        ac.SetBool("Mirror", mirror);
        if (standing)
        {
            ac.Play("PlayerStanding");
            return;
        }
        if (dir.y==0)
        {
            ac.Play("PlayerWalkRight");
        }
        else
        {
            if (dir.y>0)
            {
                if (dir.x==0)
                {
                    ac.Play("PlayerLookUp");
                }
                else
                {
                    ac.Play("PlayerShootingUpperRight");
                }
                
            }
            else
            {
                ac.Play("PlayerShootingLowerRight");
            }
        }
    }
}
