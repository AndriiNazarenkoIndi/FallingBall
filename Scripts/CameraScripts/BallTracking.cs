using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private Vector3 _cameraOffset;
    private Vector3 _targetPosition;

    private void Start()
    {
        SetCameraOffset();
    }

    private void LateUpdate()
    {
        PositionTracking();
    }

    private void SetCameraOffset()
    {
        _cameraOffset = transform.position - _ball.transform.position;
    }

    private void PositionTracking()
    {
        _targetPosition = _ball.transform.position + _cameraOffset;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}