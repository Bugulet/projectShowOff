using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private AnimalTeam currentSessionTeam = AnimalTeam.Empty;

    private string currentSessionName = "";

    [SerializeField]
    private Text scoreGameObject, currentSessionGameObject;

    public void Start()
    {
        if (scoreGameObject != null && currentSessionGameObject!=null)
        {
            scoreGameObject.text = "";
            currentSessionGameObject.text = "";

            List<ScoreObject> scoreSessions = GetAllSessions();

            ScoreObject currentSession = scoreSessions[scoreSessions.Count - 1];
            currentSessionGameObject.text = currentSession.ToString();

            scoreSessions.Sort((x, y) => y.score - x.score);


            for (int i = 0; i < scoreSessions.Count; i++)
            {
                if (scoreSessions[i] == currentSession)
                {
                    scoreGameObject.text += (i+1) + ". " + scoreSessions[i] + "  <- YOUR SCORE \n" ;
                }
                else
                {
                    scoreGameObject.text +=(i+1)+". " + scoreSessions[i] + "\n";
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

        ScoreObject sessionObject = new ScoreObject(score, name, team);

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

        print(sessionString);
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

        int score = Random.Range(0,150);

        AnimalTeam team = (AnimalTeam) Random.Range(1,4);

        string name = "Random "+Time.frameCount%1000;

        ScoreObject sessionObject = new ScoreObject(score, name, team);

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
    //setters
    public void SetFoxTeam() { currentSessionTeam = AnimalTeam.Fox; }
    public void SetDogTeam() { currentSessionTeam = AnimalTeam.Dog; }
    public void SetCatTeam() { currentSessionTeam = AnimalTeam.Cat; }
    public void SetSessionName(string name) { currentSessionName = name; }

}
