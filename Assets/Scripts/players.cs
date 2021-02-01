using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class players : MonoBehaviour
{
    public GameObject[] players0 = new GameObject[5];
    public GameObject[] players1 = new GameObject[5];
    public GameObject ball;
    public bool stopCounting;
    public float t1, t2;
    public AudioSource kick;
    public void setTeamPosition(int position, int team)
    {
        float z = -1.5f;
        ball.transform.position = new Vector3(0, 0, z);
        FindObjectOfType<GameStatus>().goal = false;
        StopMoving();
        if (team == 0)
        {
            switch (position)
            {
                case 0:
                    players0[0].transform.position = new Vector3(-7, 0, z);
                    players0[1].transform.position = new Vector3(-5, -2.4f, z);
                    players0[2].transform.position = new Vector3(-5, 2.4f, z);
                    players0[3].transform.position = new Vector3(-2.25f, -1f, z);
                    players0[4].transform.position = new Vector3(-2.25f, 1f, z);
                    break;
                case 1:
                    players0[0].transform.position = new Vector3(-5, 0, z);
                    players0[1].transform.position = new Vector3(-5, -2.4f, z);
                    players0[2].transform.position = new Vector3(-5, 2.4f, z);
                    players0[3].transform.position = new Vector3(-2.25f, -2f, z);
                    players0[4].transform.position = new Vector3(-2.25f, 2f, z);
                    break;
            }
        }

        if (team == 1)
        {
            switch (position)
            {
                case 0:
                    players1[0].transform.position = new Vector3(7, 0, z);
                    players1[1].transform.position = new Vector3(5, -2.4f, z);
                    players1[2].transform.position = new Vector3(5, 2.4f, z);
                    players1[3].transform.position = new Vector3(2.25f, -1f, z);
                    players1[4].transform.position = new Vector3(2.25f, 1f, z);
                    break;
                case 1:
                    players1[0].transform.position = new Vector3(5, 0, z);
                    players1[1].transform.position = new Vector3(5, -2.4f, z);
                    players1[2].transform.position = new Vector3(5, 2.4f, z);
                    players1[3].transform.position = new Vector3(2.25f, -2f, z);
                    players1[4].transform.position = new Vector3(2.25f, 2f, z);
                    break;
            }
        }
    }

    
    void Start()
    {
        setTeamPosition(0, 0);
        setTeamPosition(1, 1);
        FindObjectOfType<GameStatus>().whistle.Play();
    }

    void Update()
    {
        t2 = stopCounting ? Time.time : 0 ;
        if (t2 - t1 > 3)
        {
            StopMoving();
            stopCounting = false;
            t1 = 0;
            t2 = 0;
        }
    }
    
    public void StopMoving()
    {
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        foreach (var player in players0)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        foreach (var player in players1)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }

    public void hidemask()
    {
        foreach (var player in players0)
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        foreach (var player in players1)
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;

    }

    public void showmask(bool firstTeam)
    {
        
        if (firstTeam)
        {
            foreach (var player in players0)
                player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            foreach (var player in players1)
                player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        else
        {
            foreach (var player in players1)
                player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            foreach (var player in players0)
                player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }
    
}