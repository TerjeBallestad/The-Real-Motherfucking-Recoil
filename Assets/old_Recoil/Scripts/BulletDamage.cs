using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D bulletHit)
    {
        if (bulletHit.gameObject.tag == "Lumberjack")
        {
            StatControl.ljCurrentHealth = StatControl.ljCurrentHealth - 10f;
        }
    }
}
