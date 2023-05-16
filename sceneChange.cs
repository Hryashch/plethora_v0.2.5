using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    private void Start()
    {
        //Screen.fullScreen = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }

}
