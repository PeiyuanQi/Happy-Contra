using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject player;
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xmin, xmax);
        float y = Mathf.Clamp(player.transform.position.y, ymin, ymax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
