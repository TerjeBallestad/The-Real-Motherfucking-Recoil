using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class ShovelmanAI : MonoBehaviour {

	public Transform target;

	public float updateRate = 2f;

	private Seeker _seeker;
	private Rigidbody2D _rb;

	public Path path;

	public float speed = 300f;
	public ForceMode2D fmode;

	[HideInInspector]
	public bool pathIsEnded = false, _dead = false, _grounded = false, _triggered = false;


	public float nextWaypointDistance = 3;

	private int currentWaypoint;

	public float groundRadius;
	public LayerMask whatIsGround;

	SpriteRenderer _sprite;
	bool _swinging = false;
	float _swingTime;

	public GameObject bloodFountain;
	Rigidbody2D _headRB;
	Rigidbody2D _shovelRB;
	public Sprite deadSprite;
	Transform _bodyT;
	Animator _bodyAnim;

	public GameObject key;
	bool _keySpawned;

	// Use this for initialization
	void Start () {
		_bodyT = transform.GetChild(0);

		_headRB = transform.GetChild (1).GetComponent<Rigidbody2D>();
		_shovelRB = transform.GetChild (2).GetComponent<Rigidbody2D>();
		_seeker = GetComponent<Seeker> ();
		_rb = GetComponent<Rigidbody2D> ();
		_sprite = _bodyT.GetComponent<SpriteRenderer> ();
		_bodyAnim = _bodyT.GetComponent<Animator>();

        StatControl.smCurrentHealth = StatControl.smMaxHealth;

		if (target == null) {
			Debug.LogError ("No Player found");
			return;
		}


		_seeker.StartPath (transform.position, target.position, OnPathComplete);


		StartCoroutine (UpdatePath ());
	}
	void OnCollisionEnter2D(Collision2D o){
		if (o.gameObject.tag == "Bullet") {
			StatControl.smCurrentHealth -= 20f;
			if(StatControl.smCurrentHealth <= 0 && !_dead){
				Death();
			}
			Debug.Log ("im dai-eing");
			Destroy (o.gameObject);
		}

	}

	void Update (){
		_grounded = Physics2D.OverlapCircle(transform.position, groundRadius, whatIsGround);
		_bodyAnim.SetFloat ("Speed", _rb.velocity.x * _rb.velocity.x);
		if (_grounded && _dead) {
			_rb.velocity = Vector2.zero;
			GetComponent<BoxCollider2D>().enabled = false;
			_bodyAnim.SetBool ("Dead", true);
		}
		if (_swinging) {
			_swingTime += Time.deltaTime;
			if (_swingTime > 2) {
				_swinging = false;
				_swingTime = 0;
			}
		}



			
	}
	
	

	IEnumerator UpdatePath(){
		if (_dead) {
			yield break;
		}
		if (target == null) {
			//TODO: Insert player search here.
			yield return null;
		}

		_seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1 / updateRate);
		StartCoroutine (UpdatePath ());
	}
	

	public void OnPathComplete (Path p){
//		Debug.Log ("Got a Path " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}


    void FixedUpdate() {
		if (_dead || _swinging || !_triggered) {
            return;
        }

		if (!_grounded) {
			speed = 100f;
			_bodyAnim.speed = 0.1f;
		} else {
			_bodyAnim.speed = 1;
		}

        if (target == null) {
            //TODO: Insert Player search here.
            return;
        }
        if (_rb.velocity.x > 1f)
            transform.localScale = new Vector3(1, 1, 1);
 
        fmode = ForceMode2D.Force;
        speed = 2000;

 
        if (_rb.velocity.x < -1f)
            transform.localScale = new Vector3(-1, 1, 1);
        fmode = ForceMode2D.Force;
        speed = 2000;

        if (_rb.velocity.x == 0)
        {
            speed = 200;
            fmode = ForceMode2D.Impulse;
        }


        if (path == null) 
			return;
		
		if (currentWaypoint >= path.vectorPath.Count){
			if(pathIsEnded)
				return;

			Debug.Log ("End of path reched.");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;

		dir *= speed * Time.fixedDeltaTime;

		_rb.AddForce (new Vector3(dir.x,0,0), fmode);

		_headRB.gameObject.SetActive (true);
		_shovelRB.gameObject.SetActive (true);

		float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
			
		Debug.DrawLine(transform.position, dir,Color.cyan);
		}
	


	void Death(){
		_dead = true;
		_headRB.gameObject.SetActive (true);
		_shovelRB.gameObject.SetActive (true);

		_shovelRB.bodyType = RigidbodyType2D.Dynamic;
		_headRB.bodyType = RigidbodyType2D.Dynamic;
		SpawnFountain ();

		StatControl.shovelmenKilled++;

		if (StatControl.shovelmenKilled >= 3 && !_keySpawned) {
			Instantiate (key, transform.position, Quaternion.identity);
			_keySpawned = true;
		}

		Debug.Log (_sprite.sprite);

	}

	public void SpawnFountain(){
		GameObject fountain = (GameObject)Instantiate (bloodFountain, gameObject.transform);

		if (transform.localScale.x == -1) {

			fountain.transform.GetChild(0).localScale = new Vector3(-1,-1,1);
		}
	}

	public void Swing(){
		if (!_dead) {
			_headRB.gameObject.SetActive (false);
			_shovelRB.gameObject.SetActive (false);
			_bodyAnim.SetTrigger ("Swing");
			_swinging = true;
			_swingTime = 0;
		}
	}
	public void Trigger(){
		StartCoroutine ("GetTriggered");
	}

	IEnumerator GetTriggered(){
		_bodyAnim.SetBool ("Triggered", true);
		yield return new WaitForSeconds(1);
		_triggered = true;
	}

}
*/