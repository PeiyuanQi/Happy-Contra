using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {

    public BoxCollider2D doorSwitchActivator;
    public BoxCollider2D doorSwitchButton;
    public GameObject door;

    private int ButtonDownNumber;
    private int btnDir; //0->stop, 1->up, -1->down
    private float btnSpeed;
    private Vector3 btnOrigScale;
    private Vector3 btnDestScale;

    private int doorDir;
    private float doorSpeed;
    private float doorTopY;
    private float doorDownY;

    // Use this for initialization
    void Start () {
        btnDir = 0;
        doorDir = 0;
        ButtonDownNumber = 0;

        btnSpeed = 0.5f;
        btnOrigScale = doorSwitchButton.transform.localScale;
        btnDestScale = new Vector3(0, 0.1f, 0);

        doorSpeed = 1;
        doorDownY = door.transform.position.y;
        doorTopY = door.transform.position.y + 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (btnDir > 0 && doorSwitchButton.transform.localScale.y >= btnOrigScale.y || 
            btnDir < 0 && doorSwitchButton.transform.localScale.y <= btnDestScale.y)
        {
            btnDir = 0;
        }

        if (doorDir > 0 && door.transform.position.y >= doorTopY ||
            doorDir < 0 && door.transform.position.y <= doorDownY)
        {
            doorDir = 0;
        }

        Vector3 btnMove = new Vector3(0, btnSpeed * btnDir, 0);
        doorSwitchButton.transform.localScale += btnMove * Time.deltaTime;

        Vector3 doorMove = new Vector3(0, doorSpeed * doorDir, 0);
        door.transform.Translate(doorMove * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ButtonDownNumber++;
        btnDir = -1;
        doorDir = 2;
        Debug.Log("enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ButtonDownNumber--;
        if (ButtonDownNumber == 0)
        {
            btnDir = 1;
            doorDir = -6;
        }
        Debug.Log("out");
    }
}
