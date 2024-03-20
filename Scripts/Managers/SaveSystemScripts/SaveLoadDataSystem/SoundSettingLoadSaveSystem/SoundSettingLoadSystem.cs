using System;
using UnityEngine;

public class SoundSettingLoadSystem : BaseSaveSystemSoundSetting, ILoad
{
    private AudioManager _audioManager;

    public SoundSettingLoadSystem(AudioManager audioManager) : base()
    {
        _audioManager = audioManager;
    }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_soundSetting);
            _audioManager.MusicStatus = _soundSetting.musicStatus;
            _audioManager.SoundStatus = _soundSetting.soundStatus;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}