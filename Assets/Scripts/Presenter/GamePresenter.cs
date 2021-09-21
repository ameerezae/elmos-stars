using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    public SoccerStarsConfigs configs;
    public GameObject team;
    public GameObject opponent;
    public GameObject ball;
    public PlayerItemPresenter itemPresenter;
    public List<PlayerItemPresenter> teamPlayers;
    public List<PlayerItemPresenter> opponentPlayers;
    public GameModel gameModel = new GameModel();
    public ScoreManager scoreManager;
    public bool stopCounting;
    public float t1, t2;
    public int shootsCount = 0;
    
    public AudioSource goalSound;
    public AudioSource whistle;
    
    [SerializeField] TextMeshProUGUI teamScoreOnBoard;
    [SerializeField] TextMeshProUGUI opponentScoreOnBoard;
    [SerializeField] TextMeshProUGUI winner;
    [SerializeField] TextMeshProUGUI turnOnBoard;
    [SerializeField] TextMeshProUGUI turnTimeOnBoard;

    public void Awake()
    {
        gameModel.GenerateGame(configs.teamsSize, configs.turnTimer);
        DrawingMap();

        teamScoreOnBoard.text = scoreManager.GetTeamScore().ToString();
        opponentScoreOnBoard.text = scoreManager.GetOpponentScore().ToString();
        turnOnBoard.text = gameModel.GetTurn() == "team" ? "LEFT" : "RIGHT";
        turnTimeOnBoard.text = gameModel.GetTimer().ToString();
        winner.text = "";
        
        whistle.Play();
    }

    public void Update()
    {
        StopPlayersAfterMove();
        ShowPlayersTurnMask(gameModel.GetTurn() == "team");
    }

    public void DrawingMap()
    {
        List<int> teamArray = gameModel.GetTeam();

        for (int i = 0; i < teamArray.Count; i++)
        {
            var teamItem = Instantiate(itemPresenter, team.transform);
            teamItem.SetupItem(i, "team", configs.teamVectors[i], configs.sprites[0]);
            teamPlayers.Add(teamItem);
            var opponentItem = Instantiate(itemPresenter, opponent.transform);
            opponentItem.SetupItem(i, "opponent", configs.opponentVectors[i], configs.sprites[1]);
            opponentPlayers.Add(opponentItem);
        }
    }

    

    public IEnumerator Timer()
    {
        while (true)
        {
            yield return StartCoroutine(DecreaseTimerOneSec());   
        }
    }

    private IEnumerator DecreaseTimerOneSec()
    {
        turnTimeOnBoard.text = gameModel.GetTimer().ToString();
        yield return new WaitForSeconds(1);
        gameModel.DecreaseTimer();
        if (gameModel.GetTimer() ==  0 && !stopCounting)
        {
            
            gameModel.ResetTimer();
            ToggleTurnForPlayers();
        }
    }

    public void ToggleTurnForPlayers()
    {
        StopAllCoroutines();
        gameModel.ResetTimer();
        gameModel.ToggleTurn();
        turnOnBoard.text = gameModel.GetTurn() == "team" ? "LEFT" : "RIGHT";
        StartCoroutine(Timer());
    }
    
    public void IncreaseTeamScore()
    {
        if (shootsCount > 1)
        {
            scoreManager.IncreaseTeamScore();
            if (gameModel.GetTurn() == "opponent")
            {
                ToggleTurnForPlayers();
            }
            teamScoreOnBoard.text = scoreManager.GetTeamScore().ToString();
            goalSound.Play();    
        }

        shootsCount = 0;
    }

    public void IncreaseOpponentScore()
    {
        if (shootsCount > 1)
        {
            scoreManager.IncreaseOpponentScore();
            if (gameModel.GetTurn() == "team")
            {
                ToggleTurnForPlayers();
            }
            opponentScoreOnBoard.text = scoreManager.GetOpponentScore().ToString();
            goalSound.Play();    
        }

        shootsCount = 0;
    }
    
    public void StopMoving()
    {
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        foreach (PlayerItemPresenter player in teamPlayers)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        foreach (PlayerItemPresenter player in opponentPlayers)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }

    public void StopPlayersAfterMove()
    {
        t2 = stopCounting ? Time.time : 0;
        if (t2 - t1 > 3)
        {
            StopMoving();
            stopCounting = false;
            t1 = 0;
            t2 = 0;
        }
    }

    public IEnumerator ReArrangeTeam()
    {
        yield return new WaitForSeconds(2);
        ball.transform.position = new Vector3(0, 0, configs.teamVectors[0].z);
        for (int i = 0; i < teamPlayers.Count; i++)
        {
            teamPlayers[i].ChangePosition(configs.teamVectors[i]);
            opponentPlayers[i].ChangePosition(configs.opponentVectors[i]);
        }
        StopMoving();
        whistle.Play();
    }
    
    public void HidePlayersTurnMask()
    {
        foreach (PlayerItemPresenter player in teamPlayers)
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        foreach (PlayerItemPresenter player in opponentPlayers)
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;

    }

    public void ShowPlayersTurnMask(bool leftSide)
    {
        
        if (leftSide)
        {
            foreach (PlayerItemPresenter player in teamPlayers)
                player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            foreach (PlayerItemPresenter player in opponentPlayers)
                player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        else
        {
            foreach (PlayerItemPresenter player in opponentPlayers)
                player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            foreach (PlayerItemPresenter player in teamPlayers)
                player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }

    
}