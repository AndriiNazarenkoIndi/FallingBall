using UnityEngine;

public class RemovingObject : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}