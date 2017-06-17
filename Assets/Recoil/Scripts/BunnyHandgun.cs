using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class BunnyHandgun : ProjectileWeapon {

    public float RecoilForce;
	public float DampTime;
	private Vector2 _direction;
	private Vector2 _recoil;
    private CharacterRecoil _characterRecoil;
	private RecoilWeaponAmmo _ammoScript;
	private CorgiController _controller;

    public override void Initialize()
    {
        base.Initialize();
        _characterRecoil = Owner.GetComponent<CharacterRecoil>();
		_ammoScript =  GetComponent<RecoilWeaponAmmo> ();
		_controller = Owner.GetComponent<CorgiController> ();
    }

    public void GetRecoilDirection()
    {
		_direction = (transform.right * (Flipped ? 1 : -1));
    }
		
    /// <summary>
    /// Called everytime the weapon is used
    /// </summary>
    protected override void WeaponUse()
    {
		if (_ammoScript.CurrentAmmo > 0) {
			base.WeaponUse ();

			GetRecoilDirection ();

			_recoil = _direction * RecoilForce;
        
			_characterRecoil.AddRecoil (_recoil, DampTime);

			if (_controller.State.IsGrounded && _ammoScript.CurrentAmmo == 1) {
				_ammoScript.StartReloading ();
			}

			DetermineSpawnPosition ();

			/*_spawnPosition = this.transform.localPosition + this.transform.localRotation * ProjectileSpawnOffset;
       		 _spawnPosition = this.transform.TransformPoint (_spawnPosition);*/

			SpawnProjectile (_spawnPosition);

			_ammoScript.DecreaseAmmoBy (1);

            _ammoScript.updateAmmo(_ammoScript.CurrentAmmo, _ammoScript.MagazineSize);
		} 
    }
 
}
