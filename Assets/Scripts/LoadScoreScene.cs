using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadScoreScene : MonoBehaviour
{
    [SerializeField] Animator fadeSystem;
    [SerializeField] GameObject timeOut;
    [SerializeField] Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timeOut.SetActive(false);   
            StartCoroutine(loadNextScene());
        }
    }
    public IEnumerator loadNextScene()
    {

        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("scoreScene");
        timer.SetGameFinished(true);
    }
}
