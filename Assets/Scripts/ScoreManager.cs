//This Script initializes and updates the score text field 
//the text field will need to be flipped so it will read correctly on the holofil
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    private int score;

    // initializes the text and score to 0
    void Start()
    {
        score = 0;
        textScore.text = "Score: " + score.ToString();  
    }

    //updates the field using a private method
    private void WriteScore()
    {
        textScore.text = "Score: " + score.ToString();
        //Debug.Log("Score updated");
    }

    //updates the score and write to the UI
    public void add()
    {
        score += 1;
        WriteScore();
    }

    public void sub()
    {
        if ((score != 0) && (score - 2 > 0))
        {
            score -= 2;
            WriteScore();
        } else
        {
            score = 0;
        }
    }

    public int getScore()
    {
        return score;
    }
}
