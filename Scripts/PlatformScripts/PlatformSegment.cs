using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlatformSegment : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 20.0f)] private float _timeToSetEnable = 1.0f;
    private MeshCollider _meshCollider;

    public UnityEvent triggerEnterBall;

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
            triggerEnterBall?.Invoke();
            StartCoroutine(TimeToSetEnabled());
        }
    }

    private IEnumerator TimeToSetEnabled()
    {
        yield return new WaitForSeconds(_timeToSetEnable);
        _meshCollider.enabled = true;
    }
}