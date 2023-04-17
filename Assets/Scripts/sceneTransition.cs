using UnityEngine;
using UnityEngine.SceneManagement;



public class sceneTransition : MonoBehaviour
{
    public float TimeLeft;
    public float time;
    public bool timeOn = false;
    
    public void start()
    {
        timeOn = true;
        Debug.Log(GameVariables.lastScene);
        //TimeLeft = 10.0F;
    }

    public void Update()
    {
        //Debug.Log(TimeLeft);
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
        if (GameVariables.lastScene == 1)
        {
            SceneManager.LoadScene(2);
        } else if (GameVariables.lastScene == 2)
        {
            SceneManager.LoadScene(3);
        }

    }
    float updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
        return seconds;
    }
}
