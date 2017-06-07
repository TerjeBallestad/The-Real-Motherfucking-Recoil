using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPools : MonoBehaviour {

	void OnTriggerStay2D(Collider2D stay)
    {
        if (stay.CompareTag("Player"))
        {
            StatControl.currentHealth = StatControl.currentHealth - 100f;
        }
    }
}
