using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    public GameObject SettingsWindows;
   
   public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
        Debug.Log(levelToLoad); 
    }
    public void SettingsButton()
    {
        SettingsWindows.SetActive(true); 
    }
    public void QuitButton()
    {
        Application.Quit(); 
    }
    public void CloseSettingsWindow()
    {
        SettingsWindows.SetActive(false);
    }
}
