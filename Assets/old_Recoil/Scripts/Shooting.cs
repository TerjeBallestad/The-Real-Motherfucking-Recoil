using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public float bulletSpeed, shotFrequency, reloadTime,recoilForce;
	float timeToReload, timeSinceLastShot, defaultGravity;
	public static bool reloadTimeFinished, canShoot = true;

	public AudioClip gunshotSound;
	public AudioClip reloadSound;

	public GameObject projectile;
	public GameObject recoil;
	public GameObject shootPuffs;

	[HideInInspector]
	public Vector2 recoilDirection;
	GunRotation rotationScript;
	PlayerController playerScript;
	Rigidbody2D bunnyBody;





	void Start(){
		bunnyBody = transform.root.GetComponent<Rigidbody2D>();
		timeSinceLastShot = shotFrequency;
		StatControl.bulletCount = StatControl.clipSize;
		rotationScript = transform.parent.parent.GetComponent<GunRotation> ();
		playerScript = transform.parent.parent.parent.GetComponent<PlayerController> ();
		defaultGravity = bunnyBody.gravityScale;
	}

	void Update(){
		
		recoilDirection = Quaternion.AngleAxis (rotationScript.angle, Vector3.forward) * Vector2.right;


		if (timeSinceLastShot < 10){
			timeSinceLastShot += Time.deltaTime;
		}
		if (StatControl.bulletCount <= 0) {
			canShoot = false;
			if (playerScript.grounded == true) {
					StartCoroutine ("Reload");
				}
			}


		if (Input.GetButton ("Fire1") && shotFrequency <= timeSinceLastShot) {
			Shoot ();
//            AudioManager.instance.PlaySound(gunshotSound, transform.position);
	
		}

		if (Input.GetButtonDown("Fire3") && StatControl.bulletCount < StatControl.clipSize){
				StartCoroutine ("Reload");
		}
//		if (timeSinceLastShot < shotFrequency) bunnyBody.gravityScale = 1f;
//		else if (timeSinceLastShot < defaultGravity && !playerScript.grounded) bunnyBody.gravityScale = timeSinceLastShot;
	
	
	}

	void FixedUpdate(){
		
	}
		
	void Shoot (){
		if (canShoot) {
			SpawnBullet ();
			ApplyRecoil ();
			timeSinceLastShot = 0;
		}
	}

	void SpawnBullet(){
		Instantiate (shootPuffs, transform.position, transform.rotation);
		GameObject instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation);
		Rigidbody2D projectileRB = instantiatedProjectile.GetComponent<Rigidbody2D> ();
		projectileRB.velocity = transform.TransformDirection (new Vector3 (bulletSpeed, 0, 0));
		StatControl.bulletCount--;
	}
	void ApplyRecoil(){
		playerScript.recoilVector = (recoilDirection * -recoilForce);
		playerScript.shooting = true;
		playerScript.velocity = Vector2.zero;
		timeSinceLastShot = 0f;
	}
		
	IEnumerator Reload(){
            //AudioManager.instance.PlaySound(reloadSound, transform.position);
			yield return new WaitForSeconds (reloadTime);
			StatControl.bulletCount = StatControl.clipSize;
			canShoot = true;

	}
}
