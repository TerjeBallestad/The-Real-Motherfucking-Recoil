using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonSounds : MonoBehaviour, IPointerEnterHandler
{

    public AudioClip mouseOver, buttonClick;

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Entered");
        //AudioManager.instance.PlaySound(mouseOver, transform.position);
       
    }
}
