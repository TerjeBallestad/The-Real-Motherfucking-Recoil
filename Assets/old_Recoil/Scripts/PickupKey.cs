using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupKey : MonoBehaviour {
    
  

	void OnTriggerEnter2D(Collider2D o){
		if (o.tag == "Player") {
			StatControl.hasKey = true;
			Destroy (gameObject);
		}
	}
}
