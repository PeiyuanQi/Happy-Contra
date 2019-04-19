using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSuccess : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject sound = GameObject.Find("Sound");
            PlaySound play = sound.GetComponent<PlaySound>();
            play.SetEnableExplode(true);
            SceneManager.LoadScene("SuccessScene");
        }
    }


}
