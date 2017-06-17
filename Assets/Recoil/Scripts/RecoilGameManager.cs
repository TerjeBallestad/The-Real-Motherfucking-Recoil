using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecoilGameManager : GameManager {

    public GameObject killTextG, killShadeG;
    private Text killText, killShade;

    public int Kills;
    public int killObjective;

    public void onReviveReset()
    {
        Kills = 0;
        refreshKills();
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

	public void SetKillObjective()
	{
		killObjective = 0;

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemies")) {
			killObjective++;
		}

		killText = killTextG.GetComponent<Text>();
		killShade = killShadeG.GetComponent<Text>();

		killText.text = (Kills + " / " + killObjective).ToString();
		killShade.text = (Kills + " / " + killObjective).ToString();
	}

    public virtual void refreshKills()
    {
        if (killText != null && killShade != null)
        {
            killText.text = (Kills + " / " + killObjective).ToString();
            killShade.text = (Kills + " / " + killObjective).ToString();
        }

        if (Kills >= killObjective)
        {
            Debug.Log("YOU WON - Next Level something something");
        }
    }
}
