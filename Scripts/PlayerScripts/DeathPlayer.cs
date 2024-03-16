using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private CounterScore _counterScore;
    [SerializeField] private ShopManager _shopManager;

    public delegate void DeathPlayerStatus();
    public event DeathPlayerStatus DeathPlayerEvent;

    public delegate void UseExtraLife();
    public event UseExtraLife UseExtraLifeEvent;

    private Rigidbody _rigidbodyBall;
    private int _valueForSuperMod = 3;
    private int _multiplierValue;

    private void Start()
    {
        StartGetComponent();
    }

    private void StartGetComponent() 
    {
        _rigidbodyBall = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DangerPlatform dangerPlatform))
        {
            GetMultiplierValue();
            if (_multiplierValue - 1 < _valueForSuperMod && _shopManager.TotalAmountExtraLife < 1)
            {
                DefeatStatus();
            }
            else
            {
                if (_multiplierValue - 1 < _valueForSuperMod && _shopManager.TotalAmountExtraLife != 0)
                {
                    UpdateExtraLife();
                }
                BreachStatus(collision);
            }
        }
    }

    private void GetMultiplierValue()
    {
        _multiplierValue = _counterScore.ScoreMultiplier;
    }

    private void DefeatStatus()
    {
        PlayerBallDeactivation(true);
        DeathPlayerEvent?.Invoke();
    }

    private void PlayerBallDeactivation(bool isKinematic)
    {
        _rigidbodyBall.isKinematic = isKinematic;
    }

    private void BreachStatus(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    private void UpdateExtraLife()
    {
        _shopManager.TotalAmountExtraLife -= 1;
        UseExtraLifeEvent?.Invoke();
    }
}