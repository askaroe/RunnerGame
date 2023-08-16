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
    private bool _isLost;
    private bool _isStarted;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource slideSound;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (_isLost) return;

        if (_isStarted)
        {
            Movement();
            if (SwipeManager.swipeUp && IsGrounded())
            {
                Jump();
            }
            if (SwipeManager.swipeDown && IsGrounded())
            {
                StartCoroutine(SlidingCoolDown());
            }
        }
    }

    private void Movement()
    {
        Vector3 forwardMove = transform.forward * (speed * Time.deltaTime);
        if (SwipeManager.swipeLeft && currentLine < 1)
        {
            _rb.MovePosition(transform.position + new Vector3(-_lineDifference, 0, 0));
            currentLine++;
        }
        else if (SwipeManager.swipeRight && currentLine > -1)
        {
            _rb.MovePosition(transform.position + new Vector3(_lineDifference, 0, 0));
            currentLine--;
        }
        _rb.MovePosition(_rb.position + forwardMove);
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
        jumpSound.Play();
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundMask);
    }

    public void StartRunning()
    {
        speed = 8.0f;
        _isStarted = true;
    }

    public bool StartSliding()
    {
        return isSliding;
    }

    public void StopRunning()
    {
        speed = 0;
        _rb.isKinematic = true; // turns off players physics
        _isLost = true;
    }

    IEnumerator SlidingCoolDown()
    {
        isSliding = true;
        slideSound.Play();
        yield return new WaitForSeconds(0.8f);
        isSliding = false;
    }
}