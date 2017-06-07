using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip mainTheme;
    public AudioClip menuTheme;
    public static bool menuMusicPlaying, mainMusicPlaying;
     


	void Start ()
    {
       Scene currentScene = SceneManager.GetActiveScene();
       string sceneName = currentScene.name;
       mainMusicPlaying = true;
       menuMusicPlaying = false;

        

	}
	
	
	void Update ()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "BetaScene" && mainMusicPlaying == false )
        {
            AudioManager.instance.PlayMusic(mainTheme, 3);
            Debug.Log("mainTheme is playing");
            mainMusicPlaying = true;
            menuMusicPlaying = false;
        }
        if (sceneName == "MenuScene" && menuMusicPlaying == false)
        {
            AudioManager.instance.PlayMusic(menuTheme, 3);
            Debug.Log("menuTheme is playing");
            menuMusicPlaying = true;
            mainMusicPlaying = false;
        }
    }
}
