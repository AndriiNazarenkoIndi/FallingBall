using TMPro;
using UnityEngine;

public class UISetTextManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [Header("Score UI")]
    [SerializeField] private CounterScore _counterScore;
    [SerializeField] private TMP_Text _maxScoreText;
    [SerializeField] private TMP_Text _localScoreText;

    [Header("Diamond UI")]
    [SerializeField] private DiamondsCounter _diamondsCounter;
    [SerializeField] private TMP_Text _diamondScoreText;

    [Header("Shop panel")]
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private TMP_Text _priceExtraLifeText;
    [SerializeField] private TMP_Text _extraLifeCountText;

    public GameManager GetGameManager => _gameManager;
    public CounterScore GetCounterScore => _counterScore;
    public DiamondsCounter GetDiamondsCounter => _diamondsCounter;
    public ShopManager GetShopManager => _shopManager;

    private void Start()
    {
        BaseStartSetting();
        if (_gameManager != null && _gameManager.IsMainMenu)
        {
            SettingMainMenu();
        }
        else
        {
            SettingStandartLevel();
        }
    }

    private void BaseStartSetting()
    {
        SetMaxScore();
        SetDiamondsScore();
    }

    private void SettingMainMenu()
    {
        SetPriceExtraLife();
        SetExtraLifeCount();
    }

    private void SettingStandartLevel()
    {
        SetLocalScore();
        SetExtraLifeCount();
    }

    public void SetLocalScore()
    {
        SetText(_counterScore, _localScoreText, _counterScore.LocalScore);
    }

    public void SetMaxScore()
    {
        SetText(_counterScore, _maxScoreText, _counterScore.MaxScore);
    }

    public void SetDiamondsScore()
    {
        SetText(_diamondsCounter, _diamondScoreText, _diamondsCounter.ScoreDiamonds);
    }

    public void SetPriceExtraLife()
    {
        SetText(_shopManager, _priceExtraLifeText, _shopManager.PriceExtraLife);
    }

    public void SetExtraLifeCount()
    {
        SetText(_shopManager, _extraLifeCountText, _shopManager.TotalAmountExtraLife);
    }

    private void SetText<T>(T obj, TMP_Text textScore, int scoreValue)
    {
        if (obj != null)
        {
            textScore.text = scoreValue.ToString();
        }
    }
}