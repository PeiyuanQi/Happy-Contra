using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoSlider : MonoBehaviour, IEndDragHandler,IPointerClickHandler
{

    public Slider mSlider;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        mSlider.value = 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mSlider.value = 1;
    }
}
