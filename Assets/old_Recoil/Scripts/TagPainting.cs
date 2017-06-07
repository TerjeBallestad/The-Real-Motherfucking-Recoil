using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPainting : MonoBehaviour {

	Animator _anim;
	GameObject _bunny;
	bool _notTagged = true;
	PlayerDeath _deathScript;

	void Start(){
		_anim = GetComponent<Animator> ();
		_deathScript = FindObjectOfType<PlayerDeath> ();
	}

	void OnTriggerStay2D(Collider2D o){
		if (Input.GetKey (KeyCode.E ) && o.tag == "Player" && _notTagged) {
			_bunny = o.transform.gameObject;
			_bunny.SetActive(false);
			_anim.SetTrigger ("Tag");
			_notTagged = false;
			_deathScript.SetSpawnPoint (transform.position);
		}
	}

	public void ActivateBunny(){
		_bunny.SetActive (true);
	}

}
