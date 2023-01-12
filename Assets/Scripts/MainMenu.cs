using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    public GameObject SettingsWindow;
   
   public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
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
}
