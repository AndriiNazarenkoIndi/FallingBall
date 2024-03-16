using System;
using UnityEngine;

public class SoundSettingLoadSystem : BaseSaveSystemSoundSetting, ILoad
{
    public SoundSettingLoadSystem(AudioManager audioManager) : base(audioManager) { }

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