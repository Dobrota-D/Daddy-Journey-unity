using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}