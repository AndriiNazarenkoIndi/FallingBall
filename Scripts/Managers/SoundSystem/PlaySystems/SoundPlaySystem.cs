using UnityEngine;

public class SoundPlaySystem
{
    private AudioSource _audioSource;

    public SoundPlaySystem(AudioSource _soundAudioSource)
    {
        _audioSource = _soundAudioSource;
    }

    #region Sound Effect Play
    public void BallJumpSoundPlay(AudioClip ballJumpSound)
    {
        SoundPlayOneShot(ballJumpSound);
    }

    public void SegmentDestroySoundPlay(AudioClip segmentDestroySound)
    {
        SoundPlayOneShot(segmentDestroySound);
    }

    public void DiamondCollectionSoundPlay(AudioClip diamondCollectionSound)
    {
        SoundPlayOneShot(diamondCollectionSound);
    }

    public void PlayerWinSoundPlay(AudioClip playerWinSound)
    {
        SoundPlayOneShot(playerWinSound);
    }

    public void PlayerGameOverSoundPlay(AudioClip playerGameOverSound)
    {
        SoundPlayOneShot(playerGameOverSound);
    }

    public void ButtonClickSoundPlay(AudioClip buttonClickSound)
    {
        SoundPlayOneShot(buttonClickSound);
    }

    #endregion

    private void SoundPlayOneShot(AudioClip sound)
    {
        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(sound);
        }
    }
}