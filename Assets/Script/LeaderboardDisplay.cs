using UnityEngine;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;

public class LeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;
    DatabaseReference dbRef;

    void Start()
    {
        dbRef = FirebaseDatabase.GetInstance("https://flappybirddatabase-smkrus-default-rtdb.asia-southeast1.firebasedatabase.app/").RootReference;
        LoadLeaderboard();
    }

    public void LoadLeaderboard()
    {
        dbRef.Child("leaderboard").OrderByValue().LimitToLast(10).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                List<(string name, int score)> entries = new List<(string, int)>();

                foreach (DataSnapshot child in snapshot.Children)
                {
                    string name = child.Key;
                    int score = int.Parse(child.Value.ToString());
                    entries.Add((name, score));
                }

                entries.Sort((a, b) => b.score.CompareTo(a.score));

                leaderboardText.text = "Leaderboard\n\n";
                for (int i = 0; i < entries.Count; i++)
                {
                    leaderboardText.text += $"{i + 1}. {entries[i].name} - {entries[i].score}\n";
                }
            }
            else
            {
                leaderboardText.text = "Error load leaderboard.";
            }
        });
    }
}
