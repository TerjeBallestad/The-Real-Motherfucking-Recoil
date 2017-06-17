using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class RecoilCharacterHorizontalMovement : CharacterHorizontalMovement {

	private float _horizontalRecoil;

	public void UpdateHorizontalRecoil(float amount){
		_horizontalRecoil = amount;
	}

	protected override void HandleHorizontalMovement ()
	{
			// if we're not walking anymore, we stop our walking sound
			if (_movement.CurrentState != CharacterStates.MovementStates.Walking && _abilityInProgressSfx != null)
			{
				StopAbilityUsedSfx();
			}

			// if movement is prevented, or if the character is dead/frozen/can't move, we exit and do nothing
			if ( !AbilityPermitted
				|| (_condition.CurrentState != CharacterStates.CharacterConditions.Normal)
				|| (_movement.CurrentState == CharacterStates.MovementStates.Gripping) )
			{
				return;				
			}

			// check if we just got grounded
			CheckJustGotGrounded();

			// If the value of the horizontal axis is positive, the character must face right.
			if (_horizontalMovement>0.1f)
			{
				_normalizedHorizontalSpeed = _horizontalMovement;
				if (!_character.IsFacingRight)
					_character.Flip();
			}		
			// If it's negative, then we're facing left
			else if (_horizontalMovement<-0.1f)
			{
				_normalizedHorizontalSpeed = _horizontalMovement;
				if (_character.IsFacingRight)
					_character.Flip();
			}
			else
			{
				_normalizedHorizontalSpeed=0;
			}

			// if we're grounded and moving, and currently Idle, Running or Dangling, we become Walking
			if ( (_controller.State.IsGrounded)
				&& (_normalizedHorizontalSpeed != 0)
				&& ( (_movement.CurrentState == CharacterStates.MovementStates.Idle)
					|| (_movement.CurrentState == CharacterStates.MovementStates.Dangling) ))
			{				
				_movement.ChangeState(CharacterStates.MovementStates.Walking);	
				PlayAbilityStartSfx();	
				PlayAbilityUsedSfx();		
			}

			// if we're walking and not moving anymore, we go back to the Idle state
			if ((_movement.CurrentState == CharacterStates.MovementStates.Walking) 
				&& (_normalizedHorizontalSpeed == 0))
			{
				_movement.ChangeState(CharacterStates.MovementStates.Idle);
				PlayAbilityStopSfx();
			}

			// if the character is not grounded, but currently idle or walking, we change its state to Falling
			if (!_controller.State.IsGrounded
				&& (
					(_movement.CurrentState == CharacterStates.MovementStates.Walking)
					|| (_movement.CurrentState == CharacterStates.MovementStates.Idle)
				))
			{
				_movement.ChangeState(CharacterStates.MovementStates.Falling);
			}

			// we pass the horizontal force that needs to be applied to the controller.
			float movementFactor = _controller.State.IsGrounded ? _controller.Parameters.SpeedAccelerationOnGround : _controller.Parameters.SpeedAccelerationInAir;
			float movementSpeed = _normalizedHorizontalSpeed * MovementSpeed * _controller.Parameters.SpeedFactor;
			float newHorizontalForce;

			newHorizontalForce = Mathf.Lerp(_controller.Speed.x, movementSpeed , Time.deltaTime * movementFactor);
			
			newHorizontalForce += _horizontalRecoil;
			// we handle friction
			newHorizontalForce = HandleFriction(newHorizontalForce);

			// we set our newly computed speed to the controller
			_controller.SetHorizontalForce(newHorizontalForce);
		}
}
