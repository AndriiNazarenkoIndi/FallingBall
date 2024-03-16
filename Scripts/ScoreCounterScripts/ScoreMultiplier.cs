using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] private CounterScore _counterScore;
    
    private int _multiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        _multiplier += 1;
        SetNewScoreMultiplier(_multiplier);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_multiplier > 1)
        {
            _multiplier = 1;
            SetNewScoreMultiplier(_multiplier);
        }
    }

    private void SetNewScoreMultiplier(int multiplier)
    {
        _counterScore.ScoreMultiplier = multiplier;
    }
}