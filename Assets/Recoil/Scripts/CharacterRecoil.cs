using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;



public class CharacterRecoil: CharacterAbility
{
	public float MovingPlatformsJumpCollisionOffDuration = 0.05f;
	protected Vector2 _recoilForce = Vector2.zero;
	protected RecoilCharacterHorizontalMovement _movementScript;
	protected float _dampTime;

	protected override void Initialization ()
	{
		base.Initialization ();
		_movementScript = GetComponent<RecoilCharacterHorizontalMovement>(); 
	}

	public override void ProcessAbility ()
	{
		base.ProcessAbility ();
		_recoilForce = Vector2.Lerp (_recoilForce, Vector2.zero,Time.deltaTime *  _dampTime);

		if (_recoilForce != Vector2.zero) 
		{
			HandleRecoil ();
		}

		Debug.DrawLine (transform.position, transform.position - (new Vector3(_recoilForce.x,_recoilForce.y,0)*100));
	}

	public void AddRecoil(Vector2 recoil, float dampTime)
	{
		_controller.SetForce (recoil);

	}

	public void SetRecoil(Vector2 recoil, float dampTime)
	{
		_recoilForce = recoil;
		_dampTime = dampTime;
	}

	protected void HandleRecoil()
	{
		// we set the vertical force
		if ((!_controller.State.IsGrounded) || (_recoilForce.magnitude + _controller.ForcesApplied.magnitude >= 2)) {
			// if the character is standing on a moving platform and not pressing the down button,
			if ((_controller.State.IsGrounded) && (_controller.State.OnAMovingPlatform)) {					
				// we turn the boxcollider off for a few milliseconds, so the character doesn't get stuck mid air
				StartCoroutine (_controller.DisableCollisionsWithMovingPlatforms (MovingPlatformsJumpCollisionOffDuration));
				_controller.DetachFromMovingPlatform ();
			}
			_controller.SetVerticalForce (_recoilForce.y);
			_movementScript.UpdateHorizontalRecoil (_recoilForce.x * 0.1f);

		} else if (_recoilForce.magnitude + _controller.ForcesApplied.magnitude >= 20) {
			_controller.AddForce (_recoilForce * 100);
		}

	}
}
