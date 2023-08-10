using System.Collections;
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
    [SerializeField] private int currentLine;
    [SerializeField] private bool isSliding;

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
        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            StartCoroutine(SlidingCoolDown());
        }
        Debug.Log(isSliding);
    }

    private void Movement()
    {
        Vector3 forwardMove = transform.forward * (speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A) && currentLine < 1)
        {
            _rb.MovePosition(transform.position + new Vector3(-_lineDifference, 0, 0));
            currentLine++;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLine > -1)
        {
            _rb.MovePosition(transform.position + new Vector3(_lineDifference, 0, 0));
            currentLine--;
        }
        _rb.MovePosition(_rb.position + forwardMove);
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundMask);
    }

    public void StartRunning()
    {
        speed = 8.0f;
    }

    public bool StartSliding()
    {
        return isSliding;
    }

    IEnumerator SlidingCoolDown()
    {
        isSliding = true;
        yield return new WaitForSeconds(0.8f);
        isSliding = false;
    }
}