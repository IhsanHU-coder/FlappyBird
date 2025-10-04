using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseInit : MonoBehaviour
{
    public static FirebaseDatabase DB;

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                var app = FirebaseApp.DefaultInstance;
                DB = FirebaseDatabase.GetInstance(app, "https://flappybirddatabase-smkrus-default-rtdb.asia-southeast1.firebasedatabase.app/");

                Debug.Log("Firebase connected to your Realtime Database!");
            }
            else
            {
                Debug.LogError("Firebase not ready: " + dependencyStatus);
            }
        });
    }
}
