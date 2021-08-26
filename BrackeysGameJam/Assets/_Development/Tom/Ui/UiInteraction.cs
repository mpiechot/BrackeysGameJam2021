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

    private void Start()
    {
        OnNextWave(0);
    }

    void Update()
    {
        UpdateDisplayText();
        UpdateDisplayVal();
    }

    private void UpdateDisplayText()
    {
        coinsTextField.text = $"Coins: {currentCoinDisplayVal}";
    }

    private void UpdateWaveText(int waveNum)
    {
        waveTextField.text = $"Wave          - {waveNum} - \nHave Fun!";
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
}
