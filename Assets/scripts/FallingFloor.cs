using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.1f)
            {
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
                PlayerLife playerLife = other.gameObject.GetComponent<PlayerLife>();
                if (playerLife != null)
                {
                    playerLife.Die();
                }
            }
    }
}
