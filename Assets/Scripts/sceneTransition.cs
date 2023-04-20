using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class sceneTransition : MonoBehaviour
{
    public float TimeLeft;
    public float time;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    public void start()
    {
        //Debug.Log(GameVariables.lastScene);
        //Debug.Log(TimeLeft);
        time = TimeLeft;
    }

    public void Update()
    {
        //Debug.Log(TimeLeft);
        if (time != 0)
        {
            TimeLeft -= Time.deltaTime;
            time = updateTimer(TimeLeft);
            timerText.text = time.ToString();
        }
        else
        {
            TimeLeft -= Time.deltaTime;
            time = updateTimer(TimeLeft);
            timerText.text = time.ToString();
            //Debug.Log("call actDeact");
            changeScene();
        }
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
