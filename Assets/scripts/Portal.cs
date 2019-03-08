using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Portal : MonoBehaviour
{
    public GameObject pt_1, pt_2;
    // Use this for initialization
    void Start()
    {
        pt_1 = this.gameObject;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D trig)
    {
        trig.gameObject.transform.position = pt_2.gameObject.transform.position;
    }
}
