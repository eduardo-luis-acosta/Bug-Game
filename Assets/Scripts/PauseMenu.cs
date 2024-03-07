using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Is Game Paused?
    public static bool IsPaused = false;

    //Pause Menu
    public GameObject pauseUI;

    //Settings Menu
    public GameObject settingsUI;

    //Checks to see if the game is already paused
    bool pausedAlready = false;

    // Update is called once per frame
    void Update()
    {
        //Escape Key pauses the game and checks to see if the SettingsUI is already active
        if(Input.GetKeyDown(KeyCode.Escape) && !(pausedAlready)) {
            //if isPaused == true
            if(IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }


    public void Resume() {
        //Disable Pause
        pauseUI.SetActive(false);

        //Unfreeze Game Time
        Time.timeScale = 1f;

        //Pause == false
        IsPaused = false;
    }

    public void Pause() { 
        //Enable Pause Menu
        pauseUI.SetActive(true);

        //Freeze Game Time
        Time.timeScale = 0f;

        //Pause == true
        IsPaused = true;
    }

    //Settings Menu
    public void Settings() {
        //Freeze Game Time
        Time.timeScale = 0f;

        pauseUI.SetActive(false);
        settingsUI.SetActive(true);

        pausedAlready = true;

        //Pause == true
        IsPaused = true;
    }

    //Go Back To Pause Menu
    public void BackSettings() {
        //Freeze Game Time
        Time.timeScale = 0f;

        pauseUI.SetActive(true);
        settingsUI.SetActive(false); 

        pausedAlready = false;

        //Pause == true
        IsPaused = true;
    }
}
