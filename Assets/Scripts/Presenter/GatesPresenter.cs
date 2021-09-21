using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesPresenter : MonoBehaviour
{

    private GamePresenter _gamePresenter;

    private void Awake()
    {
        _gamePresenter = FindObjectOfType<GamePresenter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (tag == "LeftGate")
            {
                _gamePresenter.IncreaseOpponentScore();
            }
            else
            {
                _gamePresenter.IncreaseTeamScore();
            }
            StartCoroutine(_gamePresenter.ReArrangeTeam());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        moveOutFromGate(other);
    }
    
    
    private void moveOutFromGate(Collider obj)
    {
        if (!obj.CompareTag("Ball")
            && obj.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)
            // && !FindObjectOfType<GameStatus>().goal
            )
        {
            if (tag == "LeftGate")
            {
                obj.transform.position += new Vector3(4, 0, 0);
            }
            else
            {
                obj.transform.position -= new Vector3(4, 0, 0);
            }
            
        }
    }
}