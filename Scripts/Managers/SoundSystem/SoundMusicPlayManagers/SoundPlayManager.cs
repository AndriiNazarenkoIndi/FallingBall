using UnityEngine;

public class SoundPlayManager : MonoBehaviour
{
    [Header("Audio setting")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SoundList _soundList;

    public void BallJumpSoundPlay()
    {
        _audioManager.SoundSystemPlay.BallJumpSoundPlay(_soundList.BallJumpSound);
    }

    public void SegmentDestroySoundPlay()
    {
        _audioManager.SoundSystemPlay.SegmentDestroySoundPlay(_soundList.SegmentDestroySound);
    }

    public void DiamondCollectionSoundPlay()
    {
        _audioManager.SoundSystemPlay.DiamondCollectionSoundPlay(_soundList.DiamondCollectionSound);
    }

    public void PlayerWinSoundPlay()
    {
        _audioManager.SoundSystemPlay.PlayerWinSoundPlay(_soundList.PlayerWinSound);
    }

    public void PlayerGameOverSoundPlay()
    {
        _audioManager.SoundSystemPlay.PlayerGameOverSoundPlay(_soundList.PlayerGameOverSound);
    }
}