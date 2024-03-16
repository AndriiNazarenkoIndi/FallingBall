using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private float _timeToDetach = 0.1f; 
    private PlatformSegment[] _segments;

    public void Break()
    {
        _segments = GetComponentsInChildren<PlatformSegment>();
        foreach(PlatformSegment segment in _segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }

    public void DetachChildrenPlatform()
    {
        StartCoroutine(TimerToDetach());
    }

    private IEnumerator TimerToDetach()
    {
        yield return new WaitForSeconds(_timeToDetach);
        transform.DetachChildren();
    }
}