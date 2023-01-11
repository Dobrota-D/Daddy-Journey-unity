using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScoreScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Je passe");
            SceneManager.LoadScene("scoreScene");
        }
    }
}
