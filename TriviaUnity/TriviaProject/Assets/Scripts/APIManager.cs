using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Globalization;

public class APIManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;

    const string API_URL = "https://localhost:7241/api/";
    IEnumerator SetPlayerNameCor(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + $"Player/name?name={name}", form))
        {
            yield return request.SendWebRequest();
        }
    }
    IEnumerator SetPlayerScoreCor(int score, string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", score);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + $"Player/score?score={score}&name={name}", form))
        {
            yield return request.SendWebRequest();
        }
    }
    IEnumerator SetPlayerDoneCor(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);

        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + $"Player/isdone?isdone=1&name={name}", form))
        {
            yield return request.SendWebRequest();
        }
    }
    IEnumerator GetNumberOfPlayers()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    string numOfPlayers = request.downloadHandler.text;
                    MainMenuScript mms = new MainMenuScript();
                    mms.GetNumberOfPlayers(numOfPlayers);
                    break;
            }
        }
    }
    IEnumerator GetOtherPlayerDone(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + $"Player/isdone?name={name}"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    string playerIsDone = request.downloadHandler.text;
                    uiManager.EndGame(playerIsDone);
                    break;
            }
        }
    }
    IEnumerator GetOtherPlayerScore(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + $"Player/points?name={name}"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    string playersScore = request.downloadHandler.text;
                    uiManager.Winner(playersScore);
                    break;
            }
        }
    }
    IEnumerator GetQuestion(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/" + id))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    Question question = JsonUtility.FromJson<Question>(request.downloadHandler.text);
                    uiManager.UpdateQuestionText(question);
                    break;
            }
        }
    }
    IEnumerator GetQuestionForScore(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/" + id))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    Question question = JsonUtility.FromJson<Question>(request.downloadHandler.text);
                    uiManager.UpdateScore(question);
                    break;
            }
        }
    }
    public void GetQuestionWrapper(string id)
    {
        StartCoroutine(GetQuestion(id));
    }
    public void GetQuestionWrapperScore(string id)
    {
        StartCoroutine(GetQuestionForScore(id));
    }
    public void GetNumberOfPLayersCorWrapper()
    {
        StartCoroutine(GetNumberOfPlayers());
    }
    public void GetIsOtherPlayerDoneCorWrapper(string name)
    {
        StartCoroutine(GetOtherPlayerDone(name));
    }
    public void GetOtherPlayerScoreCorWrapper(string name)
    {
        StartCoroutine(GetOtherPlayerScore(name));
    }
    public void SetPlayerNameCorWrapper(string name)
    {
        StartCoroutine(SetPlayerNameCor(name));
    }
    public void SetPlayerScoreCorWrapper(int score, string name)
    {
        StartCoroutine(SetPlayerScoreCor(score, name));
    }
    public void SetPlayerIsDoneCorWrapper(string name)
    {
        StartCoroutine(SetPlayerDoneCor(name));
    }
}
