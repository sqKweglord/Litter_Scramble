using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class inactivityTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime = 0f;
    public float inactivityTime = 60f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!Input.anyKey)
        {
            currentTime = currentTime += Time.deltaTime;
            if (currentTime > inactivityTime)
            {
                changeScene();
                currentTime = 0;
            }
            SetTimerText();
        }
        else currentTime = 0f;


        SetTimerText();
    }

        private void SetTimerText()
    {
        int minutes = (int)(currentTime / 60) % 60;
        int seconds = (int)(currentTime % 60);
        timerText.text = "Time Remaining " + string.Format("{0:0}:{1:00}", minutes, seconds);

    }

        public void changeScene()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    
    }
}
