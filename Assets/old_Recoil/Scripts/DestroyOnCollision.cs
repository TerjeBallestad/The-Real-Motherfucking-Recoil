using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject puff;
	public GameObject blood;


	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Bullet") {
			Destroy (col.gameObject);
			if (gameObject.name == "Shovelhead" || gameObject.name == "ShovelmanController") {
				Instantiate (blood, col.transform.position,Quaternion.identity);
			} else {
				Instantiate (puff, col.transform.position,Quaternion.identity);
			}
		}
	}
}
