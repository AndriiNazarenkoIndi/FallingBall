using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]

public class TowerRotator : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private float _rotateSpeed = 5;

    private Rigidbody _towerRigidbody;
    private IInput _inputSystem;
    private Vector2 _touchDeltaPosition;
    private float torque;

    [Inject]
    private void InitInputSystem(IInput inputSystem)
    {
        _inputSystem = inputSystem;
    }

    private void Start()
    {
        InitTowerComponent();
    }

    private void InitTowerComponent()
    {
        _towerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotateTowerControl();
    }

    private void RotateTowerControl()
    {
        _touchDeltaPosition = _inputSystem.GetTouchDeltaPosition();
        RotateTowerProcess(_touchDeltaPosition);
    }

    private void RotateTowerProcess(Vector2 touchDeltaPosition)
    {
        torque = touchDeltaPosition.x * Time.deltaTime * _rotateSpeed;
        _towerRigidbody.AddTorque(Vector3.up * -torque);
    }
}