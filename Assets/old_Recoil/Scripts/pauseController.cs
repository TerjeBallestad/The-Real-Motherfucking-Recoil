using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseController : MonoBehaviour {

    public GameObject pauseMenuOverlay, spawnPosition, playerTransform, optionsMenu, videoMenu;
    public static bool isPauseActive = true;
    private Rigidbody2D playerRigidbody;

    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenWidths;
    int activeScreenResIndex;

    void Start ()
    {
        pauseMenuOverlay.SetActive(false);
        videoMenu.SetActive(false);
        isPauseActive = false;
        playerRigidbody = playerTransform.GetComponent<Rigidbody2D>();
    }
	
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape) && isPauseActive == false)
        {
            Debug.Log("Escape pressed - should open pause window");
            pauseMenuOverlay.SetActive(true);
            isPauseActive = true;
            Shooting.canShoot = false;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPauseActive == true)
        {
            Debug.Log("Escape pressed - should close pause window");
            pauseMenuOverlay.SetActive(false);
            isPauseActive = false;
            Shooting.canShoot = true;
        }
    }

    public void resumeGame(string resumeGame)
    {
        pauseMenuOverlay.SetActive(false);
        isPauseActive = false;
    }

    public void respawnCheckpoint(string respawnCheckpoint)
    {
        playerTransform.transform.position = spawnPosition.transform.position;
        playerRigidbody.velocity = Vector2.zero;
        StatControl.currentHealth = StatControl.maxHealth;
        pauseMenuOverlay.SetActive(false);
        isPauseActive = false;
    }

    public void videoOptions (string videoOptions)
    {
        optionsMenu.SetActive(false);
        videoMenu.SetActive(true);
    }

    public void videoBack (string videoBack)
    {
        optionsMenu.SetActive(true);
        videoMenu.SetActive(false);
    }

    public void toMenu(string toMenu)
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SetScreenResolution (int i)
    {
        if(resolutionToggles [i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
        }
    }

    public void SetFullscreen (bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullscreen;
        }
        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions [allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
    }

    public void SetMasterVolume (float value)
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

}
