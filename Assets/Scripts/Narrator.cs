using UnityEngine;


public class Narrator : MonoBehaviour
{
    [SerializeField] public AudioSource[] sbites;
    private int i = 0;
    public float TimeLeft;
    public bool TimerOn = false;

    void Start()
    {
        TimerOn = true;
        TimeLeft = 10.0F;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                playFact(i);
                TimeLeft = 30.0F;
            }
        }
    }
    void playFact(int x)
    {
        sbites[x].Play();
        i++;
    }
}
