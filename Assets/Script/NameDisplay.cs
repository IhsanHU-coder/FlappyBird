using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameDisplay : MonoBehaviour
{
    public TMP_InputField nameInputField;
    private const string PLAYER_NAME_KEY = "PlayerName";

    public void SetPlayerNameAndStartGame()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            PlayerPrefs.SetString(PLAYER_NAME_KEY, nameInputField.text);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Game");
        }
    }
}
