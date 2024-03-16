using System;
using UnityEngine;

public class SoundSettingSaveSystem : BaseSaveSystemSoundSetting
{
    public SoundSettingSaveSystem(AudioManager audioManager) : base(audioManager) { }

    public void SaveSoundData()
    {
        try
        {
            _soundSetting.musicStatus = _audioManager.MusicStatus;
            _soundSetting.soundStatus = _audioManager.SoundStatus;
            _saveSystem.Save(_soundSetting);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }
}