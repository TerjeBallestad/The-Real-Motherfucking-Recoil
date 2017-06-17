using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecoilLevelManager : LevelManager {

	public GameObject _killTextG, _killShadeG;
	private Text _killText, _killShade;

	private int _kills;
	private int _killObjective;
	public string NextScene;


	protected override void Initialization ()
	{
		base.Initialization ();
		SetKillObjective();
		RefreshKills ();
	}

	protected override IEnumerator SoloModeRestart ()
	{
		return base.SoloModeRestart ();
		OnReviveReset ();
	}

	public void OnReviveReset()
	{
		_kills = 0;
		SetKillObjective ();
		RefreshKills();
	}

	public virtual void AddKills(int killsToAdd)
	{
		_kills += killsToAdd;
		RefreshKills();
	}

	public virtual void SetKills(int kills)
	{
		_kills = kills;
		RefreshKills();
	}

	public void SetKillObjective()
	{
		_killObjective = 0;

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemies")) {
			_killObjective++;
		}

		_killText = _killTextG.GetComponent<Text>();
		_killShade = _killShadeG.GetComponent<Text>();

		RefreshKills ();
	}

	public virtual void RefreshKills()
	{
		if (_killText != null && _killShade != null)
		{
			_killText.text = (_kills + " / " + _killObjective).ToString();
			_killShade.text = (_kills + " / " + _killObjective).ToString();
		}

		if (_kills >= _killObjective)
		{
			if (NextScene != null) {
				LoadingSceneManager.LoadScene (NextScene);
			}
		}
	}
}
