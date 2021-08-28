using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject levelLoadMenu;
    [SerializeField] private GameObject mainMenu;
    
    public void OnStart()
    {
        
    }
    public void OnLoadLevel()
    {
        //Load the selected Level
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
