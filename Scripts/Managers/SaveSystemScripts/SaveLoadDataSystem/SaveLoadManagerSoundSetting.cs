using UnityEngine;

public class SaveLoadManagerSoundSetting : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    private SoundSettingSaveSystem _soundSettingSaveSystem;
    private SoundSettingLoadSystem _soundSettingLoadSystem;

    private void Awake()
    {
        InitSaveLoadSystem();
        LoadSoundSetting();
    }

    private void InitSaveLoadSystem()
    {
        if (_audioManager != null)
        {
            _soundSettingSaveSystem = new SoundSettingSaveSystem(_audioManager);
            _soundSettingLoadSystem = new SoundSettingLoadSystem(_audioManager);
        }
    }

    public void LoadSoundSetting()
    {
        if(_soundSettingSaveSystem != null)
        {
            _soundSettingLoadSystem.LoadSoundData();
        }
    }

    public void SaveSoundSetting()
    {
        if (_soundSettingSaveSystem != null)
        {
            _soundSettingSaveSystem.SaveSoundData();
        }
    }
}