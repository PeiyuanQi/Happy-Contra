using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    private AudioSource music;
    private AudioClip hitenemy, hitbox, shoot, jump, death;
    // Use this for initialization
    void Start() {
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        hitenemy = Resources.Load<AudioClip>("hitenemy");
        hitbox = Resources.Load<AudioClip>("hitbox");
        shoot = Resources.Load<AudioClip>("gun_shoot");
        jump = Resources.Load<AudioClip>("jump");
        death = Resources.Load<AudioClip>("death");
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
    public void PlayShoot()
    {
        music.clip = shoot;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
    public void PlayJump()
    {
        music.clip = jump;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
    public void PlayDeath()
    {
        music.clip = death;
        music.Play();
        //Debug.Log("PlayDeath");
    }
}
