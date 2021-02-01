﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameStatus : MonoBehaviour
{
    private int teamZeroScore = 0;
    private int teamOneScore = 0;
    private int timeToToggleTurn = 10;
    public int turnTimer = 10;
    public string turn = "TeamZero";
    public int isItFirstShoot = 0;
    public bool goal;
    public AudioSource goalSound;
    public AudioSource whistle;
    public AudioSource cheering;
    [SerializeField] TextMeshProUGUI teamZeroScoreOnBoard;
    [SerializeField] TextMeshProUGUI teamOneScoreOnBoard;
    [SerializeField] TextMeshProUGUI winner;
    [SerializeField] TextMeshProUGUI turnOnBoard;
    [SerializeField] TextMeshProUGUI turnTimeOnBoard;
    
    void Start()
    {
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        turnTimeOnBoard.text = turnTimer.ToString();
        turnOnBoard.text = turn == "TeamZero" ? "Red" : "Yellow";
        winner.text = "";
    }

    private void Update()
    {
        FindObjectOfType<players>().showmask(turn == "TeamZero");
    }


    public void AddToTeamZeroScore()
    {
        if (FindObjectOfType<GameStatus>().isItFirstShoot > 1)
        {
            goalSound.Play();
            teamZeroScore++;
            teamZeroScoreOnBoard.text = teamZeroScore.ToString();
            
            
        }

        isItFirstShoot = 0;

        if (teamZeroScore == 3)
        {
            introduceWinner("Red");
            cheering.Play();
        }
        
        StartCoroutine(ReArrangeTeams());
    }

    public void AddToTeamOneScore()
    {
        if (FindObjectOfType<GameStatus>().isItFirstShoot > 1)
        {
            goalSound.Play();
            teamOneScore++;
            teamOneScoreOnBoard.text = teamOneScore.ToString();
        }

        isItFirstShoot = 0;
        

        if (teamOneScore == 3)
        {
            introduceWinner("Yellow");
            cheering.Play();
        }

        StartCoroutine(ReArrangeTeams());
    }

    private void introduceWinner(string theWinner)
    {
        winner.text = theWinner + " Team Is Winner";
        teamOneScore = 0;
        teamZeroScore = 0;
        turnTimer = 10;
        turn = theWinner == "Red" ? "TeamZero" : "TeamOne";
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        turnTimeOnBoard.text = turnTimer.ToString();
        
        StopAllCoroutines();

        StartCoroutine(PlayGameAgain());
    }

    public void ToggleTurn()
    {
        
        StopAllCoroutines();
        turnTimer = 10;
        turn = turn == "TeamOne" ? "TeamZero" : "TeamOne";
        turnOnBoard.text = turn == "TeamZero" ? "Red" : "Yellow";
        StartCoroutine(ManageTurnTimer());
        StartCoroutine(ManageTurn());
        
        
    }


    private IEnumerator ToggleTurnAfterTime()
    {
        yield return new WaitForSeconds(timeToToggleTurn);
        ToggleTurn();
        
    }

    public IEnumerator ManageTurn()
    {
        while (true)
        {
            yield return StartCoroutine(ToggleTurnAfterTime());
        }
    }

    private IEnumerator DecreaseTurnTimer()
    {
        turnTimeOnBoard.text = turnTimer.ToString();
        yield return new WaitForSeconds(1);
        turnTimer--;
        turnTimeOnBoard.text = turnTimer.ToString();
        if (turnTimer < 0)
        {
            turnTimer = 10;
        }
    }

    private IEnumerator ManageTurnTimer()
    {
        while (true)
        {
            yield return StartCoroutine(DecreaseTurnTimer());   
        }
    }

    private IEnumerator PlayGameAgain()
    {
        yield return new WaitForSeconds(3);
        FindObjectOfType<SceneLoader>().LoadVictoryScene();
    }

    private IEnumerator ReArrangeTeams()
    {
        
        yield return new WaitForSeconds(2);
        goal = true;
        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);
        whistle.Play();
    }
}
