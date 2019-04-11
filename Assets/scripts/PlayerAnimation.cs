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
        //0:horizontal; 1: upper; 2: lower; 3:lookup
        ac.SetBool("FaceRight", mirror);
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
        }
    }
}
