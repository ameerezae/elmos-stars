using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    private int teamZeroScore = 0;
    private int teamOneScore = 0;
    private int timeToToggleTurn = 5;
    public int turnTimer = 5;
    public string turn = "TeamZero";
    [SerializeField] TextMeshProUGUI teamZeroScoreOnBoard;
    [SerializeField] TextMeshProUGUI teamOneScoreOnBoard;
    [SerializeField] TextMeshProUGUI winner;
    [SerializeField] TextMeshProUGUI turnOnBoard;
    [SerializeField] TextMeshProUGUI turnTimeOnBoard;
    


    // Start is called before the first frame update
    void Start()
    {
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        turnTimeOnBoard.text = turnTimer.ToString();
        turnOnBoard.text = turn == "TeamZero" ? "Red" : "Yellow";
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
        if (teamZeroScore == 3)
        {
            introduceWinner("Red");
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
            introduceWinner("Yellow");
        }

        FindObjectOfType<players>().setTeamPosition(0, 0);
        FindObjectOfType<players>().setTeamPosition(1, 1);
    }

    private void introduceWinner(string theWinner)
    {
        winner.text = theWinner + " Team Is Winner";
        teamOneScore = 0;
        teamZeroScore = 0;
        turnTimer = 5;
        turn = theWinner == "Red" ? "TeamZero" : "TeamOne";
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
        teamOneScoreOnBoard.text = teamOneScore.ToString();
        turnTimeOnBoard.text = turnTimer.ToString();
        StopAllCoroutines();
    }

    public void ToggleTurn()
    {
        StopAllCoroutines();
        turnTimer = 5;
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
            turnTimer = 5;
        }
    }

    private IEnumerator ManageTurnTimer()
    {
        while (true)
        {
            yield return StartCoroutine(DecreaseTurnTimer());   
        }
    }
}
