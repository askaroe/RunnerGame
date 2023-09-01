using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Your instance is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }



    [SerializeField] private Text coinsCollectedText;
    [SerializeField] private Text coinsCollectedPopUpText;
    [SerializeField] private Text highScoreText;

    public void CoinsCollectedTextUpdate(int coins)
    {
        coinsCollectedText.text = coins.ToString();
    }

    public void GameOverPopUp(int coins)
    {
        coinsCollectedPopUpText.text = "Coins collected: " + coins.ToString();
    }

    public void HighScoreTextUpdate(int highScore)
    {
        highScoreText.text = "High score: " + highScore.ToString();
    }
}
