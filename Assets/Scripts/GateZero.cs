using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class GateZero : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameStatus>().AddToTeamOneScore();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        moveOutFromGate(other);
    }


    private void moveOutFromGate(Collider obj)
    {
        if (!obj.CompareTag("Ball") &&
            obj.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) 
            && !FindObjectOfType<GameStatus>().goal)
        {
            obj.transform.position += new Vector3(4, 0, 0);
        }
    }
}
