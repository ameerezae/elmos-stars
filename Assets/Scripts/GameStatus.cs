using System.Collections;
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
    [SerializeField] TextMeshProUGUI winner;

    
    
    // Start is called before the first frame update
    void Start()
    {
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        winner.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTeamZeroScore()
    {
        teamZeroScore++;
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        if (teamOneScore == 3)
        {
            winner.text = "Red Team Is Winner";
            teamZeroScore = 0;
            teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        }
        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);

    }

    public void AddToTeamOneScore()
    {
        teamOneScore++;
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        if (teamOneScore == 3)
        {
            winner.text = "Yellow Team Is Winner";
            teamOneScore = 0;
            teamOneScoreOnBoard.text = teamOneScore.ToString();
        }
        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);
        
    }

    public void ToggleTurn()
    {
        turn = turn == "TeamOne" ? "TeamZero" : "TeamOne";
    }
}
