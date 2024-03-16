using System;
using UnityEngine;

public class GameDataLoadSystem : BaseSaveSystemGameData
{
    public GameDataLoadSystem(CounterScore counterScore, DiamondsCounter diamondsCounter, ShopManager shopManager) : 
        base(counterScore, diamondsCounter, shopManager) { }

    public void LoadGameData()
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