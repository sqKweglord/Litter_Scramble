using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private levelTimer timer;
    void Start()
    {
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void replay()
    {
        timer.restartGame();
    }
}
