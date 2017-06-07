using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour {

    public float turretRange = 8f;
    public Transform turretTarget;
    public GameObject turretRotation;

    private Transform rotationTransform;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        rotationTransform = turretRotation.GetComponent<Transform>();
	}
    
    void UpdateTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= turretRange)
        {
            turretTarget = player.transform;
        }
        else
        {
            turretTarget = null;
        }

    }
	
	void Update ()
    {
        if (turretTarget == null)
            return;

        Vector3 dir = turretTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationTransform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationTransform.rotation = Quaternion.Euler(0f, 0f, rotation.z);

        //turretRotation.Rotate(0f, 0f, rotation.z);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Shoot()
    {
        Debug.Log("I am shooting");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
