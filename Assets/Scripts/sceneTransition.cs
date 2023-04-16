using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class sceneTransition : MonoBehaviour
{
    public float TimeLeft;
    public float time;
    public int nexScene;
    public bool timeOn = false;
    
    public void start()
    {
        timeOn = true;
        //TimeLeft = 10.0F;
    }

    public void Update()
    {
        Debug.Log(TimeLeft);
        if (timeOn)
        {
            //Debug.Log(TimeLeft);
            if (TimeLeft <= 0.0)
            {
                //Debug.Log("call actDeact");
                changeScene();
            }
            //Debug.Log(TimeLeft);
        }
        TimeLeft -= Time.deltaTime;
        time = updateTimer(TimeLeft);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(nexScene);
    }
    float updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}
