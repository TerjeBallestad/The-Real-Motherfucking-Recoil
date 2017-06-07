using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class BunnyHandgun : ProjectileWeapon {

    public float recoilForce;
    private Vector3 _direction;
    private CharacterRecoil _characterRecoil;

    public override void Initialize()
    {
        base.Initialize();
        _characterRecoil = Owner.GetComponent<CharacterRecoil>();
    }

    public void GetDirection()
    {
        _direction = (transform.right * (Flipped ? 1 : -1) * recoilForce);
    }

    /// <summary>
    /// Called everytime the weapon is used
    /// </summary>
    protected override void WeaponUse()
    {
        base.WeaponUse();

        GetDirection();
        
        _characterRecoil.AddRecoil(new Vector2(_direction.x, _direction.y));
        DetermineSpawnPosition();

        /*_spawnPosition = this.transform.localPosition + this.transform.localRotation * ProjectileSpawnOffset;
        _spawnPosition = this.transform.TransformPoint (_spawnPosition);*/

        SpawnProjectile(_spawnPosition);
    }
 
}
