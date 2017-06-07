using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public GameObject jumpPuff;
	public GameObject runPuff;
	public float health;


	[HideInInspector]
	public bool shooting;

	private bool flipSprite;
	private bool hasRunPuffed = false;
	private SpriteRenderer spriteRenderer;
	private SpriteRenderer gunSprite;
	private Animator animator;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		gunSprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator> ();
	}
		

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if ((move.x >= 0.5f || move.x <= -0.5f) && !hasRunPuffed  && grounded) {
			GameObject puff = (GameObject)Instantiate (runPuff, transform.position, Quaternion.identity);
			puff.GetComponent<SpriteRenderer> ().flipX = spriteRenderer.flipX;
			hasRunPuffed = true;
		}

		if (move.x == 0) {
			hasRunPuffed = false;
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
			Instantiate (jumpPuff,transform.position,Quaternion.identity);
			hasRunPuffed = false;

		} else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		flipSprite = (spriteRenderer.flipX ? (move.x > 0f) : (move.x < 0f));
		if (flipSprite) 
		{	
			spriteRenderer.flipX = !spriteRenderer.flipX;
			gunSprite.flipY = !gunSprite.flipY;

		}
		health = StatControl.currentHealth;
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
		animator.SetFloat ("velocityY", velocity.y);

		recoilVector = Vector2.Lerp(recoilVector, Vector2.zero, Time.deltaTime * 3);

		targetVelocity = move * maxSpeed;
	}

	public void StartHurting(){
		StartCoroutine ("Hurt");

	}
		
	IEnumerator Hurt (){
		animator.SetBool ("Hurt", true);
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.freezeRotation = false;

		yield return new WaitForSeconds (1);
		animator.SetBool ("Hurt", false);
		rb.freezeRotation = true;
	}
}