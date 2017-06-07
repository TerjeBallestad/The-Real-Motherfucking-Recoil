using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour {

	Vector2 recoilDirection;
	float recoilForce;
	Rigidbody2D player;
	float countdown;

	void Update(){
		countdown -= Time.deltaTime;
		if (countdown <= 0) {
			gameObject.SetActive (false);
		}
	}

	void FixedUpdate (){
		
		float perc = countdown / 1;

		if (player.velocity.magnitude < 5f) {
			player.AddForce (recoilDirection * recoilForce * perc);
			Debug.Log (recoilDirection * recoilForce * perc);
		}
	}

	public void Create (Vector2 Direction,float Force, Rigidbody2D Player){
		recoilDirection = Direction;
		recoilForce = Force;
		player = Player;
		countdown = 1f;
	}
}
