using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            StartCoroutine("Play");
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Play()
    {
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSeconds(2);
    }
}
