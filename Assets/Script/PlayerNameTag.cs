using UnityEngine;
using TMPro;

public class PlayerNameTag : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    private const string PLAYER_NAME_KEY = "PlayerName";

    void Start()
    {
        if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
        {
            playerNameText.text = PlayerPrefs.GetString(PLAYER_NAME_KEY);
        }
        else
        {
            playerNameText.text = "Player";
        }
    }
}
