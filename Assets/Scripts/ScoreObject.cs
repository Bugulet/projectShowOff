using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalTeam
{
    Empty,Fox,Dog,Cat
}

public class ScoreObject
{
    public int score = 0;
    public string name = "";
    public AnimalTeam team=AnimalTeam.Empty;

    public ScoreObject(int _score, string _name, AnimalTeam _team)
    {
        score = _score;
        name = _name;
        team = _team;
    }

    public override string ToString()
    {
        return string.Format("Score: {0}   Name: {1}   Team:{2}", score, name, team);
    }
}
