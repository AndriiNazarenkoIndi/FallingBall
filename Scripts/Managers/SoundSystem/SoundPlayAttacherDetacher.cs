using UnityEngine;

public class SoundPlayAttacherDetacher : MonoBehaviour
{
    [SerializeField] private SoundPlayManager _soundPlayManager;

    [Header("Subscription sources")]
    [SerializeField] private BallJumper _ballJumper;
    [SerializeField] private Ball _ball;
    [SerializeField] private DiamondCollections _diamondCollections;
    [SerializeField] private WinPlayer _winPlayer;
    [SerializeField] private DeathPlayer _deathPlayer;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachBaseEvents();
    }

    private void AttachBaseEvents()
    {
        _eventAttacherDetacher.AttachDetach(_ballJumper, () => _ballJumper.BallJumpEvent += _soundPlayManager.BallJumpSoundPlay);
        _eventAttacherDetacher.AttachDetach(_ball, () => _ball.SegmentDestroyEvent += _soundPlayManager.SegmentDestroySoundPlay);
        _eventAttacherDetacher.AttachDetach(_diamondCollections, () => _diamondCollections.DiamondCollectedEvent += _soundPlayManager.DiamondCollectionSoundPlay);
        _eventAttacherDetacher.AttachDetach(_winPlayer, () => _winPlayer.OnPlayerWinEvent += _soundPlayManager.PlayerWinSoundPlay);
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent += _soundPlayManager.PlayerGameOverSoundPlay);
    }

    private void DetachBaseEvents()
    {
        _eventAttacherDetacher.AttachDetach(_ballJumper, () => _ballJumper.BallJumpEvent -= _soundPlayManager.BallJumpSoundPlay);
        _eventAttacherDetacher.AttachDetach(_ball, () => _ball.SegmentDestroyEvent -= _soundPlayManager.SegmentDestroySoundPlay);
        _eventAttacherDetacher.AttachDetach(_diamondCollections, () => _diamondCollections.DiamondCollectedEvent -= _soundPlayManager.DiamondCollectionSoundPlay);
        _eventAttacherDetacher.AttachDetach(_winPlayer, () => _winPlayer.OnPlayerWinEvent -= _soundPlayManager.PlayerWinSoundPlay);
        _eventAttacherDetacher.AttachDetach(_deathPlayer, () => _deathPlayer.DeathPlayerEvent -= _soundPlayManager.PlayerGameOverSoundPlay);
    }

    private void OnDestroy()
    {
        DetachBaseEvents();
    }
}