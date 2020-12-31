using System;
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

    private void OnTriggerStay(Collider other)
    {
        // if (other.gameObject.CompareTag("Ball") && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.1)
        // {
        //     FindObjectOfType<GameStatus>().AddToTeamZeroScore();
        // }
        moveOutFromGate(other);
    }


    private void moveOutFromGate(Collider obj)
    {
        if (!obj.CompareTag("Ball") &&
            obj.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)
            && !FindObjectOfType<GameStatus>().goal)
        {
            obj.transform.position -= new Vector3(4, 0, 0);
        }
    }
}