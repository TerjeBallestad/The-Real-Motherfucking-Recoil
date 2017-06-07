using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class ShovelmanInflictDamage : MonoBehaviour {

	bool _insideHitbox = false;
	PlayerController playerScript;

	void Start(){
		playerScript = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			_insideHitbox = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			_insideHitbox = false;
		}
	}
	public void DealDamage(){
		if (_insideHitbox) {
			StatControl.currentHealth -= 50;
			playerScript.StartHurting ();
		}
	}
	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "Player") {
			GetComponentInParent<ShovelmanAI> ().Swing ();

		}
	}
}
*/