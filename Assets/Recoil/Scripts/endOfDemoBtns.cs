using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;


public class endOfDemoBtns : MonoBehaviour {

    public void Start()
    {
        Cursor.visible = true;
    }

	public void GoHome(string MenuScene)
    {
        LoadingSceneManager.LoadScene("MenuScene");
    }

    public void exitGame(string exitGame)
    {
        Application.Quit();
    }
}
