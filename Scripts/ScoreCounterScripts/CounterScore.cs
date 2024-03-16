using UnityEngine;

public class CounterScore : MonoBehaviour
{
    [SerializeField] private ScoreValueSetting _scoreValueSetting; 

    private int _standartPoint = 10;
    private int _diamondBonusPoint = 100;
    private int _maxScore = 0;
    private int _localScore = 0;
    private int _scoreMultiplier = 1;

    public delegate void ScorePointUpdate();
    public ScorePointUpdate ScorePointUpdateEvent;

    public int ScoreMultiplier
    {
        get { return _scoreMultiplier; }
        set { _scoreMultiplier = value; }
    }
    public int MaxScore
    {
        get { return _maxScore; }
        set { _maxScore = value; }
    }
    public int LocalScore
    {
        get { return _localScore; }
        set { _localScore = value; }
    }

    private void Start()
    {
        InitScoreSetting();
    }

    private void InitScoreSetting()
    {
        if (_scoreValueSetting != null)
        {
            _standartPoint = _scoreValueSetting.StandartPoint;
            _diamondBonusPoint = _scoreValueSetting.DiamondBonusPoint;
        }
    }

    public void ScoreAdd()
    {
        _localScore += (_standartPoint * _scoreMultiplier);
        ScorePointUpdateEvent?.Invoke();
    }

    public void ScoreBonusAdd()
    {
        _localScore += _diamondBonusPoint;
        ScorePointUpdateEvent?.Invoke();
    }

    public void SetLocalScoreToZero()
    {
        _localScore = 0;
    }

    public void SetNewMaxScore()
    {
        if (_localScore > _maxScore)
        {
            _maxScore = _localScore;
        }
    }
}