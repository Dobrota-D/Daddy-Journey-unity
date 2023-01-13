using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    [SerializeField] int countDownTime;
    [SerializeField] Text countDownDisplay;
    [SerializeField] GameObject player;
    [SerializeField] GameObject message;
    [SerializeField] GameObject dadPixel;
    [SerializeField] GameObject audioManager;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject timer;
    private void Awake()
    {
        timer.SetActive(false);
    }

    private void Start()
    {
        player.SetActive(false);
        dadPixel.SetActive(true);
        message.SetActive(true);
        audioManager.SetActive(false);

        StartCoroutine(CountDownToStart());

    }

    IEnumerator CountDownToStart()
    {
  
        //décompte 
        countDownDisplay.text = "3";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "2";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "1";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "GO !";

        yield return new WaitForSeconds(1f);
        //on cache le texte du décompte
        countDownDisplay.gameObject.SetActive(false);
        //on passe la variable isMoving à true pour pouvoir dans PlayerMouvement donner dees mouvements au Player
        player.SetActive(true);
        message.SetActive(false);
        dadPixel.SetActive(false);
        scoreText.SetActive(true);
        timer.SetActive(true);
        audioManager.SetActive(true);


    }
}
