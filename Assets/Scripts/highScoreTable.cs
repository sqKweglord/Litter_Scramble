using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Linq;

public class highScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private static string path;

    private void Start() {
        Debug.Log(Application.persistentDataPath);
        //path to file
        path = Application.persistentDataPath + "/scores.txt";
        
        //gets the current players score
        int newScore = GameVariables.score;
        //resets the current players score for when the game gets restart
        GameVariables.score = 0;
        //reads the old scores in from the file
        int[] scores = ReadScores();
        

      entryContainer = transform.Find("highScoreEntryContainer");
      entryTemplate = entryContainer.Find("highScoreEntryTemp");

      entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>();

        //adds scores to entry objects
        foreach(int score in scores)
        {
            highscoreEntryList.Add(new HighscoreEntry { score = score });
        }

        //Sorts the scores 
        sortScores();

        //adds the new score to replace the lowest
        HighscoreEntry last = highscoreEntryList.Last();
        last.score = newScore;
        //sets new score to true so that we can check later which entry in the new one
        last.newScore = true;

        //sorts the scores again
        sortScores();

        //saves new scores to file
        int[] newSaveScores = new int[scores.Length];
        int counter = 0;
        foreach(HighscoreEntry e in highscoreEntryList)
        {
            newSaveScores[counter] = e.score;
            counter++;
        }
        WriteScores(newSaveScores);



        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscoreEntryList){
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

        //A function to add a new entry to the table
        private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){

        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch(rank){
            default:
            rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        
        //Checks if the current score is the new score and highlights the score green if it is.
        if(highscoreEntry.newScore){
        entryTransform.Find("posText").GetComponent<Text>().color = Color.blue;
        entryTransform.Find("scoreText").GetComponent<Text>().color = Color.blue;
        }

        transformList.Add(entryTransform);
        }

    //writes scores to a file by converting an int[] to a format string, then overwriting the scores.txt file with the new string
    private static void WriteScores(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        string s;
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]).Append(",");
        }
        s = sb.ToString();

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(s);
        writer.Close();
    }

   //reads the new scores in from the file
    private static int[] ReadScores()
    {
        int[] arr = new int[10];
        try
        {
            StreamReader reader = new StreamReader(path);
            string temp = reader.ReadToEnd();
            reader.Close();

            string[] scoresIn = temp.Split(',');
            arr = new int[scoresIn.Length - 1];
            for (int i = 0; i < scoresIn.Length - 1; i++)
            {
                arr[i] = int.Parse(scoresIn[i]);
            }

        } catch (IOException e) {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }
        
        return arr;
    }

    //a sort function to re-order the HighscoreEntries from highest to lowest
    private void sortScores()
    {
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
    }

    //The function below is to add a new score entry to the score board

        // private void AddHighscoreEntry(int score, string name){
        //     //Create HighscoreEntry
        //     HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name};

        //     //Load saved Highscores
        //     string jsonString = Playerprefs.GetString("highscoreTable");
        //     HighScores highScores = jsonUtility.FromJson<HighScores>(jsonString);

        //     //Add new entry to Highscores
        //     highScores.highscoreEntryList.Add(highscoreEntry);

        //     //Save updated Highscores
        //     string json = JsonUtility.ToJson(highScores);
        //     PlayerPrefs.SetString("highscoretTable", json);
        // }
        private class HighScores{
            public List<HighscoreEntry> highscoreEntryList;
        }
        //Class that creates a single line entry for the scoreboard
        
    private class HighscoreEntry{
        public int score;
        public bool newScore = false;
        //public string name;
    }

}


