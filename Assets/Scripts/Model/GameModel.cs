using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager
{
    private int teamScore;
    private int opponentScore;

    public void IncreaseTeamScore()
    {
        teamScore++;
    }

    public void IncreaseOpponentScore()
    {
        opponentScore++;
    }

    public int GetTeamScore()
    {
        return teamScore;
    }

    public int GetOpponentScore()
    {
        return opponentScore;
    }
}

public class GameModel
{
    private List<int> team = new List<int>();
    private List<int> opponent = new List<int>();
    private String turn = "team";
    private int turnTimer;
    private int constantTimer;
    
    public void GenerateGame(int teamsSize, int timer)
    {
        for (int i = 0; i < teamsSize; i++)
        {
            team.Add(i);
            opponent.Add(i);
        }

        turnTimer = timer;
        constantTimer = timer;
    }

    public List<int> GetTeam()
    {
        return team;
    }

    public List<int> GetOpponent()
    {
        return opponent;
    }

    public void ToggleTurn()
    {
        turn = turn == "team" ? "opponent" : "team";
    }

    public String GetTurn()
    {
        return turn;
    }

    public void DecreaseTimer()
    {
        turnTimer--;
        if (turnTimer < 0) turnTimer = 0;
    }
    
    public void ResetTimer()
    {
        turnTimer = constantTimer;
    }

    public int GetTimer()
    {
        return turnTimer;
    }

}
