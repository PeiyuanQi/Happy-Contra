using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessButton : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
    

    // Update is called once per frame
    void Update () {
		
	}

    public void OnSuccessMenuClick()
    {
        PlayerMove.ResetSavingPoint();
        PlayerPrefs.SetInt("life", 3);
        SceneManager.LoadScene("MainScene");
    }

    public void OnSuccessReplayClick()
    {
        PlayerMove.ResetSavingPoint();
        PlayerPrefs.SetInt("life", 3);
        SceneManager.LoadScene("SampleScene");
    }
}
