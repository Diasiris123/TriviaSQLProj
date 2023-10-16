using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextQuestionButtonBehavior : MonoBehaviour
{
    public UIManager _uiManager;
    public GameObject nextQuestionImage1;
    public GameObject nextQuestionImage2;
    public GameObject nextQuestionImage3;
    public GameObject nextQuestionImage4;
    public GameObject nextQuestionImage5;
    public GameObject nextQuestionImage6;
    public GameObject nextQuestionImage7;
    public GameObject nextQuestionImage8;
    public GameObject nextQuestionImage9;
    public GameObject nextQuestionImage10;
    public GameObject EndGamePanel;
    public TimerScript timer;

    public void OnButtonClickedNextBackground()
    {
        timer.Restart();
        if (nextQuestionImage1.activeSelf)
        {
            nextQuestionImage2.SetActive(true);
            nextQuestionImage1.SetActive(false);
        }
        else if (nextQuestionImage2.activeSelf)
        {
            nextQuestionImage3.SetActive(true);
            nextQuestionImage2.SetActive(false);
        }
        else if(nextQuestionImage3.activeSelf)
        {
            nextQuestionImage4.SetActive(true);
            nextQuestionImage3.SetActive(false);
        }
        else if(nextQuestionImage4.activeSelf)
        {
            nextQuestionImage5.SetActive(true);
            nextQuestionImage4.SetActive(false);
        }
        else if(nextQuestionImage5.activeSelf)
        {
            nextQuestionImage6.SetActive(true);
            nextQuestionImage5.SetActive(false);
        }
        else if(nextQuestionImage6.activeSelf)
        {
            nextQuestionImage7.SetActive(true);
            nextQuestionImage6.SetActive(false);
        }
        else if(nextQuestionImage7.activeSelf)
        {
            nextQuestionImage8.SetActive(true);
            nextQuestionImage7.SetActive(false);         
        }
        else if(nextQuestionImage8.activeSelf)
        {
            nextQuestionImage9.SetActive(true);
            nextQuestionImage8.SetActive(false);  
        }
        else if(nextQuestionImage9.activeSelf)
        {
            nextQuestionImage10.SetActive(true);
            nextQuestionImage9.SetActive(false); 
        }
        else
        {
            EndGamePanel.SetActive(true);
            nextQuestionImage10.SetActive(false);
            _uiManager.SetIsDoneButtonClicked();
        }
    }
}
