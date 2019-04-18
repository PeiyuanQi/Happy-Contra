using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour {

    private Rigidbody2D rg2d;
    public float fallDelay;

	// Use this for initialization
	void Start () {
        rg2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rg2d.gravityScale = 1;
        rg2d.mass = 1;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield return 0;
    }
}
