using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallJumper : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] private float _jumpForce;

    private Rigidbody _ballRigidbody;

    public delegate void OnBallJump();
    public event OnBallJump BallJumpEvent;

    private void Start()
    {
        StartGetComponent();
    }

    private void StartGetComponent()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out JumpCollider jumpCollider))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _ballRigidbody.velocity = Vector3.zero;
        _ballRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        BallJumpEvent?.Invoke();
    }
}