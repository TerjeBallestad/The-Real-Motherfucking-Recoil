using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroyer : MonoBehaviour {

	public float TimeToDestruction;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, TimeToDestruction);
	}
	

}
