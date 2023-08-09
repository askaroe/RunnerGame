using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimations _playerAnimations;
    private PlayerMovement _playerMovement;
    private bool _isStarted;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && !_isStarted)
        {
            _isStarted = true;
            _playerAnimations.StartRunAnimation();
            _playerMovement.StartRunning();
        }
        _playerAnimations.JumpAnimation(!_playerMovement.IsGrounded());
    }


}
