using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float seconds;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            DecreasedTimer();
        }
    }
    void StartTimer()
    {
        isRunning = true;
    }

    void DecreasedTimer()
    {
        if (seconds < 1)
        {
            seconds = 0; //Make sure the seconds won't be negative
            isRunning = false;
            return;
        }
        seconds -= Time.deltaTime;
    }

    public string DisplayTime()
    {
        float minute = Mathf.FloorToInt(seconds / 60);
        float sec = Mathf.FloorToInt(seconds % 60);
        return string.Format("{0:00}:{1:00}", minute, sec);
    }
}
