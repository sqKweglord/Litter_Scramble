//This Script initializes and updates the score text field 
//the text field will need to be flipped so it will read correctly on the holofil
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;

    // initializes the text and score to 0
    void Start()
    {
        score = 0f;
        textScore.text = "Score: " + score.ToString();  
    }

    //updates the field using a private method
    private void WriteScore()
    {
        textScore.text = "Score: " + score.ToString();
        //Debug.Log("Score updated");
    }

    //a public wrapper method that can be called in other classes
    public void sendScore()
    {
        WriteScore();
    }
}
