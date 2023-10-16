using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public APIManager _APIManager;
    public TMP_InputField PlayerName;

    private void Update()
    {
        _APIManager.GetNumberOfPLayersCorWrapper();
        if (PlayerGlobal.allPlayersConnected)
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void GetStartButtonClicked()
    {
        PlayerGlobal.name = PlayerName.text;
        _APIManager.SetPlayerNameCorWrapper(PlayerName.text);  
    }
    public void GetNumberOfPlayers(string numOfPlayers)
    {
        if (numOfPlayers == "[\"2\"]")
        {
            PlayerGlobal.allPlayersConnected = true;
        }
    }
}
