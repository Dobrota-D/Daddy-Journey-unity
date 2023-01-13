using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    public GameObject SettingsWindow;
    [SerializeField] Animator fadeSystem;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject quitButton;

    public void StartGame()
    {
        playButton.SetActive(false);
        settingsButton.SetActive(false);    
        quitButton.SetActive(false);    
        StartCoroutine(loadNextScene());
        Debug.Log(levelToLoad); 
    }
    public void SettingsButton()
    {
        SettingsWindow.SetActive(true); 
    }
    public void QuitButton()
    {
        Application.Quit(); 
    }
    public void CloseSettingsWindow()
    {
        SettingsWindow.SetActive(false);
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelToLoad);
    }
}
