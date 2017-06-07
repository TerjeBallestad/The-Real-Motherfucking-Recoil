using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillontouchSC : MonoBehaviour


{
   
    public Transform RespawnPoint;


    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        other.gameObject.transform.position = RespawnPoint.position;
    }
}

