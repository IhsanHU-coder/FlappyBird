using UnityEngine;
using TMPro;
using Firebase.Database;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] TextMeshProUGUI _currentScoreText;
    [SerializeField] TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            PlayerPrefs.Save();
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

    public void SaveScore()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        int count = PlayerPrefs.GetInt("LeaderboardCount", 0);

        PlayerPrefs.SetString("LeaderboardName_" + count, playerName);
        PlayerPrefs.SetInt("LeaderboardScore_" + count, _score);

        PlayerPrefs.SetInt("LeaderboardCount", count + 1);

        PlayerPrefs.Save();

        SaveScoreToFirebase(playerName, _score);
    }

    public void SaveScoreToFirebase(string playerName, int score)
    {
        if (FirebaseInit.DB == null)
        {
            Debug.LogError("Firebase not ready!");
            return;
        }

        DatabaseReference dbRef = FirebaseInit.DB.GetReference("leaderboard").Child(playerName);

        dbRef.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error read data from Firebase!");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if (snapshot.Exists)
                {
                    int oldScore = int.Parse(snapshot.Value.ToString());

                    if (score > oldScore)
                    {
                        dbRef.SetValueAsync(score);
                        Debug.Log($" Skor {playerName} updated: {oldScore} ➜ {score}");
                    }
                    else
                    {
                        Debug.Log($" Skor {playerName} ({score}) is't bigger then before ({oldScore})");
                    }
                }
                else
                {
                    dbRef.SetValueAsync(score);
                    Debug.Log($" Skor have been saved: {playerName} - {score}");
                }
            }
        });
    }
}
