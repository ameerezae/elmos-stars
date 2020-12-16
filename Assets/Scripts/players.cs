using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class players : MonoBehaviour
{
    public GameObject[] players0 = new GameObject[5];
    public GameObject[] players1 = new GameObject[5];
    public GameObject ball;
    
    void setTeamPosition(int position, int team)
    {
        float z = -1.5f;
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

    // Start is called before the first frame update
    void Start()
    {
        setTeamPosition(0, 0);
        setTeamPosition(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    
}