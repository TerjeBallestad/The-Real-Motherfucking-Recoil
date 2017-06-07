using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPill : MonoBehaviour {

    public float respawnTime = 10f;
    public static bool active;
    public float timer;

    private Collider2D col;


    public void Start()
    {
        active = true;
        col = GetComponentInChildren<Collider2D>();
        StartCoroutine(pillSpawn(5));
    }

	public void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.CompareTag("Player") && active == true && StatControl.currentHealth != StatControl.maxHealth)
        {
            Debug.Log ("Collision");
            StatControl.currentHealth = StatControl.currentHealth + 30f;
            active = false;
            col.gameObject.SetActive(false);
            StartCoroutine(pillSpawn(3));
            
        }
    }

    //Respawn not working because when the object is deactivated, it does not run the rest of the code. Problem. Send help.

    IEnumerator pillSpawn(float spawnTimer)
    {
        while (active == false)
        {
            yield return new WaitForSeconds(spawnTimer);
            col.gameObject.SetActive(true);
            active = true;
            print("hello world");
            yield return null;
        }
        
    }
}
