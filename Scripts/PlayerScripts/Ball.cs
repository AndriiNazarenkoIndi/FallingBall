using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent colliderTrigger;

    public delegate void OnSegmentDestroy();
    public event OnSegmentDestroy SegmentDestroyEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment)) 
        {
            other.GetComponentInParent<Platform>().Break();
            colliderTrigger?.Invoke();
            SegmentDestroyEvent?.Invoke();
        }
    }
}