using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoardTimer : MonoBehaviour
{
    public AudioSource sbites;
    public GameObject objectsToActivate;
    public float TimeLeft;
    public bool TimerOn = true;
    private bool played = false;

    void Start()
    {
        TimeLeft = 70.0F;
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
                changeScene();
            }
            TimeLeft -= Time.deltaTime;
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(0);
    }
}
