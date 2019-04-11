using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime , Space.World);
        if(transform.localPosition.x > 500)
        {
            Vector3 vector = new Vector3(-400, -150, 1);
            transform.localPosition = vector;
        }
    }

}
