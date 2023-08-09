using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontalMultiplier = 2.0f;
    private Rigidbody _rb;
    private float _lineDifference = 2.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Movement();
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

    public void StartRunning()
    {
        speed = 5.0f;
    }
}