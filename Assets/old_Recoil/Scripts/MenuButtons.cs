using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public GameObject optionsOverlay;
    public AudioClip mouseOver, buttonClick;
    public Slider[] menuVolSlider;
    public Toggle[] menuResToggles;
    public int[] screenWidths;

    private float value;

    int activeScreenResIndex;

    public void Start()
    {
       // optionsOverlay = GameObject.Find("OptionsMenuMaster");
        optionsOverlay.SetActive(false);
    }

    public void startGame (string startGame)
    {
        SceneManager.LoadScene("BetaScene");
    }

    public void optionsMenu (string optionsMenu)
    {
        optionsOverlay.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void backToMain(string backToMain)
    {
        optionsOverlay.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSFXVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.SFX);
    }

    public void SetScreenResolution(int i)
    {
        if (menuResToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        for (int i = 0; i < menuResToggles.Length; i++)
        {
            menuResToggles[i].interactable = !isFullscreen;
        }
        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
    }


}
