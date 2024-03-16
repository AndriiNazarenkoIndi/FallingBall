using UnityEngine;

public class DiamondsCounter : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private ScoreValueSetting _scoreValueSetting;

    private int _diamondScore = 0;

    public delegate void DiamondsCounterDelegate();
    public event DiamondsCounterDelegate DiamondScoreUpdate;

    public ShopManager GetShopManager => _shopManager;

    public int ScoreDiamonds
    {
        get { return _diamondScore; }
        set { _diamondScore = value; }
    }

    public void DiamondScoreAdd()
    {
        if (_diamondScore < _scoreValueSetting.MaxDiamondValue)
        {
            _diamondScore++;
            DiamondScoreUpdate?.Invoke();
        }
    }

    public void DiamondScoreSub()
    {
        if (_diamondScore >= _shopManager.PriceExtraLife)
        {
            _diamondScore -= _shopManager.PriceExtraLife;
            DiamondScoreUpdate?.Invoke();
        }
    }
}