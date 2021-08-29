using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialProgression : MonoBehaviour
{

    private enum PointTypes
    {
        buildHere,
        nothing
    }
    private enum UIContainerTypes
    {
        goHereBuild,
        buildHere,
        minion,
        enemyspawn,
        attack,
        chaos,
        chaossave,
        gohere2,
        sell,
        end,
        nothing
    }

    [SerializeField] private int tutorialState;
    [SerializeField] private Transform player;
    [SerializeField] private TowerBuildPosition buildPosition;

    [SerializeField] private GameObject[] uiPanels;
    [SerializeField] private Transform[] tutorialPoints;
    [SerializeField] private LifeCycleManager cycleManager;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private GameObject strongEnemy;

    private float timer;
    private int subState;

    public void ProgressToNextStep()
    {
        Array.ForEach(uiPanels, panel => panel.SetActive(false));
        tutorialState++;
        PauseMenuControl.SetTimeScale(1);
        subState = 0;
    }

    public void WaveProgression(int wave)
    {
        print("Progression!");

        if(tutorialState >= 1 && wave >= 2 && tutorialState < 3)
        {
            if (wave == 2) spawner.SetEnemy(strongEnemy);
            ProgressToNextStep();
        }
    }

    private void Update()
    {
        if(tutorialState == 0)
        {
            UpdateTowerBuild();
        }
        else if(tutorialState == 1)
        {
            UpdateDefend();
        }
        else if(tutorialState == 2)
        {
            UpdateChaos();
        }
        else if(tutorialState == 3)
        {
            UpdateSell();
        }
    }

    private void UpdateSell()
    {
        if (subState == 0)
        {

            if (Vector2.Distance(player.position, tutorialPoints[(int)PointTypes.buildHere].position) > 1)
            {
                ActivatePanel(UIContainerTypes.gohere2);
                DeactivatePanel(UIContainerTypes.sell);
            }
            else
            {
                ActivatePanel(UIContainerTypes.sell);
                DeactivatePanel(UIContainerTypes.gohere2);
                timer = 5;
            }
            if (!buildPosition.HasTower)
            {
                PlayerPrefs.SetInt("Tutorial", 1);
                subState = 1;
            }
        }
        else
        {
            DeactivatePanel(UIContainerTypes.sell);
            ActivatePanel(UIContainerTypes.end);
        }
    }

    private void UpdateChaos()
    {
        if (subState == 0)
        {
            if (!buildPosition.HasTarget)
            {
                ActivatePanel(UIContainerTypes.chaos);
                timer = 3;
            }
            else
            {
                subState++;
            }
        }
        else if (subState == 1)
        {
            DeactivatePanel(UIContainerTypes.chaos);
            ActivatePanel(UIContainerTypes.chaossave);
            timer -= Time.unscaledDeltaTime;
            if (timer < 0)
            {
                subState++;
            }
        }
        else
        {
            DeactivatePanel(UIContainerTypes.chaossave);
        }
    }

    private void UpdateDefend()
    {
        if(!cycleManager.enabled)
        {
            cycleManager.enabled = true;
        }
        if (subState == 0 && !buildPosition.HasTarget)
        {
            ActivatePanel(UIContainerTypes.enemyspawn);
            timer = 5;
        }
        else if(timer > 0)
        {
            DeactivatePanel(UIContainerTypes.enemyspawn);
            ActivatePanel(UIContainerTypes.attack);
            PauseMenuControl.SetTimeScale(0.1f);
            timer -= Time.unscaledDeltaTime;
            subState = 1;
        }
        else if(timer <= 0)
        {
            PauseMenuControl.SetTimeScale(1f);
            DeactivatePanel(UIContainerTypes.attack);
        }
    }

    private void UpdateTowerBuild()
    {
        if (subState == 0)
        {

            if (Vector2.Distance(player.position, tutorialPoints[(int)PointTypes.buildHere].position) > 1)
            {
                ActivatePanel(UIContainerTypes.goHereBuild);
                DeactivatePanel(UIContainerTypes.buildHere);
            }
            else
            {
                ActivatePanel(UIContainerTypes.buildHere);
                DeactivatePanel(UIContainerTypes.goHereBuild);
                timer = 5;
            }
        }

        if(buildPosition.HasTower)
        {
            if(timer > 0)
            {
                DeactivatePanel(UIContainerTypes.buildHere);
                ActivatePanel(UIContainerTypes.minion);
                timer -= Time.deltaTime;
                subState = 1;
            }
            else
            {
                ProgressToNextStep();
            }
        }
    }

    private void ActivatePanel(int num)
    {
        if (!uiPanels[num].activeInHierarchy)
        {
            uiPanels[num].SetActive(true);
        }
    }
    private void ActivatePanel(UIContainerTypes num)
    {
        if (!uiPanels[(int)num].activeInHierarchy)
        {
            uiPanels[(int)num].SetActive(true);
        }
    }

    private void DeactivatePanel(int num)
    {
        if (uiPanels[num].activeInHierarchy)
        {
            uiPanels[num].SetActive(false);
        }
    }
    private void DeactivatePanel(UIContainerTypes num)
    {
        if (uiPanels[(int)num].activeInHierarchy)
        {
            uiPanels[(int)num].SetActive(false);
        }
    }
}
