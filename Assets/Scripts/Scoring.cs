using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField] bool win;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject finalTime;
    public AudioClip clip;
    [SerializeField] float score;
    public GameObject timer;
    public AudioClip winSound;
    public AudioClip loseSound;
    public float volume = 0.3f;
    private void Start()
    {
        timer = GameObject.Find("Timer");
        score = timer.GetComponent<Timer>().seconds;
        if (score < 3)
        {
            ToWin();
            AudioManager.instance.PlayGingle(winSound, transform.position, volume);
            // winSound.PlayOneShot(clip, volume);
        }
        else
        {
            ToLose();
            AudioManager.instance.PlayGingle(loseSound, transform.position, volume);
            // loseSound.PlayOneShot(clip, volume);
        }
    }
    private void Update()
    {
       

        
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
