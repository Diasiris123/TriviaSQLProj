using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerAnswer;
    int QuestionID = 1;
    int QuestionID2 = 1;
    int score = 0;
    string playerName = PlayerGlobal.name;
    public TMP_InputField PlayerId;
    public TMP_Text QuestionText;
    public TMP_Text AnswerText1;
    public TMP_Text AnswerText2;
    public TMP_Text AnswerText3;
    public TMP_Text AnswerText4;
    public APIManager _APIManager;
    public GameObject WinImage;
    public GameObject LoseImage;
    public GameObject DrawImage;
    public GameObject WaitImage;

    private void Start()
    {
        GetQuestionButtonClicked();
    }
    private void Update()
    {
        if (PlayerGlobal.timeLeft <= 0)
        {
            GetQuestionButtonClicked();
            GetScoreButtonClicked();
        }

        if (QuestionID < 10)
            return;
           
        GetIsOtherPlayerDone();
    }
    public void GetQuestionButtonClicked()
    {
        if (QuestionID > 11)
            return;

        _APIManager.GetQuestionWrapper(QuestionID.ToString()); 
    }
    public void GetScoreButtonClicked()
    {
        if (QuestionID > 11)
            return;

        _APIManager.GetQuestionWrapperScore(QuestionID2.ToString()); 
    }
    public void SetIsDoneButtonClicked()
    {
        _APIManager.SetPlayerIsDoneCorWrapper(playerName);
    }
    public void GetIsOtherPlayerDone()
    {
        _APIManager.GetIsOtherPlayerDoneCorWrapper(playerName);
    }
    public void GetOtherPlayerScore()
    {
        _APIManager.GetOtherPlayerScoreCorWrapper(playerName);
    }
    public void Winner(string otherScore)
    {
        if (int.Parse(otherScore) > score)
        {
            LoseImage.SetActive(true);
        }
        else if (int.Parse(otherScore) < score)
        {
            WinImage.SetActive(true);
        }
        else
        {
            DrawImage.SetActive(true);
        }
    }
    public void EndGame(string done)
    {
        if (done == "1")
        {
            GetOtherPlayerScore();
            WaitImage.SetActive(false); 
        }
    }
    public void UpdateQuestionText(Question question)
    {
        if (QuestionID > 10)
            return;

        QuestionText.text = question.text;
        UpdateAnswersText(question.ans1, question.ans2, question.ans3, question.ans4);
        QuestionID++;
    }
    public void UpdateScore(Question question)
    {
        if (PlayerGlobal.timeLeft <= 0)
        {
            QuestionID2++;
            return;
        }
        
        if (QuestionID >= 10 || QuestionID2 >= 10)
        {
            return;
        }

        if (playerAnswer.text == question.correct.ToString())
        {
            score++;
            _APIManager.SetPlayerScoreCorWrapper(score, playerName);
        }
        QuestionID2++;
    }
    public void UpdateAnswersText(string ans1, string ans2, string ans3, string ans4)
    {
        AnswerText1.text = ans1;
        AnswerText2.text = ans2;
        AnswerText3.text = ans3;
        AnswerText4.text = ans4;
    }
}