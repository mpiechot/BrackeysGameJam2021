using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject levelLoadMenu;
    [SerializeField] private GameObject mainMenu;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Tutorial"))
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }
    }

    public void OnStart()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            SceneManager.LoadScene("Tutorial1");
        }
        else
        {
            PlayerPrefs.SetInt("SelectedLevel", 1);
            SceneManager.LoadScene("Level1");
        }
    }
    public void OnLoadLevel(int level)
    {
        PlayerPrefs.SetInt("SelectedLevel", level);
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
    public void OnLoadTutorial()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
