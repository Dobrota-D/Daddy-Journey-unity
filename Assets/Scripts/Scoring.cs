using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField] bool win;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject finalTime;
    [SerializeField] float score;
    public GameObject timer;
    private void Start()
    {
        timer = GameObject.Find("Timer");
        score = timer.GetComponent<Timer>().seconds;
    }
    private void Update()
    {
        if (score < 3)
        {
            ToWin();
        }
        else
        {
            ToLose();
        }
        
    }


    void ToWin()
    {
        winText.SetActive(true);
        loseText.SetActive(false);
    }

    void ToLose()
    {
        winText.SetActive(false);
        loseText.SetActive(true);
    }

}
