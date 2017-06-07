using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

	private Vector3 _spawnPoint;
    private Rigidbody2D playerRigidbody;
    private bool isAlive, checkOnce;

    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        isAlive = true;
        checkOnce = true;
		_spawnPoint = transform.position;
    }

    void Update()
    {
        if (StatControl.currentHealth <= 0 && checkOnce == true)
        {
            checkOnce = false;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            FadeScreen.Instance.Fade(true, 2);
            Invoke("moveAndHeal", 2);
        }

        if (isAlive == false & StatControl.currentHealth == StatControl.maxHealth)
        {
            FadeScreen.Instance.Fade(false, 3);
            isAlive = true;
            checkOnce = true;
        }


    }

	public void SetSpawnPoint(Vector3 T){
		_spawnPoint = T;
	}

    public void moveAndHeal()
    {
		gameObject.transform.position = _spawnPoint;
        playerRigidbody.velocity = Vector2.zero;
        StatControl.currentHealth = StatControl.maxHealth;
        StatControl.bulletCount = StatControl.clipSize;
        playerRigidbody.constraints = RigidbodyConstraints2D.None;
        isAlive = false;
    }
}
       

      
	

