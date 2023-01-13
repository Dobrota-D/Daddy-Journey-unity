using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] bool win;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

    [SerializeField] float score;

    private void Update()
    {


        if (score < 45)
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
