using UnityEngine;

public class WinPlayer : MonoBehaviour
{
    public delegate void PlayerWin();
    public event PlayerWin OnPlayerWinEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FinishSegment finishSegment))
        {
            OnPlayerWinEvent?.Invoke();
        }
    }
}