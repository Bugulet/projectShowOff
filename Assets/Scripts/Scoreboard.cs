using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;


public class Scoreboard : MonoBehaviour
{
    private AnimalTeam currentSessionTeam = AnimalTeam.Empty;

    private string currentSessionName = "";

    private int currentFeedback = 0;

    [SerializeField]
    private GameObject scoreGameObject, currentSessionGameObject, scoreElement;
    

    public void Start()
    {
        PrintAllSessions();

        if (scoreGameObject != null && currentSessionGameObject!=null)
        {
            
            List<ScoreObject> scoreSessions = GetAllSessions();

            ScoreObject currentSession = scoreSessions[scoreSessions.Count - 1];
            

            scoreSessions.Sort((x, y) => y.score - x.score);


            for (int i = 0; i < scoreSessions.Count; i++)
            {
                GameObject newElement = Instantiate(scoreElement, scoreGameObject.transform);

                newElement.transform.GetChild(1).GetComponent<Text>().text = (i + 1).ToString();
                newElement.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = scoreSessions[i].name;
                newElement.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = scoreSessions[i].score.ToString();
                newElement.transform.GetChild(4).transform.GetChild((int)scoreSessions[i].team-1).gameObject.SetActive(true);

                if (scoreSessions[i] == currentSession)
                {
                    newElement.transform.GetChild(0).gameObject.SetActive(true);
                }
                
            }
        }
        else
        {
            print("score gameobject is not set");
        }

    }

    public void CreateNewEntry()
    {

        int sessionCounter;

        int score = PlayerPrefs.GetInt("score");

        AnimalTeam team = currentSessionTeam;

        string name = currentSessionName;

        int feedback = currentFeedback;

        ScoreObject sessionObject = new ScoreObject(score, name, team,feedback);

        string sessionString = JsonUtility.ToJson(sessionObject);

        if (PlayerPrefs.HasKey("sessionCounter"))
        {
            sessionCounter = PlayerPrefs.GetInt("sessionCounter");
        }
        else
        {
            sessionCounter = 0;
            PlayerPrefs.SetInt("sessionCounter", sessionCounter);
        }

        PlayerPrefs.SetString(sessionCounter + "sessionKey", sessionString);
        PlayerPrefs.SetInt("sessionCounter", sessionCounter + 1);

        //create entry on text file
       /* {
            sessionString += string.Format(" Played: {0} seconds, at {1}", Time.time, System.DateTime.Today);

            print(sessionString);

            string path = @"museumFile.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(sessionString);
                }
                return;
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(sessionString);
            }
        }*/
        
        
    }

    public void PrintAllSessions()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("sessionCounter"); i++)
        {
            string jsonSession = PlayerPrefs.GetString(i + "sessionKey");
            ScoreObject sessionObject = JsonUtility.FromJson<ScoreObject>(jsonSession);
            print(jsonSession);
        }
    }

    public List<ScoreObject> GetAllSessions()
    {
        List<ScoreObject> sessionHolder = new List<ScoreObject>();

        for (int i = 0; i < PlayerPrefs.GetInt("sessionCounter"); i++)
        {
            string jsonSession = PlayerPrefs.GetString(i + "sessionKey");
            ScoreObject sessionObject = JsonUtility.FromJson<ScoreObject>(jsonSession);
            sessionHolder.Add(sessionObject);
        }

        return sessionHolder;
    }

    public void DeleteAllUserPref()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("sessionCounter"); i++)
        {
            PlayerPrefs.DeleteKey(i + "sessionKey");
        }
        PlayerPrefs.DeleteKey("sessionCounter");
    }

    public void AddRandomSession()
    {
        int sessionCounter;

        int score = UnityEngine.Random.Range(0,150);

        AnimalTeam team = (AnimalTeam)UnityEngine.Random.Range(1,4);

        string name = "Random "+Time.frameCount%1000;

        int feedback = UnityEngine.Random.Range(1, 6);

        ScoreObject sessionObject = new ScoreObject(score, name, team,feedback);

        string sessionString = JsonUtility.ToJson(sessionObject);

        if (PlayerPrefs.HasKey("sessionCounter"))
        {
            sessionCounter = PlayerPrefs.GetInt("sessionCounter");
        }
        else
        {
            sessionCounter = 0;
            PlayerPrefs.SetInt("sessionCounter", sessionCounter);
        }

        PlayerPrefs.SetString(sessionCounter + "sessionKey", sessionString);
        PlayerPrefs.SetInt("sessionCounter", sessionCounter + 1);
        print("Added random session: "+ sessionString);
    }

    //getters
    public int GetFeedback() { return currentFeedback; }

    //setters
    public void SetFeedback(int value) { currentFeedback = value; }
    public void SetFoxTeam() { currentSessionTeam = AnimalTeam.Fox; }
    public void SetDogTeam() { currentSessionTeam = AnimalTeam.Dog; }
    public void SetCatTeam() { currentSessionTeam = AnimalTeam.Cat; }
    public void SetSessionName(string name) { currentSessionName = name; }

}
