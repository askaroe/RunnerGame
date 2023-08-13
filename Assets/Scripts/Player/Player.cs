using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimations _playerAnimations;
    private PlayerMovement _playerMovement;
    private bool _isStarted;
    private int _coinsCollected;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _playerAnimations.JumpAnimation(!_playerMovement.IsGrounded());
        _playerAnimations.SlideAnimation(_playerMovement.StartSliding());
    }

    public void StartGame()
    {
        _isStarted = true;
        _playerAnimations.StartRunAnimation();
        _playerMovement.StartRunning();
    }

    public void Lose()
    {
        _playerMovement.StopRunning();
        _playerAnimations.LoseAnimation();
        UIManager.Instance.GameOverPopUp(_coinsCollected);
        GameManager.Instance.GameOver();
    }

    public void CoinCollected()
    {
        _coinsCollected += 1;
        UIManager.Instance.CoinsCollectedTextUpdate(_coinsCollected);
    }

}
