using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public static Camera Instance;
    public GameObject player;
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    public float CameraCenterVerticalOffset;
    public int cameraEdge = 7;
    // Use this for initialization
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        float x = Mathf.Clamp(player.transform.position.x, xmin, xmax);
        float y = Mathf.Clamp(player.transform.position.y + CameraCenterVerticalOffset, ymin, ymax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
    public bool InRange(float x)
    {
        return (gameObject.transform.position.x - cameraEdge <= x && 
                gameObject.transform.position.x + cameraEdge >= x);
    }
    public bool RightOutOfRange(float x)
    {
        return (gameObject.transform.position.x + cameraEdge < x);
    }
}
