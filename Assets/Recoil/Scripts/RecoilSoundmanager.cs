using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class RecoilSoundmanager: SoundManager {

    public float masterVolume;

    public void AdjustMasterVolume(float newMasterVolume)
    {
        newMasterVolume = masterVolume;
    }

	public void AdjustMusicVolume(float newMusicVolume)
    {
        _backgroundMusic.volume = newMusicVolume;
        PlayerPrefs.SetFloat("musicVolume", newMusicVolume);
    }

    public void AdjustSfxVolume (float newSfxVolume)
    {
        SfxVolume = newSfxVolume;
        PlayerPrefs.SetFloat("SfxVolume", newSfxVolume);
    }

}
