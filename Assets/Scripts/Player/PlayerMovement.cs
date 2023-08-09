using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontalMultiplier = 2.0f;
    private Rigidbody _rb;
    private float _lineDifference = 2.2f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    private void Movement()
    {
        Vector3 forwardMove = transform.forward * (speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rb.MovePosition(transform.position + new Vector3(-_lineDifference, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _rb.MovePosition(transform.position + new Vector3(_lineDifference, 0, 0));
        }
        _rb.MovePosition(_rb.position + forwardMove);
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
    }

    public bool IsGrounded()
    {
        Debug.Log(Physics.CheckSphere(groundCheck.position, 0.1f, groundMask));
        return Physics.CheckSphere(groundCheck.position, .1f, groundMask);
    }

    public void StartRunning()
    {
        speed = 8.0f;
    }
}