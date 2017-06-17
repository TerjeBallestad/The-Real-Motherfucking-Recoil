using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class RecoilHealth : Health {

    public int killsWhenDestroyed;
	private RecoilLevelManager _levelManager;
    private GameObject tempManager;

    protected override void Start()
    {
        base.Start();
        tempManager = GameObject.Find("LevelManager");
		_levelManager = tempManager.GetComponent<RecoilLevelManager>();
    }

    public override void Kill()
	{
		base.Kill ();

		if (killsWhenDestroyed != 0) {
			_levelManager.AddKills (killsWhenDestroyed);
		}
	}

}
