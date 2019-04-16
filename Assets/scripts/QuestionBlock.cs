using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour {
    public float bounceHeight = 0.75f;
    public float bounceSpeed = 4f;
    public GameObject monsterPrefab;

    private Vector2 originalPosition;

    private bool canBounce = true;
    private Vector2 door;
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
                door = new Vector2(-8.53823f, 0.5654256f);
                Instantiate(monsterPrefab, door, transform.rotation);
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
