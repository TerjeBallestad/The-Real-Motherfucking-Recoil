using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecoilGameManager : GameManager {

    public GameObject killTextG, killShadeG;
    public GameObject[] enemiesInScene;
    private Text killText, killShade;

    public int Kills;
    public int killObjective;


    public void OnLevelWasLoaded()
    {
        killTextG = GameObject.Find("killText");
        killShadeG = GameObject.Find("killShade");
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemies");

        killText = killTextG.GetComponent<Text>();
        killShade = killShadeG.GetComponent<Text>();

        Kills = 0;
        

        killText.text = (Kills + " / " + killObjective).ToString();
        killShade.text = (Kills + " / " + killObjective).ToString();

        
    }

    protected override void Start()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemies");
        killObjective = enemiesInScene.Length;

        killText = killTextG.GetComponent<Text>();
        killShade = killShadeG.GetComponent<Text>();

        killText.text = (Kills + " / " + killObjective).ToString();
        killShade.text = (Kills + " / " + killObjective).ToString();

    }

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
