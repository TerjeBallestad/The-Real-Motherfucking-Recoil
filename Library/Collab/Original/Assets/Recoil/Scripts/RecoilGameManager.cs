using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.UI;

public class RecoilGameManager : GameManager {

    private GameObject killTextG, killShadeG;
    private Text killText, killShade;

    public int Kills { get; private set; }
    public int killObjective { get; private set; }


    protected void Start()
    {
		setKills (0);

    }

    public virtual void addKills(int killsToAdd)
    {
        Kills += killsToAdd;
        refreshKills();
    }

    public virtual void setKills(int kills)
    {
        Kills = kills;
        refreshKills();
    }

    public virtual void refreshKills()
    {
		killTextG = GameObject.Find ("killText");
		killShadeG = GameObject.Find ("killShade");
	
        if (killText != null && killShade != null)
        {
			killText = killTextG.GetComponent<Text> ();
			killShade = killShadeG.GetComponent<Text> ();

            killText.text = (Kills + " / " + killObjective).ToString();
            killShade.text = (Kills + " / " + killObjective).ToString();
        }
    }
}
