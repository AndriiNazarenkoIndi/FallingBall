using UnityEngine;

public class UISetActiveEventManager : MonoBehaviour
{
    [Header("Base setting")]
    [SerializeField] private UISetActiveManager _uiSetActiveManager;
    [SerializeField] private GameManager _gameManager;

    [Header("Player Win/Death")]
    [SerializeField] private DeathPlayer _deathPlayer;
    [SerializeField] private WinPlayer _winPlayer;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachToStandartLevel();
    }

    private void AttachToStandartLevel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            AttachSetActiveRestartButton();
            AttachSetActiveReturnToMainMenuButton();
            AttachSetActiveNextLevelButton();
        }
    }

    private void DetachToStandartLevel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            DetachSetActiveRestartButton();
            DetachSetActiveReturnToMainMenuButton();
            DetachSetActiveNextLevelButton();
        }
    }

    #region Attach/Detach
    private void AttachSetActiveRestartButton()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent += _uiSetActiveManager.SetActiveRestartButton);
    }

    private void DetachSetActiveRestartButton()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent -= _uiSetActiveManager.SetActiveRestartButton);
    }

    private void AttachSetActiveReturnToMainMenuButton()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent += _uiSetActiveManager.SetActiveMainMenuButton);
    }

    private void DetachSetActiveReturnToMainMenuButton()
    {
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent -= _uiSetActiveManager.SetActiveMainMenuButton);
    }

    private void AttachSetActiveNextLevelButton()
    {
        _eventAttacherDetacher.AttachDetach(_winPlayer, () => _winPlayer.OnPlayerWinEvent += _uiSetActiveManager.SetActiveNextLevelButton);
    }

    private void DetachSetActiveNextLevelButton()
    {
        _eventAttacherDetacher.AttachDetach(_winPlayer, () => _winPlayer.OnPlayerWinEvent -= _uiSetActiveManager.SetActiveNextLevelButton);
    }
    #endregion

    private void OnDestroy()
    {
        DetachToStandartLevel();
    }
}