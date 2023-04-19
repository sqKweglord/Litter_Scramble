using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class StartMenu : MonoBehaviour
{
    public GameObject creditsFirst, menuClosedFirst;
    public GameObject canvas;

    public float TimeLeft;

     void Awake () {
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 30;
 }

    public void Update()
    {
        if (canvas.activeSelf)
        {
            if (TimeLeft <= 0.0)
            {
                closeCredits();
            }
            //Debug.Log(TimeLeft);
            TimeLeft -= Time.deltaTime;
        } else if (TimeLeft != 60f){
            TimeLeft = 80f;
        }
        
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Credits()
    {
        canvas.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirst);
    }

    public void closeCredits()
    {
        canvas.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuClosedFirst);
    }

    float updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}
