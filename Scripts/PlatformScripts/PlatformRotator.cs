using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        if (_speedRotate != 0)
        {
            RotateObjectAxisY(_speedRotate);
        }
    }

    private void RotateObjectAxisY(float speedRotate)
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speedRotate);
    }
}