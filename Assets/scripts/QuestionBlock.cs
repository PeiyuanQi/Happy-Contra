using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour {
    public float bounceHeight = 0.75f;
    public float bounceSpeed = 4f;
    public GameObject trampoline;
    public GameObject door;
    public GameObject door_dt;
    private Vector2 originalPosition;

    private bool canBounce = true;
    private Vector2 trampoline_lc;
    private Vector2 door_st_lc;
    private Vector2 door_dt_lc;
    // Use this for initialization
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void QuestionBlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;
            StartCoroutine("Bounce");
        }
    }

    IEnumerator Bounce()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x,
                                                   transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
            {
                trampoline_lc = new Vector2(-8.53823f, 0.5654256f);
                door_st_lc = new Vector2(-3.79f, 11.86f);
                door_dt_lc = new Vector2(251.2696f, 3.524225f);
                Instantiate(trampoline, trampoline_lc, transform.rotation);
                Instantiate(door, door_st_lc, transform.rotation);
                Instantiate(door_dt, door_dt_lc, transform.rotation);
                break;
            }
            yield return null;
        }
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x,
                                                   transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y <= originalPosition.y)
            {
                transform.localPosition = originalPosition;
                break;
            }
            yield return null;
        }
    }
}
