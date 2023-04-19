using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class IntroStart : MonoBehaviour
{
    public AudioSource sbites;
    public GameObject objectsToActivate;
    public float time;
    public float TimeLeft;
    public bool TimerOn = true;

    void Start()
    {
        
        TimeLeft = 46.0F;
    }

    public void Update()
    {
        if (TimerOn)
        {
            if (time == 44.0 && !sbites.isPlaying)
            {
                sbites.Play();
            }
            if (time == 31.0)
            {
                objectsToActivate.GetComponent<Button>().interactable = true;
            }
            if (time == 0.0)
            {
                //Debug.Log("call actDeact");
                changeScene();
            }
            TimeLeft -= Time.deltaTime;
            time = ticTimer(TimeLeft);
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }

    float ticTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}