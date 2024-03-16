using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private DiamondsCounter _diamondsCounter;
    [SerializeField] private ShopSetting _shopSetting;

    private int _amountExtraLife = 1;
    private int _totalAmountExtraLife = 0;

    public delegate void BuyExtraLife();
    public event BuyExtraLife BuyExtraLifeEvent;

    public delegate void UpdatePrice();
    public event UpdatePrice UpdatePriceEvent;

    public int PriceExtraLife => _shopSetting.ExtraLifePrice;

    public int TotalAmountExtraLife
    {
        get { return _totalAmountExtraLife; }
        set { _totalAmountExtraLife = value;}
    }

    private void OnValidate()
    {
        UpdatePriceEvent?.Invoke();
    }

    public void AddExtraLife()
    {
        if (_diamondsCounter != null && _diamondsCounter.ScoreDiamonds >= _shopSetting.ExtraLifePrice)
        {
            _totalAmountExtraLife += _amountExtraLife;
            BuyExtraLifeEvent?.Invoke();
        }
    }
}