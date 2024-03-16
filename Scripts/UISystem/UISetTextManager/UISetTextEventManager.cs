using UnityEngine;
using UnityEngine.Events;

public class UISetTextEventManager : MonoBehaviour
{
    [Header("Base setting")]
    [SerializeField] private UISetTextManager _uiSetTextManager;
    [SerializeField] private DeathPlayer _deathPlayer;

    private CounterScore _counterScore;
    private DiamondsCounter _diamondsCounter;
    private ShopManager _shopManager;
    private GameManager _gameManager;
    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        Init();
        AttachingEventToEveryone();
        if (_gameManager != null && _gameManager.IsMainMenu)
        {
            AttachingEventToMainMenu();
        }
        else
        {
            AttachingEventToStandartLevel();
        }
    }

    private void Init()
    {
        _counterScore = _uiSetTextManager.GetCounterScore;
        _diamondsCounter = _uiSetTextManager.GetDiamondsCounter;
        _shopManager = _uiSetTextManager.GetShopManager;
        _gameManager = _uiSetTextManager.GetGameManager;
    }

    #region Attaching/Detaching ToEveryone
    private void AttachingEventToEveryone()
    {
        AttachDiamondScoreUpdateEvent();
        AttachUpdateExtraLifeCountEvent();
    }

    private void DetachingEventToEveryone()
    {
        DetachDiamondScoreUpdateEvent();
        DetachUpdateExtraLifeCountEvent();
    }

    #endregion

    #region Attaching/Detaching ToMainMenu
    private void AttachingEventToMainMenu()
    {
        AttachShopBuyEvent();
    }

    private void DetachingEventToMainMenu()
    {
        DetachShopBuyEvent();
    }

    #endregion

    #region Attaching/Detaching ToStandartLevel
    private void AttachingEventToStandartLevel()
    {
        AttachLocalScoreUpdateEvent();
        AttachUseExtraLifeEvent();
    }

    private void DetachingEventToStandartLevel()
    {
        DetachLocalScoreUpdateEvent();
        DetachUseExtraLifeEvent();
    }

    #endregion

    #region Event Attach/Detach
    private void AttachLocalScoreUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_counterScore, () => _counterScore.ScorePointUpdateEvent += _uiSetTextManager.SetLocalScore);
    }

    private void DetachLocalScoreUpdateEvent()
    {
       _eventAttacherDetacher.AttachDetach(_counterScore, () => _counterScore.ScorePointUpdateEvent -= _uiSetTextManager.SetLocalScore);
    }

    private void AttachUseExtraLifeEvent()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.UseExtraLifeEvent += _uiSetTextManager.SetExtraLifeCount);
    }

    private void DetachUseExtraLifeEvent()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.UseExtraLifeEvent -= _uiSetTextManager.SetExtraLifeCount);
    }

    private void AttachDiamondScoreUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_diamondsCounter, () => _diamondsCounter.DiamondScoreUpdate += _uiSetTextManager.SetDiamondsScore);
    }

    private void DetachDiamondScoreUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_diamondsCounter, () => _diamondsCounter.DiamondScoreUpdate -= _uiSetTextManager.SetDiamondsScore);
    }

    private void AttachShopBuyEvent()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.UpdatePriceEvent += _uiSetTextManager.SetPriceExtraLife);
    }

    private void DetachShopBuyEvent()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.UpdatePriceEvent -= _uiSetTextManager.SetPriceExtraLife);
    }

    private void AttachUpdateExtraLifeCountEvent()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.BuyExtraLifeEvent += _uiSetTextManager.SetExtraLifeCount);
    }

    private void DetachUpdateExtraLifeCountEvent()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.BuyExtraLifeEvent -= _uiSetTextManager.SetExtraLifeCount);
    }

    #endregion

    private void OnDestroy()
    {
        DetachingEventToEveryone();
        if (_gameManager != null && _gameManager.IsMainMenu)
        {
            DetachingEventToMainMenu();
        }
        else
        {
            DetachingEventToStandartLevel();
        }
    }
}