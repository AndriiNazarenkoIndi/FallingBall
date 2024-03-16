public abstract class BaseSaveSystemGameData
{
    protected CounterScore _counterScore;
    protected DiamondsCounter _diamondsCounter;
    protected ShopManager _shopManager;

    protected GameDataToSave _gameData;
    protected SaveSystem _saveSystem;
    private string _fileName;

    protected BaseSaveSystemGameData(CounterScore counterScore, DiamondsCounter diamondsCounter, ShopManager shopManager) 
    { 
        _counterScore = counterScore;
        _diamondsCounter = diamondsCounter;
        _shopManager = shopManager;
        InitSaveSystem();
        InitGameData();
    }

    protected virtual void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.gameDataFileName;
        _saveSystem = new SaveSystem(_fileName);
    }

    protected virtual void InitGameData()
    {
        _gameData = new GameDataToSave();
    }
}