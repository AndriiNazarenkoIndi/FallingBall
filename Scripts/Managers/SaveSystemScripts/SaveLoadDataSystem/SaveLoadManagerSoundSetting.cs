using UnityEngine;

public class SaveLoadManagerSoundSetting : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    private ISave _soundSettingSaveSystem;
    private ILoad _soundSettingLoadSystem;

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
            _soundSettingLoadSystem.Load();
        }
        else
        {
            Debug.Log("SoundSettingLoadSystem is Null. Load is Failed.");
        }
    }

    public void SaveSoundSetting()
    {
        if (_soundSettingSaveSystem != null)
        {
            _soundSettingSaveSystem.Save();
        }
        else
        {
            Debug.Log("SoundSettingSaveSystem is Null. Save is Failed.");
        }
    }
}