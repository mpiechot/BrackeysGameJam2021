using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void OnContinue()
    {
        pauseMenu.SetActive(false);
        SetTimeScale(1);
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetTimeScale(1);
    }
    public void OnExit()
    {
        SceneManager.LoadScene(0);
        SetTimeScale(1);
    }

    public static void SetTimeScale(float time)
    {
        Time.timeScale = time;
        Time.fixedDeltaTime = 0.02f * time;
    }
}
