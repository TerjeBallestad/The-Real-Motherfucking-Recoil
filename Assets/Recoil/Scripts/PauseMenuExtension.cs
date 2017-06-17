using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.CorgiEngine;

public class PauseMenuExtension : LevelSelector {
    public GameObject optionsMenu;
    public GameObject resBtn, restartBtn, optionsBtn, returnBtn;

    public void Start()
    {
        optionsMenu.SetActive(false);
    }

	public void toOptions()
    {
        optionsMenu.SetActive(true);
        resBtn.SetActive(false);
        restartBtn.SetActive(false);
        optionsBtn.SetActive(false);
        returnBtn.SetActive(false);
    }

    public void backFromOptions()
    {
        optionsMenu.SetActive(false);
        resBtn.SetActive(true);
        restartBtn.SetActive(true);
        optionsBtn.SetActive(true);
        returnBtn.SetActive(true);
    }

    public void backToMain(string MenuScene)
    {
        LoadingSceneManager.LoadScene("MenuScene");
    }
/*
    public void Update()
    {
        if (GameManager.Instance.Paused == true)
        {
            Cursor.visible = true;
        }

        else if (GameManager.Instance.Paused == false)
        {
            Cursor.visible = false;
        }
    }
    */
}
