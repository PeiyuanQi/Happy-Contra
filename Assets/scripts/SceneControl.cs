using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour {
    public Text lifes;
    public static int numLifes=3;
	// Use this for initialization
	void Start () {
        StartCoroutine("ShowScene");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator ShowScene()
    {
        GameObject sound = GameObject.Find("Sound");
        PlaySound play = sound.GetComponent<PlaySound>();
        play.PlayDie();
        if(PlayerPrefs.GetInt("life") == 3)
        {
            numLifes = 3;
            PlayerPrefs.DeleteKey("life");
        }
        numLifes--;
        lifes.text = " : " + numLifes.ToString();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}
