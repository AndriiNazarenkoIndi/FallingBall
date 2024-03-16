using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlatformSegment : MonoBehaviour
{
    private MeshCollider _meshCollider;
    private float _timeToSetEnable = 1.0f;

    public UnityEvent TriggerEnterBall;

    private void Start()
    {
        _meshCollider = GetComponent<MeshCollider>();
    }

    public void Bounce(float force, Vector3 center, float radius)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, center, radius);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            _meshCollider.enabled = false;
            TriggerEnterBall?.Invoke();
            StartCoroutine(TimerToSetEnabled());
        }
    }

    private IEnumerator TimerToSetEnabled()
    {
        yield return new WaitForSeconds(_timeToSetEnable);
        _meshCollider.enabled = true;
    }
}