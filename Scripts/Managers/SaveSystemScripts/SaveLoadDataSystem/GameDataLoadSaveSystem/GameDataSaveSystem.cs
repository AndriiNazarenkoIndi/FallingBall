using System;
using UnityEngine;

public class GameDataSaveSystem : BaseSaveSystemGameData, ISave
{
    public GameDataSaveSystem(CounterScore counterScore, DiamondsCounter diamondsCounter, ShopManager shopManager) : 
        base(counterScore, diamondsCounter, shopManager) { }

    public void Save()
    {
        try
        {
            _gameData.maxScoreValue = _counterScore.MaxScore;
            _gameData.maxDiamondsValue = _diamondsCounter.ScoreDiamonds;
            _gameData.localScoreValue = _counterScore.LocalScore;
            _gameData.totalAmountExtraLife = _shopManager.TotalAmountExtraLife;
            _saveSystem.Save(_gameData);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception" + ex);
        }
    }
}