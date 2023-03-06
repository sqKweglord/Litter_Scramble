using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class levelTimer : MonoBehaviour
{
    public GameObject gameOverScreen;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime = 181f;
    public bool countDown;

    [Header("Timer Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            gameOver();
            enabled = false;
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        int minutes = (int)(currentTime / 60) % 60;
        int seconds = (int)(currentTime % 60);
        timerText.text = "Time Remaining " + string.Format("{0:0}:{1:00}", minutes, seconds);

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
 }
