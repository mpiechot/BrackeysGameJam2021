using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject levelLoadMenu;
    [SerializeField] private GameObject mainMenu;
    
    public void OnStart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnLoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void OnLoadLevelClose()
    {
        levelLoadMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OnLoadLevelSelected()
    {
        levelLoadMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
