using UnityEngine;

public class SettingMultiplierEffects : MonoBehaviour
{
    [SerializeField] private CounterScore _counterScore;
    [SerializeField] private GameObject _particleTail;
    [SerializeField] private Renderer _ballRenderer;
    [SerializeField] private Material _ballMaterialBoost;
    
    private int _valueForSuperMod = 3;
    private int _multiplier = 1;
    private Material _standartBallMaterial;

    private void Start()
    {
        _standartBallMaterial = _ballRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        _multiplier = _counterScore.ScoreMultiplier;
        SetAnEffect(_multiplier, _valueForSuperMod, _ballMaterialBoost, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetAnEffect(_multiplier, _valueForSuperMod, _standartBallMaterial, false);
    }

    private void SetAnEffect(int multiplier, int valueForSuperMod, Material setBallMaterial, bool setParticleTail)
    {
        if (multiplier > valueForSuperMod)
        {
            _ballRenderer.material = setBallMaterial;
            _particleTail.SetActive(setParticleTail);
        }
    }
}