using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    /*
        Starter / Menu Screen Buttons
    */

    //Settings Button
    public void SettingsScene() {
        SceneManager.LoadScene("Settings");
    }

    //Start Button
    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit Button
    public void QuitGame() {
        //Quits in Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
    }


    /*
        Setting Screen Buttons
    */

    //Back Button - Settings Screen
    public void BackButton() {
        SceneManager.LoadScene("Starter Screen");
    }


    /*
        End Screen Buttons
    */

    //Main Menu Button
    public void ReturnStart() {
        SceneManager.LoadScene("Starter Screen");
    }
}