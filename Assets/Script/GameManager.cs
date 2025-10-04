using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject _gameOverScreen;

    public TextMeshProUGUI playerNameText;

    [SerializeField] GameObject pauseScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        Score.Instance.SaveScore();

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
}
