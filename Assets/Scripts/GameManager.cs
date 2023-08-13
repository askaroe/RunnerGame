using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager instance is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }




    [SerializeField] private Player player;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject gameOverPopUp;
    [SerializeField] private GameObject pauseMenuButton;
    [SerializeField] private GameObject pauseMenuPanel;

    public void StartGameButton()
    {
        player.StartGame();
        pauseMenuButton.SetActive(true);
        startGameButton.SetActive(false);
    }

    public void PauseMenuButton()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverPopUp.SetActive(true);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    public void ResumeGameButton()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}