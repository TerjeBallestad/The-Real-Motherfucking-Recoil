using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour {

    public GameObject objectToSpawn;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0, 1);
	}
	
	void Spawn()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
