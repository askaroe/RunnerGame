using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float horizontalMultiplier = 2.0f;
    private Rigidbody _rb;
    private float _horizontalInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * (speed * Time.fixedDeltaTime);
        Vector3 horizontalMove = transform.right * (_horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier);
        _rb.MovePosition(_rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
