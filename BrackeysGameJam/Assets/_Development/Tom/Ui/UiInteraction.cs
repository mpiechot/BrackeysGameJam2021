using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInteraction : MonoBehaviour
{


    private int targetCoinVal;
    private int currentCoinDisplayVal;
    [SerializeField] private TMPro.TMP_Text coinsTextField;

    private void Start()
    {
        // TODO: Subscribe to Coins Change Event
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

    private void OnCoinChange(int newCoinValue)
    {
        targetCoinVal = newCoinValue;
    }

}
