using UnityEngine;

public class DiamondsCounter : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;

    private int _maxDiamondValue = 9999;
    private int _diamondScore = 0;

    public delegate void DiamondsCounterDelegate();
    public event DiamondsCounterDelegate DiamondScoreUpdate;

    private delegate void EventSubscribe();

    public int ScoreDiamonds
    {
        get { return _diamondScore; }
        set { _diamondScore = value; }
    }

    private void Start()
    {
        SubscribeEvents();
    }
    
    private void SubscribeEvents()
    {
        SubscribeUnsubscribeEvent(_shopManager, () => _shopManager.BuyExtraLifeEvent += DiamondScoreSub);
    }

    private void UnsubscribeEvents()
    {
        SubscribeUnsubscribeEvent(_shopManager, () => _shopManager.BuyExtraLifeEvent -= DiamondScoreSub);
    }

    private void SubscribeUnsubscribeEvent<T>(T obj, EventSubscribe EventSubscribe)
    {
        if (obj != null)
        {
            EventSubscribe();
        }
    }

    public void DiamondScoreAdd()
    {
        if (_diamondScore < _maxDiamondValue)
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

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}