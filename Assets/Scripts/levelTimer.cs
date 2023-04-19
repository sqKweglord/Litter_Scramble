using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class levelTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime = 181f;
    public bool countDown;

    [Header("Timer Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    private ScoreManager score;

    void Start()
    {
        score = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        GameVariables.lastScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            changeScene();
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

    public void changeScene()
    {
        GameVariables.score += score.getScore();
        SceneManager.LoadScene(5);
    }
 }
