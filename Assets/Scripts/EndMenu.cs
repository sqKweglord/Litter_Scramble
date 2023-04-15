using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private levelTimer timer;
    private ScoreManager score;
    void Start()
    {
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();
        score = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }
    public void ChangeScene(int scene)
    {
        if (scene != 0)
        {
            GameVariables.score += score.getScore();
        } else
        {
            GameVariables.score = 0;
        }

        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void replay()
    {
        timer.restartGame();
    }
}
