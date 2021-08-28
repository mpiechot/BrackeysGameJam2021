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
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnExit()
    {
        SceneManager.LoadScene(0);
    }
}
