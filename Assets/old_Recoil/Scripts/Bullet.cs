using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject puff;
	public GameObject blood;

	void Start () {
		Destroy (gameObject, 3f);
	}

	void OnCollisionEnter2D(Collision2D col){
		
			
		if (col.gameObject.name == "Shovelhead" || col.gameObject.name == "ShovelmanController") {
			Instantiate (blood, transform.position, Quaternion.identity);
		} else {
			Instantiate (puff, transform.position, Quaternion.identity);
		}

		Destroy (gameObject);

	}


}
