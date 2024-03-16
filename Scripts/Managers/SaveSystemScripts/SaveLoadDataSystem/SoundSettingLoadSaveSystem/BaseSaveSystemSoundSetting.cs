public abstract class BaseSaveSystemSoundSetting
{
    protected AudioManager _audioManager;
    protected SoundDataToSave _soundSetting;
    protected SaveSystem _saveSystem;
    private string _fileName;

    public BaseSaveSystemSoundSetting(AudioManager audioManager)
    {
        _audioManager = audioManager;
        InitSaveSystem();
        InitSoundSetting();
    }

    protected virtual void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.soundSettingFileName;
        _saveSystem = new SaveSystem(_fileName);
    }

    protected virtual void InitSoundSetting()
    {
        _soundSetting = new SoundDataToSave();
    }
}