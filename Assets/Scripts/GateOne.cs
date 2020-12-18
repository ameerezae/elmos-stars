using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOne : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameStatus>().AddToTeamZeroScore();
        }
    }
}
