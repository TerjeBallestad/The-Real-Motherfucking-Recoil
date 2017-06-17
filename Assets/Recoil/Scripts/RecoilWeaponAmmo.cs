using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

public class RecoilWeaponAmmo : WeaponAmmo {

	public float ReloadTime;
	public AudioClip ReloadStartSFX;
	public AudioClip ReloadFinishedSFX;
    public GameObject skuddTekst, skuddShade;
    private Text ammoTekst, ammoSkygge;

	private Character _owner;
	private CorgiController _controller;
	private Weapon _equippedWeapon;
	private CharacterHandleWeapon _handleWeaponScript;
    private InputManager _inputManager;

	private void OnEnable(){
		CurrentAmmo = MagazineSize;
	}

	private void Start(){
		_equippedWeapon = GetComponent<Weapon> ();
		_owner = _equippedWeapon.Owner;
		_controller = _owner.GetComponent<CorgiController> ();
		_handleWeaponScript = _owner.GetComponent<CharacterHandleWeapon> ();

        skuddTekst = GameObject.Find("AmmoText");
        skuddShade = GameObject.Find("AmmoText (1)");
        ammoTekst = skuddTekst.GetComponent<Text>();
        ammoSkygge = skuddShade.GetComponent<Text>();
        
    }

	private void Update()
    {
        if (_owner.LinkedInputManager.ReloadButton.State.CurrentState == MMInput.ButtonStates.ButtonDown && _controller.State.IsGrounded)
        {
            StartCoroutine("Reload");
        }

        if (_controller.State.JustGotGrounded && CurrentAmmo <= 0) {
			StartCoroutine ("Reload");
		}
		if (!_controller.State.IsGrounded) {
			StopCoroutine ("Reload");
			updateAmmo (CurrentAmmo, MagazineSize);
		}
	}

    public void updateAmmo(int CurrentAmmo, int MagazineSize)
    {
        ammoTekst.text = (CurrentAmmo + "/" + MagazineSize).ToString();
        ammoSkygge.text = (CurrentAmmo + "/" + MagazineSize).ToString();
    }

    public void StartReloading()
	{
		StartCoroutine ("Reload");
	}

	public void DecreaseAmmoBy(int amount)
	{
		CurrentAmmo = CurrentAmmo - amount;
	}

	IEnumerator Reload()
	{
		if (_controller.State.IsGrounded) {
			_handleWeaponScript.ShootStop ();
            if (CurrentAmmo <= 0)
            {
                _handleWeaponScript.AbilityPermitted = false;
            }
			SfxPlayReloadStartSound ();
			SetAmmoTextToReload ();
			Debug.Log ("started to reload");
			yield return new WaitForSeconds(ReloadTime);

			CurrentAmmo = MagazineSize;
			_handleWeaponScript.AbilityPermitted = true;
			Debug.Log ("finished reloading");
			SfxPlayReloadFinishedSound ();
            updateAmmo(CurrentAmmo, MagazineSize);
		}
	}

	protected void SetAmmoTextToReload(){
		ammoTekst.text = "Reloading";
		ammoSkygge.text = "Reloading";
	}

	protected virtual void SfxPlayReloadStartSound()
	{
		if (ReloadStartSFX!=null) {	SoundManager.Instance.PlaySound(ReloadStartSFX,transform.position);	}
	}

	protected virtual void SfxPlayReloadFinishedSound()
	{
		if (ReloadFinishedSFX!=null) {	SoundManager.Instance.PlaySound(ReloadFinishedSFX,transform.position);	}
	}

}
