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

    void Update()
    {
        UpdateDisplayText();
        UpdateDisplayVal();
    }

    private void UpdateDisplayText()
    {
        coinsTextField.text = $"Coins: {currentCoinDisplayVal}";
    }

    private void UpdateLifeText(int lives)
    {
        lifeTextField.text = $"Lives: {lives}";
    }

    private void UpdatePowerText(int power)
    {
        playerTextField.text = $"PlayerPower: {power}";
    }

    private void UpdateWaveText(int waveNum)
    {
        waveTextField.text = $"Wave          - {waveNum} - \nHave Fun!";
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
    }

    public void OnLifeChange(int currentLife)
    {
        UpdateLifeText(currentLife);
    }

    public void OnGameOver()
    {
        UpdateLostText();
    }

    public void OnPowerChange(int newPower)
    {
        UpdatePowerText(newPower);
    }
}
