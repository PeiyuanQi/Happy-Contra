using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject bridge3;
    public GameObject bridge4;

    public GameObject player;
    public BoxCollider2D bridgeActivator;
    public GameObject bridgeExplosionPrefab;

    public bool exist = true; //bridge still exists?
    private GameObject sound;
    private PlaySound play;


    // Use this for initialization
    void Start () {
        exist = true;
        sound = GameObject.Find("Sound");
        play = sound.GetComponent<PlaySound>();
    }
	
	// Update is called once per frame
	void Update () {
        if (exist) {
            if (player.transform.position.x > (bridgeActivator.bounds.center.x - bridgeActivator.bounds.size.x/2))
            {
                BridgeExplosion();
                exist = false;
            }
        }
    }

    void BridgeExplosion()
    {
        Destroy(bridgeActivator);
        StartCoroutine(BridgeBlockExplosion(bridge1, 0));
        StartCoroutine(BridgeBlockExplosion(bridge2, 0.3f));
        StartCoroutine(BridgeBlockExplosion(bridge3, 0.6f));
        StartCoroutine(BridgeBlockExplosion(bridge4, 1.2f));
    }

    IEnumerator BridgeBlockExplosion(GameObject block, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(play.GetEnableExplode())play.PlayExplode();
        //block.SetActive(false);
        GameObject exp = Instantiate(bridgeExplosionPrefab, block.transform.position, Quaternion.identity);
        Destroy(block);
        Destroy(exp, 0.3f);
    }
}
