using UnityEngine;
using UnityEngine.Events;

public class DiamondCollections : MonoBehaviour
{
    public UnityEvent diamondCollect;

    public delegate void OnDiamondCollected();
    public event OnDiamondCollected DiamondCollectedEvent;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Diamond diamond))
        {
            diamondCollect?.Invoke();
            DiamondCollectedEvent?.Invoke();
            Destroy(collider.gameObject);
        }
    }
}