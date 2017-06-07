using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour {

    public float test = 100f;

    void OnTriggerStay2D(Collider2D stay)
    {
        if (stay.CompareTag("Player"))
        {
            StatControl.currentHealth = StatControl.currentHealth - 50f * Time.deltaTime;
        }
        if(stay.CompareTag("Lumberjack"))
        {
            StatControl.ljCurrentHealth = StatControl.ljCurrentHealth - 50f * Time.deltaTime;
        }
        
    }
	
	void Update ()
    {
		
	}
}
