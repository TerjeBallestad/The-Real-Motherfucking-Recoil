using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D o)

    {
		if (o.tag == "Player" && StatControl.hasKey == true) {
			Debug.Log ("You fucking win, congratulations");
		}
    }

   
}
