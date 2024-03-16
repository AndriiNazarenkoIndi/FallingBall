using UnityEngine;

public class SoundList : MonoBehaviour
{
    [Header("Sound AudioClips")]

    [Header("Game process sound effets")]
    [SerializeField] private AudioClip _ballJumpSound;
    [SerializeField] private AudioClip _segmentDestroySound;
    [SerializeField] private AudioClip _diamondCollectionSound;

    [Header("Win/GameOver sound")]
    [SerializeField] private AudioClip _playerWinSound;
    [SerializeField] private AudioClip _playerGameOverSound;

    [Header("UI event effect sound")]
    [SerializeField] private AudioClip _buttonClickSound;

    public AudioClip BallJumpSound => _ballJumpSound;
    public AudioClip SegmentDestroySound => _segmentDestroySound;
    public AudioClip DiamondCollectionSound => _diamondCollectionSound;
    public AudioClip PlayerWinSound => _playerWinSound;
    public AudioClip PlayerGameOverSound => _playerGameOverSound;
    public AudioClip ButtonClickSound => _buttonClickSound;
}