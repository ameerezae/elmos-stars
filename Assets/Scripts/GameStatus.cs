using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    private int teamZeroScore = 0;
    private int teamOneScore = 0;
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
        Debug.Log(teamZeroScore);
        teamZeroScore++;
        teamZeroScoreOnBoard.text = teamZeroScore.ToString();
    }

    public void AddToTeamOneScore()
    {
        Debug.Log(teamOneScore);
        teamOneScore++;
        teamOneScoreOnBoard.text = teamOneScore.ToString();
    }
}
