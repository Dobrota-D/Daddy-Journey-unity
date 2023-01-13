using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] bool isGameFinished;
    public Text scoreText;
    public float seconds;
    private bool isRunning = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
// Start is called before the first frame update
void Start()
    {
        StartTimer();
        //if(!isGameFinished) scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        //if (isGameFinished) scoreText = GameObject.Find("FinalScore").GetComponent<Text>();
        if (isRunning && isGameFinished == false)
        {
            print("is game finished "  +  isGameFinished);
            IncreaseTimer();
        }
        scoreText.text = DisplayTime();
    }

    void StartTimer()
    {
        isRunning = true;
    }

    void IncreaseTimer()
    {
        seconds += Time.deltaTime;
        //decompte
        //seconds -= Time.deltaTime;

        float minute = Mathf.FloorToInt(seconds / 60);
        float sec = Mathf.FloorToInt(seconds % 60);
        if (sec < 10)
        {
            scoreText.text = minute + " :0" + sec.ToString();
        }
        else
        {
            scoreText.text = minute + " : " + sec.ToString();
        }
    }

    public string DisplayTime()
    {
        float minute = Mathf.FloorToInt(seconds / 60);
        float sec = Mathf.FloorToInt(seconds % 60);
        return string.Format("{0:00}:{1:00}", minute, sec);
    }

    public void SetGameFinished(bool b)
    {

        isGameFinished = b;
        print("is game finished " + isGameFinished);

    }
    public bool GetIsGameFinished()
    {
        return isGameFinished;
    }


}
