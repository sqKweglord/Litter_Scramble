using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoardTimer : MonoBehaviour
{
    public AudioSource sbites;
    public GameObject objectsToActivate;
    public float time;
    public float TimeLeft;
    public bool TimerOn = true;
    private bool played = false;

    void Start()
    {

        TimeLeft = 70.0F;
        time = TimeLeft;
    }

    public void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft <= 68.0 && !played)
            {
                played = true;
                sbites.Play();
            }
            if (TimeLeft <= 58.0)
            {
                objectsToActivate.GetComponent<Button>().interactable = true;
            }
            if (TimeLeft <= 0.0)
            {
                //Debug.Log("call actDeact");
                changeScene();
            }
            TimeLeft -= Time.deltaTime;
            //time = ticTimer(TimeLeft);
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(0);
    }

    float ticTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}
