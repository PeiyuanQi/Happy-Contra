using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    private AudioSource music;
    private AudioClip hitenemy, hitbox, shoot, jump, die, explode;
    private static bool enableExplode = true;
    // Use this for initialization
    void Start() {
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        hitenemy = Resources.Load<AudioClip>("hitenemy");
        hitbox = Resources.Load<AudioClip>("hitbox");
        shoot = Resources.Load<AudioClip>("gun_shoot");
        jump = Resources.Load<AudioClip>("jump");
        die = Resources.Load<AudioClip>("die");
        explode = Resources.Load<AudioClip>("explode");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayHitEnemy()
    {
        music.clip = hitenemy;
        music.volume = 1f;
        music.Play();
        //Debug.Log("PlayHitEnemy");
    }
    public void PlayHitBox()
    {
        music.clip = hitbox;
        music.volume = 1f;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
    public void PlayShoot()
    {
        music.clip = shoot;
        music.volume = 0.4f;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
    public void PlayJump()
    {
        music.clip = jump;
        music.volume = 1f;
        music.Play();
        //Debug.Log("PlayHitBox");
    }
    public void PlayDie()
    {
        music.clip = die;
        music.volume = 1f;
        music.Play();
        //Debug.Log("PlayDie");
    }
    public void PlayExplode()
    {
        music.clip = explode;
        music.volume = 1f;
        music.Play();
        //Debug.Log("PlayExplode");
    }
    public bool GetEnableExplode()
    {
        return enableExplode;
    }
    public void SetEnableExplode(bool enabled)
    {
        enableExplode = enabled;
    }
}
