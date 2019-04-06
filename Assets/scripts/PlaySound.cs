using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    private AudioSource music;
    private AudioClip hitenemy, hitbox;
    // Use this for initialization
    void Start() {
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        hitenemy = Resources.Load<AudioClip>("hitenemy");
        hitbox = Resources.Load<AudioClip>("hitbox");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayHitEnemy()
    {
        music.clip = hitenemy;
        music.Play();
        //Debug.Log("PlayHitEnemy");
    }
    public void PlayHitBox()
    {
        music.clip = hitbox;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
}
