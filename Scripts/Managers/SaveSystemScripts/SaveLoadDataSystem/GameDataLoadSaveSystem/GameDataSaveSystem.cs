using System;
using UnityEngine;

public class GameDataSaveSystem : BaseSaveSystemGameData, ISave
{
    private CounterScore _counterScore;
    private DiamondsCounter _diamondsCounter;
    private ShopManager _shopManager;

    public GameDataSaveSystem(CounterScore counterScore, DiamondsCounter diamondsCounter, ShopManager shopManager) : base()
    {
        _counterScore = counterScore;
        _diamondsCounter = diamondsCounter;
        _shopManager = shopManager;
    }

    public void Save()
    {
        try
        {
            AssigningValues();
            _saveSystem.Save(_gameData);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception" + ex);
        }
    }

    private void AssigningValues()
    {
        _gameData.maxScoreValue = _counterScore.MaxScore;
        _gameData.maxDiamondsValue = _diamondsCounter.ScoreDiamonds;
        _gameData.localScoreValue = _counterScore.LocalScore;
        _gameData.totalAmountExtraLife = _shopManager.TotalAmountExtraLife;
    }
}