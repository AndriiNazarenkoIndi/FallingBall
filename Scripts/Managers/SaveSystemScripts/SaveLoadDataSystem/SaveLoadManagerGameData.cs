using UnityEngine;

public class SaveLoadManagerGameData : MonoBehaviour
{
    [SerializeField] private CounterScore _counterScore;
    [SerializeField] private DiamondsCounter _diamondsCounter;
    [SerializeField] private ShopManager _shopManager;

    private ISave _gameDataSaveSystem;
    private ILoad _gameDataLoadSystem;

    private void Awake()
    {
        AwakeInitSaveLoadSystem();
        LoadGameData();
    }

    private void AwakeInitSaveLoadSystem()
    {
        _gameDataSaveSystem = new GameDataSaveSystem(_counterScore, _diamondsCounter, _shopManager);
        _gameDataLoadSystem = new GameDataLoadSystem(_counterScore, _diamondsCounter, _shopManager);
    }

    public void LoadGameData()
    {
        if (_gameDataLoadSystem != null)
        {
            _gameDataLoadSystem.Load();
        } 
        else
        {
            Debug.Log("GameDataLoadSystem is Null. Load is Failed.");
        }
    }
     
    public void SaveGameData()
    {
        if (_gameDataSaveSystem != null)
        {
            _gameDataSaveSystem.Save();
        }
        else
        {
            Debug.Log("GameDataSaveSystem is Null. Save is Failed.");
        }
    }
}