using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;



public class CharacterRecoil: CharacterAbility
{
	protected float DampTime;
	protected Vector2 _recoilDirecetion;

	void Update ()
	{

		_recoilDirecetion  = Vector2.Lerp(_recoilDirecetion, Vector2.zero, Time.deltaTime * DampTime);

		if (_recoilDirecetion != Vector2.zero) {
			_controller.AddForce (_recoilDirecetion);
		} else {
			_controller.SlowFall (1);
		}

	}

	public void AddRecoil(Vector2 direction, float dampTime)
    {
		_recoilDirecetion = direction;
		DampTime = dampTime;
		_controller.SlowFall (0.7f);

    }
	void OnTriggerStay2d(){
		_recoilDirecetion = Vector2.zero;
	}

}
