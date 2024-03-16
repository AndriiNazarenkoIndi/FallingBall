using UnityEngine;

public class SaveLoadManagerGameData : MonoBehaviour
{
    [SerializeField] private CounterScore _counterScore;
    [SerializeField] private DiamondsCounter _diamondsCounter;
    [SerializeField] private ShopManager _shopManager;

    private GameDataSaveSystem _gameDataSaveSystem;
    private GameDataLoadSystem _gameDataLoadSystem;

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
        _gameDataLoadSystem.LoadGameData();
    }

    public void SaveGameData()
    {
        _gameDataSaveSystem.SaveGameData();
    }
}