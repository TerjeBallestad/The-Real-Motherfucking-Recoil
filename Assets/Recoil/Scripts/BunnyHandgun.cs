using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class BunnyHandgun : ProjectileWeapon {

    public float recoilForce;
    private Vector3 _recoilDirection;
    private CharacterRecoil _characterRecoil;

    public override void Initialize()
    {
        base.Initialize();
        _characterRecoil = Owner.GetComponent<CharacterRecoil>();
    }

    public void GetRecoilDirection()
    {
		_recoilDirection = (transform.right * (Flipped ? 1 : -1) * recoilForce);
    }
		

    /// <summary>
    /// Called everytime the weapon is used
    /// </summary>
    protected override void WeaponUse()
    {
        base.WeaponUse();

        GetRecoilDirection();
        
        _characterRecoil.AddRecoil(new Vector2(_recoilDirection.x, _recoilDirection.y), 10);
        DetermineSpawnPosition();

        /*_spawnPosition = this.transform.localPosition + this.transform.localRotation * ProjectileSpawnOffset;
        _spawnPosition = this.transform.TransformPoint (_spawnPosition);*/

        SpawnProjectile(_spawnPosition);
    }
 
}
