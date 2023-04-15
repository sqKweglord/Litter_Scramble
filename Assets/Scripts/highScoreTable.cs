using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
      entryContainer = transform.Find("highScoreEntryContainer");
      entryTemplate = entryContainer.Find("highScoreEntryTemp");

      entryTemplate.gameObject.SetActive(false);

      highscoreEntryList = new List<HighscoreEntry>(){
        new HighscoreEntry{score = 521854, name = "AAA"},
          new HighscoreEntry{score = 441854, name = "BOB"},
            new HighscoreEntry{score = 881854, name = "JIM"},
              new HighscoreEntry{score = 87854, name = "CRAIG"},
                new HighscoreEntry{score = 52300054, name = "50CENT"},
                  new HighscoreEntry{score = 11854, name = "KIMK"},
                    new HighscoreEntry{score = 8781854, name = "SNOOPY"},
          
        };

        //Sorts the scores 
        for(int i = 0; i < highscoreEntryList.Count; i++){
            for(int j = i + 1; j < highscoreEntryList.Count; j++){
                if(highscoreEntryList[j].score > highscoreEntryList[i].score){
                    //swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscoreEntryList){
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //Using Playerprefs for saving and loading data.
        //Using JsonUtility to convert an onject into Json.
        HighScores highScores = new HighScores{highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
   
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

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
            

        transformList.Add(entryTransform);
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
        public string name;
    }

}


