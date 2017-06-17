using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class RecoilCheckpoint : CheckPoint {

	private RecoilLevelManager _levelManagerScript;
	private GameObject _levelManager;
	protected Animator _anim;
	protected GameObject _bunny;
	protected bool _portraitTagged = false;

	void Start(){
		_levelManager = GameObject.Find("LevelManager");
		_levelManagerScript = _levelManager.GetComponent<RecoilLevelManager> ();
		_anim = GetComponent<Animator> ();
	}

	public override void SpawnPlayer (Character player)
	{
		base.SpawnPlayer (player);
		if (_levelManagerScript != null)
		{
			_levelManagerScript.OnReviveReset ();
		}
	}

	protected override void OnTriggerEnter2D (Collider2D collider)
	{	
		if (collider.tag == "Player" && !_portraitTagged) {
			base.OnTriggerEnter2D (collider);
			_anim.SetTrigger ("Tag");
			_bunny = collider.gameObject;
			_bunny.SetActive (false);
			_portraitTagged = true;
		}

	}
	public void EnableSprite(){
		_bunny.SetActive (true); 
	}
}
