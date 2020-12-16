using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static float time = 20;
    private float t = time;
    public Text Time0;
    private bool turn = false;
    public int a = 1;

    private void Start()
    {
        Time0.text = t.ToString();
    }

    void Update()
    {
        t -= a * Time.deltaTime;
        Time0.text = Mathf.Round(t).ToString();
        if (Mathf.RoundToInt(t) == -1 || Mathf.RoundToInt(t) == time + 1)
        {
            a *= -1;
        }
    }
}