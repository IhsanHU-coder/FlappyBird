using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class OnlineLeaderboard : MonoBehaviour
{
    DatabaseReference dbRef;

    void Start()
    {
        dbRef = FirebaseDatabase.GetInstance("https://flappybirddatabase-smkrus-default-rtdb.asia-southeast1.firebasedatabase.app/").RootReference;
    }

    public void SaveScore(string playerName, int score)
    {
        string key = dbRef.Child("leaderboard").Push().Key;

        LeaderboardEntry entry = new LeaderboardEntry(playerName, score);
        string json = JsonUtility.ToJson(entry);

        dbRef.Child("leaderboard").Child(key).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
                Debug.Log($"Score saved for {playerName} ({score})");
            else
                Debug.LogError("Failed to save score: " + task.Exception);
        });
    }
}

[System.Serializable]
public class LeaderboardEntry
{
    public string name;
    public int score;

    public LeaderboardEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
