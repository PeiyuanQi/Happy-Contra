using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float XOrigin,XDestination;
    public GameObject player;
    private int isTriggered;
	// Use this for initialization
	void Start () {
        isTriggered = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.x >= XDestination)
        {
            isTriggered = 0;
        }
        else if (player.transform.position.x >= XOrigin - 1)
        {
            isTriggered = 1;
        }
        Vector3 move = new Vector3(isTriggered * 10, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
    }
}
