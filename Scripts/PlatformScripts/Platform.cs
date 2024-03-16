using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

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
        StartCoroutine(TimeToDetach());
    }

    private IEnumerator TimeToDetach()
    {
        yield return new WaitForSeconds(0.1f);
        transform.DetachChildren();
    }
}