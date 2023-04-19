using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class inactivityTimer : MonoBehaviour
{
    //Editable settings for the timer
    [Header("Component")]
    //public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime = 0f;
    public float inactivityTime = 60f;

    // Detects player input into game. Counts up when no input is given. Resets to 0 when input is given.
    void Update()
    {
        //Debug.Log(GameManager.Instance.anyInput);
        if (!GameVariables.anyInput) {
            currentTime = currentTime += Time.deltaTime;
            if (currentTime > inactivityTime)
            {
                changeScene();
                currentTime = 0;
            }
            //SetTimerText();
        } else {
            currentTime = 0f;
                }
        //SetTimerText();
    }

    //For testing the timer
    /*
        private void SetTimerText()
    {
        int minutes = (int)(currentTime / 60) % 60;
        int seconds = (int)(currentTime % 60);
        timerText.text = "Time Remaining " + string.Format("{0:0}:{1:00}", minutes, seconds);

    }
    */

    //To send the game back to menu if inactivity timer pops.
        public void changeScene()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    
    }
}
