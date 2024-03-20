public abstract class BaseSaveSystemSoundSetting
{
    protected SoundDataToSave _soundSetting;
    protected ISaveSystem _saveSystem;
    private string _fileName;

    public BaseSaveSystemSoundSetting()
    {
        InitSaveSystem();
        InitSoundSetting();
    }

    private void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.soundSettingFileName;
        _saveSystem = new SaveSystem(_fileName);
    }

    private void InitSoundSetting()
    {
        _soundSetting = new SoundDataToSave();
    }
}