using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
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

    public void StartGameButton()
    {
        player.StartGame();
        startGameButton.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPopUp.SetActive(true);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
