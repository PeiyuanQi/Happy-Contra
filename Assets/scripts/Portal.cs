using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Portal : MonoBehaviour
{
    public GameObject pt_destination;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D trig)
    {
        trig.gameObject.transform.position = pt_destination.gameObject.transform.position;
    }
}
