using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPointFlag : MonoBehaviour {

    public Animator animator;
    private PlayerMove playerMove;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        if (playerMove.IsSaved())
        {
            animator.Play("Top");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("saved", true);
            GameObject sound = GameObject.Find("Sound");
            PlaySound play = sound.GetComponent<PlaySound>();
            play.UnsetEnableExplode();
        }
    }
}
