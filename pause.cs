using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    [SerializeField] private AudioSource m;
    public GameObject pauseUI;
    public static bool isPaused = false;
    void Start()
    {
        pauseUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                ResumeTheGame();
            }
            else
            {
                PauseTheGame();
            }
        }
    }
    public void ResumeTheGame()
    {
        m.UnPause();
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void PauseTheGame()
    {
        m.Pause();
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
