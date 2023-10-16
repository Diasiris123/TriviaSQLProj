using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeStart = 10;
    public TextMeshProUGUI timerText;
    public Button nextQuestionButton;
    void Start()
    {
        timerText.text = timerText.ToString();
        PlayerGlobal.timeLeft = timeStart;
    }
    void Update()
    {
        if (timeStart <= 0)
        {
            NextStart();
            return;
        }
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        PlayerGlobal.timeLeft = timeStart;
    }

    public void NextStart()
    {
        nextQuestionButton.onClick.Invoke();
    }

    public void Restart()
    {
        timeStart = 10;
        PlayerGlobal.timeLeft = timeStart;
    }
}
