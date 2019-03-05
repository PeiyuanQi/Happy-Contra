using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour {
    public int XMoveDirection;
    public float XMin, XMax;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(XMoveDirection, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
        if (gameObject.transform.position.x > XMax || gameObject.transform.position.x < XMin)
        {
            XMoveDirection = -XMoveDirection;
        }
    }



    protected void Die()
    {
        Destroy(gameObject);
    }

}
