﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    private int teamZeroScore = 0;
    private int teamOneScore = 0;
    public string turn = "TeamZero";
    [SerializeField] TextMeshProUGUI teamZeroScoreOnBoard;
    [SerializeField] TextMeshProUGUI teamOneScoreOnBoard;

    
    
    // Start is called before the first frame update
    void Start()
    {
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTeamZeroScore()
    {
        teamZeroScore++;
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);

    }

    public void AddToTeamOneScore()
    {
        teamOneScore++;
        teamOneScoreOnBoard.text = teamOneScore.ToString();

        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);
    }

    public void ToggleTurn()
    {
        turn = turn == "TeamOne" ? "TeamZero" : "TeamOne";
    }
}
