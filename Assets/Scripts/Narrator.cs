using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Narrator : MonoBehaviour
{
    [SerializeField] public AudioSource[] sbites;
    public float time;
    private int i = 0;
    public float TimeLeft;
    public bool TimerOn = false;

    void Start()
    {
        TimerOn = true;
        TimeLeft = 10.0F;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                time = updateTimer(TimeLeft);
            }
            else
            {
                playFact(i);
                TimeLeft = 30.0F;
            }
        }
    }
    void playFact(int x)
    {
        sbites[x].Play();
        i++;
    }

    float updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}
