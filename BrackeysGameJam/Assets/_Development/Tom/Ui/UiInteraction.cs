using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInteraction : MonoBehaviour
{

    private int targetCoinVal;
    private int currentCoinDisplayVal;
    [SerializeField] private TMPro.TMP_Text coinsTextField;
    [SerializeField] private TMPro.TMP_Text waveTextField;
    [SerializeField] private TMPro.TMP_Text lifeTextField;
    [SerializeField] private TMPro.TMP_Text playerTextField;

    [SerializeField] private GameObject goPanel;
    [SerializeField] private GameObject nextLevelButton;

    void Update()
    {
        UpdateDisplayText();
        UpdateDisplayVal();
    }

    private void UpdateDisplayText()
    {
        coinsTextField.text = currentCoinDisplayVal.ToString() ;
    }

    private void UpdateLifeText(int lives)
    {
        lifeTextField.text = lives.ToString();
    }

    private void UpdatePowerText(int power)
    {
        playerTextField.text = power.ToString();
    }

    private void UpdateWaveText(int waveNum)
    {
        waveTextField.text = waveNum.ToString();
    }

    private void UpdateWonText()
    {
        waveTextField.text = $"You          - Won - \nThe Game!";

    }
    private void UpdateLostText()
    {
        waveTextField.text = $"You          - Lost - \nThe Game!";

    }

    private void UpdateDisplayVal()
    {
        if (Mathf.Abs(currentCoinDisplayVal - targetCoinVal) > 10)
        {
            currentCoinDisplayVal = (int)Mathf.Lerp(currentCoinDisplayVal, targetCoinVal, 0.1f);
        }
        else
        {
            currentCoinDisplayVal = targetCoinVal;
        }
    }

    public void OnCoinChange(int newCoinValue)
    {
        targetCoinVal = newCoinValue;
    }


    public void OnNextWave(int currentWave)
    {
        UpdateWaveText(currentWave);
    }
    public void OnWonGame()
    {
        UpdateWonText();
        PauseMenuControl.SetTimeScale(0);
        nextLevelButton.SetActive(true);
        goPanel.SetActive(true);
    }

    public void OnLifeChange(int currentLife)
    {
        UpdateLifeText(currentLife);
    }

    public void OnGameOver()
    {
        UpdateLostText();
        PauseMenuControl.SetTimeScale(0);
        nextLevelButton.SetActive(false);
        goPanel.SetActive(true);
    }

    public void OnPowerChange(int newPower)
    {
        UpdatePowerText(newPower);
    }
}
