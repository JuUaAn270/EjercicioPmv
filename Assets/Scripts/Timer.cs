using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;

        string hours = ((int)t / 3600).ToString("00");
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");

        timerText.text = hours + ":" + minutes + ":" + seconds;
    }
}