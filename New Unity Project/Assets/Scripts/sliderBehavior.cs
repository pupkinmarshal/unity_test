using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class sliderBehavior : MonoBehaviour, IEndDragHandler
{

    private Slider me;

    void Awake()
    {
        me = gameObject.GetComponent<Slider>();
    }


    public void OnEndDrag(PointerEventData data)
    {
        //print("eh");
        me.value = 0f;
    }
}
