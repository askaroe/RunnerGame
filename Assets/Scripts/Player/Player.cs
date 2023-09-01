using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimations _playerAnimations;
    private PlayerMovement _playerMovement;
    private bool _isStarted;
    private int _coinsCollected;
    private int _highScore;

    [SerializeField] private AudioSource collectCoinSound;
    [SerializeField] private AudioSource loseSound;

    [SerializeField] private float timeIntervalToIncreaseSpeed = 30.0f;
    [SerializeField] private float _canIncrease = 30.0f;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("highScore", 0);
        UIManager.Instance.HighScoreTextUpdate(_highScore);
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
        InvokeRepeating("IncreasePlayerSpeed", 120f, 120f); // the name of the method, wait after game started, every X seconds
    }

    public void Lose()
    {
        _playerMovement.StopRunning();
        _playerAnimations.LoseAnimation();
        loseSound.Play();
        UIManager.Instance.GameOverPopUp(_coinsCollected);
        GameManager.Instance.GameOver();
    }

    public void CoinCollected()
    {
        _coinsCollected += 1;
        collectCoinSound.Play();
        UIManager.Instance.CoinsCollectedTextUpdate(_coinsCollected);
        if(_coinsCollected > _highScore)
        {
            _highScore = _coinsCollected;
            PlayerPrefs.SetInt("highScore", _highScore);
            UIManager.Instance.HighScoreTextUpdate(_highScore);
        }
    }

    private void IncreasePlayerSpeed()
    {
        _playerMovement.IncreaseSpeed();
        Debug.Log("INCREASED");
    }

}
