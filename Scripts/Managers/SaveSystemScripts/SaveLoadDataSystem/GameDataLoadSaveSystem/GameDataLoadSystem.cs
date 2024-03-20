using System;
using UnityEngine;

public class GameDataLoadSystem : BaseSaveSystemGameData, ILoad
{
    private CounterScore _counterScore;
    private DiamondsCounter _diamondsCounter;
    private ShopManager _shopManager;

    public GameDataLoadSystem(CounterScore counterScore, DiamondsCounter diamondsCounter, ShopManager shopManager) : base()
    {
        _counterScore = counterScore;
        _diamondsCounter = diamondsCounter;
        _shopManager = shopManager;
    }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_gameData);
            _counterScore.MaxScore = _gameData.maxScoreValue;
            _counterScore.LocalScore = _gameData.localScoreValue;
            _diamondsCounter.ScoreDiamonds = _gameData.maxDiamondsValue;
            _shopManager.TotalAmountExtraLife = _gameData.totalAmountExtraLife;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}