public abstract class BaseSaveSystemGameData
{
    protected GameDataToSave _gameData;
    protected ISaveSystem _saveSystem;
    private string _fileName;

    protected BaseSaveSystemGameData() 
    {
        InitSaveSystem();
        InitGameData();
    }

    private void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.gameDataFileName;
        _saveSystem = new SaveSystem(_fileName);
    }

    private void InitGameData()
    {
        _gameData = new GameDataToSave();
    }
}